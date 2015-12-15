using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePaint
{
    
    public interface Shape
    {
        
         void drawShape();
    }

    public abstract class ShapeConc :Shape
    {
        private Graphics graphics;
        private Point origin ;
        private Point end ;
        private int shapeNumber;
        private Color color;
        private float drawSize;

        public Point getOrigin(){
            return origin;
        }
        public Point getEnd()
        {
            return end;
        }
        public int getShapeNumber()
        {
            return shapeNumber;
        }
        public Graphics getGraphics(){
            return graphics;
        }
        public Color getColor() { return color; }
        public float getSize() { return drawSize; }

        public void setOrigin(Point origin)
        {
            this.origin = origin;
        }
        public void setEnd(Point end)
        {
            this.end = end;
        }
        public void setShapeNumber(int num)
        {
            this.shapeNumber = num;

        }
        public void setGraphics(Graphics g)
        {
            this.graphics = g;
        }
        public void setColor(Color c) { color = c; }
        public void setSize(float size) { drawSize = size; }
        public virtual void drawShape( )
        {
            throw new NotImplementedException();
        }
    }
    
    public enum ShapeName
    {
        Rectangle=1,Circle=2,Square=3
    };

    public class Circle : ShapeConc
    {

        public Circle(Point origin, Point end,Color c, float width)
        {
            base.setOrigin(origin);
            base.setEnd(end);
            base.setColor(c);
            base.setSize(width);

        }
        
        public override void drawShape( )
        {
            SolidBrush sb = new SolidBrush(getColor());
            Pen pn = new Pen(sb,getSize());
            if (getGraphics() != null)
                //getGraphics().FillEllipse(sb, base.getOrigin().X, base.getOrigin().Y, Math.Abs(base.getOrigin().X - base.getEnd().X), Math.Abs(base.getOrigin().Y - base.getEnd().Y));
                getGraphics().DrawEllipse(pn, base.getOrigin().X, base.getOrigin().Y, Math.Abs(base.getOrigin().X - base.getEnd().X), Math.Abs(base.getOrigin().Y - base.getEnd().Y));
        }
    }
    public class Rectangle : ShapeConc
    {



        public Rectangle(Point origin, Point end, Color c, float width)
        {
            base.setOrigin(origin);
            base.setEnd(end);
            base.setColor(c);
            base.setSize(width);

        }
        public override void drawShape()
        {
            SolidBrush sb = new SolidBrush(getColor());
            Pen pn = new Pen(sb, getSize());
            if (getGraphics() != null)
                //getGraphics().FillRectangle(sb, base.getOrigin().X, base.getOrigin().Y, Math.Abs(base.getOrigin().X - base.getEnd().X), Math.Abs(base.getOrigin().Y - base.getEnd().Y));
            getGraphics().DrawRectangle(pn, base.getOrigin().X, base.getOrigin().Y, Math.Abs(base.getOrigin().X - base.getEnd().X), Math.Abs(base.getOrigin().Y - base.getEnd().Y));
        }
    }
    public class Square : ShapeConc
    {

        public Square(Point origin, Point end, Color c, float width)
        {
            base.setOrigin(origin);
            base.setEnd(end);
            base.setColor(c);
            base.setSize(width);
        }

        public override void drawShape()
        {
            SolidBrush sb = new SolidBrush(getColor());
            Pen pn = new Pen(sb, getSize());
            if (getGraphics() != null)
                //getGraphics().FillRectangle(sb, base.getOrigin().X, base.getOrigin().Y, Math.Abs(base.getOrigin().Y - base.getEnd().Y), Math.Abs(base.getOrigin().Y - base.getEnd().Y));
            getGraphics().DrawRectangle(pn, base.getOrigin().X, base.getOrigin().Y, Math.Abs(base.getOrigin().Y - base.getEnd().Y), Math.Abs(base.getOrigin().Y - base.getEnd().Y));
        }
    }

    // Factory class
    public class ShapeFactory
    {
        public static ShapeConc giveShape(ShapeName sn, Point org, Point end, Color c, float width)
        {
            if (sn == ShapeName.Square) {
                return new Square(org,end,c, width);
            }
            else if (sn == ShapeName.Rectangle)
            {
                return new Rectangle(org, end, c, width);
            }
            else if (sn == ShapeName.Circle)
            {
                return new Circle(org, end, c, width);
            }
            return null;
        }
    }
    //memory of shapes 
    public class ShapesList
    {
        private List<ShapeConc> _Shapes;    //Stores all the shapes

        public ShapesList()
        {
            _Shapes = new List<ShapeConc>();
        }
        //Returns the number of shapes being stored.
        public int NumberOfShapes()
        {
            return _Shapes.Count;
        }
        //Add a shape to the database, recording its position, width, colour and shape relation information
        public void NewShape(ShapeConc shp)
        {
            _Shapes.Add(shp);
        }
        //returns a shape of the requested data.
        public ShapeConc GetShape(int Index)
        {
            return _Shapes[Index];
        }
        //Removes any point data within a certain threshold of a point.
        public void RemoveShape(Point L, float threshold)
        {
            for (int i = 0; i < _Shapes.Count; i++)
            {
                //Finds if a point is within a certain distance of the point to remove.
                if ((Math.Abs(L.X - _Shapes[i].getOrigin().X) < threshold) && (Math.Abs(L.Y - _Shapes[i].getOrigin().Y) < threshold))
                {
                    //removes all data for that number
                    _Shapes.RemoveAt(i);

                    //goes through the rest of the data and adds an extra 1 to defined them as a seprate shape and shuffles on the effect.
                    for (int n = i; n < _Shapes.Count; n++)
                    {
                        _Shapes[n].setShapeNumber(_Shapes[n].getShapeNumber()+1);
                    }
                    //Go back a step so we dont miss a point.
                    i -= 1;
                }
            }
        }
    }

}
