namespace JaProjekt
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
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            checkBox1 = new CheckBox();
            button5 = new Button();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(119, 739);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 0;
            button1.Text = "Create fractal";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(55, 686);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(223, 686);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 689);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 3;
            label1.Text = "Re: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(190, 689);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 4;
            label2.Text = "Im: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(519, 671);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 5;
            label3.Text = "Fractal 1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(636, 671);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 6;
            label4.Text = "Fractal 2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(761, 671);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 7;
            label5.Text = "Fractal 3";
            // 
            // button2
            // 
            button2.Location = new Point(507, 689);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 8;
            button2.Text = "Create";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(627, 689);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 9;
            button3.Text = "Create";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(749, 689);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 10;
            button4.Text = "Create";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(616, 643);
            label6.Name = "label6";
            label6.Size = new Size(99, 15);
            label6.TabIndex = 11;
            label6.Text = "Example fractals :";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(24, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(858, 475);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(55, 668);
            label7.Name = "label7";
            label7.Size = new Size(98, 15);
            label7.TabIndex = 13;
            label7.Text = "Best :  -1.2 to -0.7";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(223, 668);
            label8.Name = "label8";
            label8.Size = new Size(90, 15);
            label8.TabIndex = 14;
            label8.Text = "Best : -0.3 to 0.3";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(67, 580);
            label9.Name = "label9";
            label9.Size = new Size(57, 15);
            label9.TabIndex = 15;
            label9.Text = "Threads : ";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(24, 505);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 17;
            checkBox1.Text = "Save to file";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(280, 739);
            button5.Name = "button5";
            button5.Size = new Size(112, 23);
            button5.TabIndex = 21;
            button5.Text = "Create with asm";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(507, 718);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(81, 19);
            checkBox2.TabIndex = 22;
            checkBox2.Text = "Assembler";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(627, 718);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(81, 19);
            checkBox3.TabIndex = 23;
            checkBox3.Text = "Assembler";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(749, 718);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(81, 19);
            checkBox4.TabIndex = 24;
            checkBox4.Text = "Assembler";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(507, 509);
            label11.Name = "label11";
            label11.Size = new Size(105, 15);
            label11.TabIndex = 25;
            label11.Text = "Execution time c#:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(716, 509);
            label12.Name = "label12";
            label12.Size = new Size(114, 15);
            label12.TabIndex = 26;
            label12.Text = "Execution time asm:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(627, 509);
            label13.Name = "label13";
            label13.Size = new Size(13, 15);
            label13.TabIndex = 27;
            label13.Text = "0";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(843, 509);
            label14.Name = "label14";
            label14.Size = new Size(13, 15);
            label14.TabIndex = 28;
            label14.Text = "0";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(67, 598);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 29;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 783);
            Controls.Add(textBox3);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(button5);
            Controls.Add(checkBox1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(pictureBox1);
            Controls.Add(label6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Julia Fractals";
            Load += Form1_Load;
            Paint += Form1_Paint;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label6;
        private PictureBox pictureBox1;
        private Label label7;
        private Label label8;
        private Label label9;
        private CheckBox checkBox1;
        private Button button5;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox textBox3;
    }
}
