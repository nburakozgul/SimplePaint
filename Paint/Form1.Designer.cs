namespace SimplePaint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.drawSize_inc_button = new System.Windows.Forms.Button();
            this.drawSize_dec_button = new System.Windows.Forms.Button();
            this.btn_Square = new System.Windows.Forms.Button();
            this.btn_Circle = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_Rectangle = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 691);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(221, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 61);
            this.button1.TabIndex = 1;
            this.button1.Text = "Eraser";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(953, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 62);
            this.button3.TabIndex = 4;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(862, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 62);
            this.button4.TabIndex = 0;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Image = global::SimplePaint.Properties.Resources.th_1;
            this.label1.Location = new System.Drawing.Point(113, 15);
            this.label1.MinimumSize = new System.Drawing.Size(90, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 11;
            // 
            // drawSize_inc_button
            // 
            this.drawSize_inc_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawSize_inc_button.Location = new System.Drawing.Point(163, 43);
            this.drawSize_inc_button.Name = "drawSize_inc_button";
            this.drawSize_inc_button.Size = new System.Drawing.Size(40, 34);
            this.drawSize_inc_button.TabIndex = 9;
            this.drawSize_inc_button.Text = "+";
            this.drawSize_inc_button.UseVisualStyleBackColor = true;
            this.drawSize_inc_button.Click += new System.EventHandler(this.drawSize_inc_button_Click);
            // 
            // drawSize_dec_button
            // 
            this.drawSize_dec_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawSize_dec_button.Location = new System.Drawing.Point(113, 43);
            this.drawSize_dec_button.Name = "drawSize_dec_button";
            this.drawSize_dec_button.Size = new System.Drawing.Size(40, 34);
            this.drawSize_dec_button.TabIndex = 10;
            this.drawSize_dec_button.Text = "-";
            this.drawSize_dec_button.UseVisualStyleBackColor = true;
            this.drawSize_dec_button.Click += new System.EventHandler(this.drawSize_dec_button_Click);
            // 
            // btn_Square
            // 
            this.btn_Square.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Square.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Square.Location = new System.Drawing.Point(615, 12);
            this.btn_Square.Name = "btn_Square";
            this.btn_Square.Size = new System.Drawing.Size(89, 62);
            this.btn_Square.TabIndex = 13;
            this.btn_Square.Text = "Square";
            this.btn_Square.UseVisualStyleBackColor = false;
            this.btn_Square.Click += new System.EventHandler(this.btn_Square_Click);
            // 
            // btn_Circle
            // 
            this.btn_Circle.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Circle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Circle.Location = new System.Drawing.Point(520, 12);
            this.btn_Circle.Name = "btn_Circle";
            this.btn_Circle.Size = new System.Drawing.Size(89, 62);
            this.btn_Circle.TabIndex = 16;
            this.btn_Circle.Text = "Circle";
            this.btn_Circle.UseVisualStyleBackColor = false;
            this.btn_Circle.Click += new System.EventHandler(this.btn_Circle_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::SimplePaint.Properties.Resources.pencil2_80;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(13, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 62);
            this.button5.TabIndex = 14;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_Rectangle
            // 
            this.btn_Rectangle.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Rectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Rectangle.Location = new System.Drawing.Point(425, 12);
            this.btn_Rectangle.Name = "btn_Rectangle";
            this.btn_Rectangle.Size = new System.Drawing.Size(89, 62);
            this.btn_Rectangle.TabIndex = 15;
            this.btn_Rectangle.Text = "Rectangle";
            this.btn_Rectangle.UseVisualStyleBackColor = false;
            this.btn_Rectangle.Click += new System.EventHandler(this.btn_Rectangle_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::SimplePaint.Properties.Resources.true_colors;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(317, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(89, 62);
            this.button6.TabIndex = 12;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(771, 13);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(85, 62);
            this.button7.TabIndex = 18;
            this.button7.Text = "Template";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ımageList1.ImageSize = new System.Drawing.Size(256, 256);
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 786);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btn_Square);
            this.Controls.Add(this.btn_Circle);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btn_Rectangle);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drawSize_inc_button);
            this.Controls.Add(this.drawSize_dec_button);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Simple Paint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button drawSize_inc_button;
        private System.Windows.Forms.Button drawSize_dec_button;
        private System.Windows.Forms.Button btn_Square;
        private System.Windows.Forms.Button btn_Circle;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_Rectangle;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ImageList ımageList1;
    }
}

