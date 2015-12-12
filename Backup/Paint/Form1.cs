using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Paint
{

    public partial class Form1 : Form
    {
        private bool Brush = true;                      //Uses either Brush or Eraser. Default is Brush
        private Shapes DrawingShapes = new Shapes();    //Stores all the drawing data
        private bool IsPainting = false;                //Is the mouse currently down (PAINTING)
        private bool IsEraseing = false;                 //Is the mouse currently down (ERASEING)
        private Point LastPos = new Point(0, 0);        //Last Position, used to cut down on repative data.
        private Color CurrentColour = Color.Black;      //Deafult Colour
        private float CurrentWidth = 10;                //Deafult Pen width
        private int ShapeNum = 0;                       //record the shapes so they can be drawn sepratley.
        private Point MouseLoc = new Point(0, 0);       //Record the mouse position
        private bool IsMouseing = false;                //Draw the mouse?

        public Form1()
        {
            InitializeComponent();
            //Set Double Buffering
            panel1.GetType().GetMethod("SetStyle", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(panel1, new object[] { System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.DoubleBuffer, true });
        }


        private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //If we're painting...
            if (Brush)
            {
                //set it to mouse down, illatrate the shape being drawn and reset the last position
                IsPainting = true;
                ShapeNum++;
                LastPos = new Point(0, 0);
            }
            //but if we're eraseing...
            else
            {
                IsEraseing = true;
            }
        }

        protected void panel1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseLoc = e.Location;
            //PAINTING
            if (IsPainting)
            {
                //check its not at the same place it was last time, saves on recording more data.
                if (LastPos != e.Location)
                {
                    //set this position as the last positon
                    LastPos = e.Location;
                    //store the position, width, colour and shape relation data
                    DrawingShapes.NewShape(LastPos, CurrentWidth, CurrentColour, ShapeNum);
                }
            }
            if (IsEraseing)
            {
                //Remove any point within a certain distance of the mouse
                DrawingShapes.RemoveShape(e.Location,10);
            }
            //refresh the panel so it will be forced to re-draw.
            panel1.Refresh();
        }

        private void panel1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (IsPainting)
            {
                //Finished Painting.
                IsPainting = false;
            }
            if (IsEraseing)
            {
                //Finished Earsing.
                IsEraseing = false;
            }
        }

        //DRAWING FUNCTION
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Apply a smoothing mode to smooth out the line.
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //DRAW THE LINES
            for (int i = 0; i < DrawingShapes.NumberOfShapes()-1; i++)
            {
                Shape T = DrawingShapes.GetShape(i);
                Shape T1 = DrawingShapes.GetShape(i+1);
                //make sure shape the two ajoining shape numbers are part of the same shape
                if (T.ShapeNumber == T1.ShapeNumber)
                {
                    //create a new pen with its width and colour
                    Pen p = new Pen(T.Colour, T.Width);
                    p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    p.EndCap = System.Drawing.Drawing2D.LineCap.Round; 
                    //draw a line between the two ajoining points
                    e.Graphics.DrawLine(p, T.Location, T1.Location);
                    //get rid of the pen when finished
                    p.Dispose();
                }
            }
            //If mouse is on the panel, draw the mouse
            if (IsMouseing)
            {
                e.Graphics.DrawEllipse(new Pen(Color.White, 0.5f), MouseLoc.X - (CurrentWidth / 2), MouseLoc.Y - (CurrentWidth / 2), CurrentWidth, CurrentWidth);
            }
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            //Go from the BRUSH to the ERASER
            Brush = !Brush;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Show and Get the result of the colour dialog
            DialogResult D = colorDialog1.ShowDialog();
            if (D == DialogResult.OK)
            {
                //Apply the new colour
                CurrentColour = colorDialog1.Color;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //Change the width of the pen. Oh and convert it to a float
            CurrentWidth = Convert.ToSingle(numericUpDown1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Reset the list, removeing all shapes.
            DrawingShapes = new Shapes();
            panel1.Refresh();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            //Hide the mouse cursor and tell the re-drawing function to draw the mouse
            Cursor.Hide();
            IsMouseing = true;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            //show the mouse, tell the re-drawing function to stop drawing it and force the panel to re-draw.
            Cursor.Show();
            IsMouseing = false;
            panel1.Refresh();
        }
    }

    public class Shape
    {
        public Point Location;          //position of the point
        public float Width;             //width of the line
        public Color Colour;            //colour of the line
        public int ShapeNumber;         //part of which shape it belongs to

        //CONSTRUCTOR
        public Shape(Point L, float W, Color C, int S)
        {
            Location = L;               //Stores the Location
            Width = W;                  //Stores the width
            Colour = C;                 //Stores the colour
            ShapeNumber = S;            //Stores the shape number
        }
    }
    public class Shapes
    {
        private List<Shape> _Shapes;    //Stores all the shapes

        public Shapes()
        {
            _Shapes = new List<Shape>();
        }
        //Returns the number of shapes being stored.
        public int NumberOfShapes()
        {
            return _Shapes.Count;
        }
        //Add a shape to the database, recording its position, width, colour and shape relation information
        public void NewShape(Point L, float W, Color C, int S)
        {
            _Shapes.Add(new Shape(L,W,C,S));
        }
        //returns a shape of the requested data.
        public Shape GetShape(int Index)
        {
            return _Shapes[Index];
        }
        //Removes any point data within a certain threshold of a point.
        public void RemoveShape(Point L, float threshold)
        {
            for (int i = 0; i < _Shapes.Count; i++)
            {
                //Finds if a point is within a certain distance of the point to remove.
                if ((Math.Abs(L.X - _Shapes[i].Location.X) < threshold) &&(Math.Abs(L.Y - _Shapes[i].Location.Y)< threshold))
                {
                    //removes all data for that number
                    _Shapes.RemoveAt(i);

                    //goes through the rest of the data and adds an extra 1 to defined them as a seprate shape and shuffles on the effect.
                    for (int n = i; n < _Shapes.Count; n++)
                    {
                        _Shapes[n].ShapeNumber += 1;
                    }
                    //Go back a step so we dont miss a point.
                    i -= 1;
                }
            }
        }
    }


}
