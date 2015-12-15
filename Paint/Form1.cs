using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace SimplePaint
{
   

    public partial class Form1 : Form
    {
        private bool Brush = true;                      //Uses either Brush or Eraser. Default is Brush
        private Shapes Drawings = new Shapes();    //Stores all the drawing data
        private ShapesList memoryShapes = new ShapesList();
        private bool IsPainting = false;                //Is the mouse currently down (PAINTING)
        private bool IsEraseing = false;                 //Is the mouse currently down (ERASEING)
        private Point LastPos = new Point(0, 0);        //Last Position, used to cut down on repative data.
        private Color CurrentColour = Color.Black;      //Deafult Colour
        private float CurrentWidth = 10;                //Deafult Pen width
        private int ShapeNum = 0;                       //record the shapes so they can be drawn sepratley.
        private Point MouseLoc = new Point(0, 0);       //Record the mouse position
        private bool IsMouseing = false;                //Draw the mouse?

        private ShapeName selectedShape=0;
        private Point ShapeOrigin = new Point(0, 0);
        private Point ShapeEnd = new Point(0, 0);
        private float drawSize = 10;
        private Color drawColor ;
        private bool load = false;
        private int img_index;
        private List<System.IO.FileInfo> files;

        public Form1()
        {
            InitializeComponent();
            //Set Double Buffering
            panel1.GetType().GetMethod("SetStyle", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(panel1, new object[] { System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.DoubleBuffer, true });
            img_index = 0;
            files=new List<System.IO.FileInfo>();
            setDrawColor(Color.Black);
        }


        private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //If we're painting...
            if (Brush && selectedShape==0)
            {
                //set it to mouse down, illatrate the shape being drawn and reset the last position
                IsPainting = true;
                ShapeNum++;
                LastPos = new Point(0, 0);
            }
            else if (Brush && selectedShape !=0)
            {
                    //set this position as the last positon
                    //store the position, width, colour and shape relation data
                    ShapeOrigin = e.Location;
                    IsPainting = true;
                
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
            if (IsPainting && selectedShape==0)
            {
                //check its not at the same place it was last time, saves on recording more data.
                if (LastPos != e.Location)
                {
                    //set this position as the last positon
                    LastPos = e.Location;
                    //store the position, width, colour and shape relation data
                    Drawings.NewShape(LastPos, drawSize, drawColor, ShapeNum);
                }
            }
            
            if (IsEraseing)
            {
                //Remove any point within a certain distance of the mouse
                Drawings.RemoveShape(e.Location,10);
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
                if ( selectedShape!=0) {

                    ShapeEnd = e.Location;
                    ShapeConc shapeToDraw = ShapeFactory.giveShape(selectedShape, ShapeOrigin, ShapeEnd,drawColor,drawSize);
                    memoryShapes.NewShape(shapeToDraw);
                    
                    selectedShape = 0;
                }
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
            if (load)
            {

                Image imag = Image.FromFile(files[img_index].FullName);
                e.Graphics.DrawImage(imag, new Point(0, 0));

            }
            //DRAW THE LINES
            for (int i = 0; i < Drawings.NumberOfShapes()-1; i++)
            {
                DrawShape T = Drawings.GetShape(i);
                DrawShape T1 = Drawings.GetShape(i + 1);
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
            for (int i = 0; i < memoryShapes.NumberOfShapes(); ++i)
            {
                memoryShapes.GetShape(i).setGraphics(e.Graphics);
                memoryShapes.GetShape(i).drawShape();
            
            }
            


            //If mouse is on the panel, draw the mouse
            if (IsMouseing)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Black, 0.5f), MouseLoc.X - (CurrentWidth / 2), MouseLoc.Y - (CurrentWidth / 2), CurrentWidth, CurrentWidth);
            }
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            //Go from the BRUSH to the ERASER
            Brush = false;
        }

        private void clearPanel() {

            //Reset the list, removeing all shapes.
            Drawings = new Shapes();
            memoryShapes = new ShapesList();
            load = false;
            panel1.Refresh();
        }
      

        private void button3_Click(object sender, EventArgs e)
        {
            clearPanel();
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

        private void button4_Click(object sender, EventArgs e)
        {
            using (var bmp = new Bitmap(panel1.Width, panel1.Height))
            {
                string filename=Interaction.InputBox("Give file name");
                if (filename == "")
                {
                    MessageBox.Show("Save Canceled");
                    return;
                }
                else
                {
                    panel1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save(filename + ".png");
                }
            }
            MessageBox.Show("Image saved successfully.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Brush = true;
        }

        public void setDrawColor(Color c)
        {
            drawColor = c;
            button2.BackColor = c;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Colors_Form.getInstance(this).Show();
        }

        private void drawSize_inc_button_Click(object sender, EventArgs e)
        {
            if (drawSize < 15f)
            {
                drawSize += 1;
                int res_index=((((int)drawSize-5)/2)+1);
                res_index= res_index==6? res_index-1:res_index;
                label1.Image = (Image)SimplePaint.Properties.Resources.ResourceManager.GetObject("th-" + res_index);
              //  label1.Text = drawSize.ToString();
            }
            
        }

        private void drawSize_dec_button_Click(object sender, EventArgs e)
        {
            if (drawSize > 5f)
            {
                drawSize -= 1;
                int res_index = ((((int)drawSize - 5) / 2) + 1);
                res_index = res_index == 6 ? res_index - 1 : res_index;
                label1.Image = (Image)SimplePaint.Properties.Resources.ResourceManager.GetObject("th-" + res_index);
               // label1.Text = drawSize.ToString();
            }
        }

        private void btn_Rectangle_Click(object sender, EventArgs e)
        {
            
            selectedShape = ShapeName.Rectangle;
        }

        private void btn_Circle_Click(object sender, EventArgs e)
        {
            
            selectedShape = ShapeName.Circle;
        }

        private void btn_Square_Click(object sender, EventArgs e)
        {
            
            selectedShape = ShapeName.Square;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            load = true;
            panel1.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Template_Form.getInstance(this).Show();
        }
        public void loadImage(int index) {
            clearPanel();
            img_index = index;
            load = true;
            panel1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"temps");
            
            foreach (System.IO.FileInfo file in dir.GetFiles())
            {
                files.Add(file);
                try
                {
                    this.ımageList1.Images.Add(Image.FromFile(file.FullName));
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }
        }

    }

    public class DrawShape
    {
        public Point Location;          //position of the point
        public float Width;             //width of the line
        public Color Colour;            //colour of the line
        public int ShapeNumber;         //part of which shape it belongs to

        //CONSTRUCTOR
        public DrawShape(Point L, float W, Color C, int S)
        {
            Location = L;               //Stores the Location
            Width = W;                  //Stores the width
            Colour = C;                 //Stores the colour
            ShapeNumber = S;            //Stores the shape number
        }
    }
    public class Shapes
    {
        private List<DrawShape> _Shapes;    //Stores all the shapes

        public Shapes()
        {
            _Shapes = new List<DrawShape>();
        }
        //Returns the number of shapes being stored.
        public int NumberOfShapes()
        {
            return _Shapes.Count;
        }
        //Add a shape to the database, recording its position, width, colour and shape relation information
        public void NewShape(Point L, float W, Color C, int S)
        {
            _Shapes.Add(new DrawShape(L, W, C, S));
        }
        //returns a shape of the requested data.
        public DrawShape GetShape(int Index)
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
