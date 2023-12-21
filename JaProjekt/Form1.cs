using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;


namespace JaProjekt
{
    public partial class Form1 : Form
    {
        [DllImport(@"C:\Users\janma\source\repos\JaProjekt\x64\Debug\JAAsm.dll")]
        static extern int MyProc1(int a, int b);

        private Bitmap bitmap;
        private const int MaxIterations = 1000;
        private const double Zoom = 1;
        private const double OffsetX = 0;
        private const double OffsetY = 0;
        private object lockObject = new object();
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            int logicalProcessorCount = Environment.ProcessorCount;
            foreach (RadioButton radioButton in groupBox1.Controls.OfType<RadioButton>())
            {
                if (radioButton.Text == logicalProcessorCount.ToString())
                {
                    radioButton.Checked = true;
                    break;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DrawJuliaFractal(Graphics g, double cX, double cY, int numThreads)
        {

            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Parallel.For(0, pictureBox1.Width, new ParallelOptions { MaxDegreeOfParallelism = numThreads }, x =>
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    double zx = 1.5 * (x - pictureBox1.Width / 2) / (0.5 * Zoom * pictureBox1.Width) + OffsetX;
                    double zy = (y - pictureBox1.Height / 2) / (0.5 * Zoom * pictureBox1.Height) + OffsetY;

                    int iteration = 0;
                    while (zx * zx + zy * zy < 4 && iteration < MaxIterations)
                    {
                        double tmp = zx * zx - zy * zy + cX;
                        zy = 2.0 * zx * zy + cY;
                        zx = tmp;
                        iteration++;
                    }


                    if (iteration == MaxIterations)
                    {
                        lock (bitmap)
                        {
                            bitmap.SetPixel(x, y, Color.Black);
                        }
                    }
                    else
                    {
                        double ratio = (double)iteration / MaxIterations;
                        int red = (int)(9 * (1 - ratio) * ratio * ratio * ratio * 255);
                        int green = (int)(15 * (1 - ratio) * (1 - ratio) * ratio * ratio * 255);
                        int blue = (int)(8.5 * (1 - ratio) * (1 - ratio) * (1 - ratio) * ratio * 255);
                        Color color = Color.FromArgb(red, green, blue);

                        lock (bitmap)
                        {
                            bitmap.SetPixel(x, y, color);
                        }

                    }

                }
            });

            pictureBox1.Image = bitmap;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                double re = Convert.ToDouble(textBox1.Text, CultureInfo.InvariantCulture);
                double im = Convert.ToDouble(textBox2.Text, CultureInfo.InvariantCulture);
                button_clicked(re, im);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            button_clicked(-0.77097, -0.08545);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button_clicked(-0.65488, -0.4477);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button_clicked(-0.7, 0.27015);

        }


        private string GetSelectedRadioButtonText(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    return radioButton.Text;
                }
            }

            return string.Empty;
        }

        private void button_clicked(double re, double im)
        {
            int selectedRadioButtonText = Convert.ToInt32(GetSelectedRadioButtonText(groupBox1));
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            DrawJuliaFractal(this.CreateGraphics(), re, im, selectedRadioButtonText);
            stopwatch.Stop();

            MessageBox.Show($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }
    }

}
