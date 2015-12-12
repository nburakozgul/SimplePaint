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
    public partial class Colors_Form : Form
    {
        public Colors_Form()
        {
            InitializeComponent();
        }
        // Singleton Pattern
        static Colors_Form m_me;
        static Form1 caller;
        
        public static Colors_Form getInstance(Form1 id)
        {
            if (m_me == null || m_me.IsDisposed)
            {
                m_me = new Colors_Form();
            }
            caller = id;
            return m_me;
        }

        private void setColor(object sender, EventArgs e)
        {
            caller.setDrawColor(((Button)sender).BackColor);
        }

    }
}
