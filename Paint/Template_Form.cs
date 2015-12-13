using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class Template_Form : Form
    {

        private int index;
        // Singleton Pattern
        static Template_Form m_me;
        static Form1 caller;

        private Template_Form()
        {
            InitializeComponent();
            index = 0;
        }

        public static Template_Form getInstance(Form1 id)
        {
            if (m_me == null || m_me.IsDisposed)
            {
                m_me = new Template_Form();
            }
            caller = id;
            return m_me;
        }

        
        private void Template_Form_Load(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"temps");
            foreach (System.IO.FileInfo file in dir.GetFiles())
            {
                try
                {
                    this.ımageList1.Images.Add(Image.FromFile(file.FullName));
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            refreshImage(index);
            
            

            /*
            this.listView1.View = View.List;
            this.ımageList1.ImageSize = new Size(32, 32);
            this.listView1.LargeImageList = this.ımageList1;*/
            //or
            //this.listView1.View = View.SmallIcon;
            //this.listView1.SmallImageList = this.imageList1;
            /*
            for (int j = 0; j < this.ımageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                this.listView1.Items.Add(item);
            }*/
        }
        private void refreshImage(int ind) {
            
            pictureBox1.Image = ımageList1.Images[index];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                refreshImage(index);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (index < ımageList1.Images.Count-1)
            {
                index++;
                refreshImage(index);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            caller.loadImage(index);
        }

    }
}
