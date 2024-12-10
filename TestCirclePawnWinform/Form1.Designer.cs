namespace TestCirclePawnWinform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            textBox1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            lable4 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            label4 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            textBox3 = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            button2 = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            comboBox1 = new System.Windows.Forms.ComboBox();
            label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(1175, 12);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "绘制";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(580, 508);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            textBox1.Location = new System.Drawing.Point(0, 24);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            textBox1.Size = new System.Drawing.Size(364, 409);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 17);
            label1.TabIndex = 3;
            label1.Text = "曲线:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(9, 39);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 17);
            label2.TabIndex = 4;
            label2.Text = "圆心数据";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(9, 72);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(32, 17);
            label3.TabIndex = 5;
            label3.Text = "弧度";
            // 
            // panel1
            // 
            panel1.Controls.Add(lable4);
            panel1.Controls.Add(textBox1);
            panel1.Location = new System.Drawing.Point(614, 160);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(364, 433);
            panel1.TabIndex = 6;
            // 
            // lable4
            // 
            lable4.AutoSize = true;
            lable4.Location = new System.Drawing.Point(3, 4);
            lable4.Name = "lable4";
            lable4.Size = new System.Drawing.Size(80, 17);
            lable4.TabIndex = 3;
            lable4.Text = "圆弧点位数据";
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(textBox2);
            panel2.Location = new System.Drawing.Point(1026, 160);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(344, 433);
            panel2.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 4);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(80, 17);
            label4.TabIndex = 3;
            label4.Text = "曲线点位数据";
            // 
            // textBox2
            // 
            textBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            textBox2.Location = new System.Drawing.Point(0, 24);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            textBox2.Size = new System.Drawing.Size(344, 409);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(791, 9);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(100, 23);
            textBox3.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(729, 15);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(56, 17);
            label5.TabIndex = 9;
            label5.Text = "点位数量";
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label2);
            panel3.Location = new System.Drawing.Point(614, 41);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(756, 113);
            panel3.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(614, 12);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 11;
            button2.Text = "添加点位";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.Color.Yellow;
            label6.Location = new System.Drawing.Point(12, 559);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(123, 17);
            label6.TabIndex = 12;
            label6.Text = "_______________________";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(172, 566);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(68, 17);
            label7.TabIndex = 13;
            label7.Text = "圆弧上的点";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(172, 619);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(68, 17);
            label8.TabIndex = 15;
            label8.Text = "曲线上的点";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = System.Drawing.Color.Blue;
            label9.Location = new System.Drawing.Point(12, 612);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(123, 17);
            label9.TabIndex = 14;
            label9.Text = "_______________________";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(172, 671);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(80, 17);
            label10.TabIndex = 17;
            label10.Text = "开始给出的点";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = System.Drawing.Color.Red;
            label11.Location = new System.Drawing.Point(12, 664);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(123, 17);
            label11.TabIndex = 16;
            label11.Text = "_______________________";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(973, 9);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(121, 25);
            comboBox1.TabIndex = 18;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(917, 15);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(56, 17);
            label12.TabIndex = 19;
            label12.Text = "计算类型";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1410, 720);
            Controls.Add(label12);
            Controls.Add(comboBox1);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(panel3);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lable4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
    }
}
