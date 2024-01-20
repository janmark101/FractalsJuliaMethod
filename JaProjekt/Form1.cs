using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace JaProjekt
{
    public partial class Form1 : Form
    {
        [DllImport(@"C:\Users\janma\source\repos\JaProjekt\x64\Debug\JAAsm.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MyProc2(byte[] pixelData, double cx, double cy);
        [DllImport(@"C:\Users\janma\source\repos\JaProjekt\x64\Debug\JAAsm.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MyProc3(byte[] pixelData, double cx, double cy,int x, int y);

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            int logicalProcessorCount = Environment.ProcessorCount;
            textBox3.Text = logicalProcessorCount.ToString();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

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

            if (checkBox2.Checked)
            {
                assemblerPressed(-0.77097, -0.08545);
            }
            else
            {
                button_clicked(-0.77097, -0.08545);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                assemblerPressed(-0.65488, -0.4477);
            }
            else
            {
                button_clicked(-0.65488, -0.4477);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                assemblerPressed(-0.7, 0.27015);
            }
            else
            {
                button_clicked(-0.7, 0.27015);
            }

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
            int threads = Convert.ToInt32(textBox3.Text);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();


            JuliaFractal.Class1.DrawJuliaFractal(this.CreateGraphics(), re, im, threads, pictureBox1);



            stopwatch.Stop();

            bool isCheckBoxChecked = checkBox1.Checked;
            if (isCheckBoxChecked)
            {
                SavePictureBoxToPng();
            }

            label13.Text = $"{stopwatch.ElapsedMilliseconds} ms";

        }


        private void SavePictureBoxToPng()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki PNG|*.png";
            saveFileDialog.Title = "Zapisz obraz do pliku PNG";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                try
                {
                    bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                    MessageBox.Show("Obraz zosta³ pomyœlnie zapisany.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wyst¹pi³ b³¹d podczas zapisywania obrazu: " + ex.Message, "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                double re = Convert.ToDouble(textBox1.Text, CultureInfo.InvariantCulture);
                double im = Convert.ToDouble(textBox2.Text, CultureInfo.InvariantCulture);
                assemblerPressed(re, im);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void assemblerPressed(double re, double im)
        {
            //if(pictureBox1.Image != null)
            //{
            //    pictureBox1.Image.Dispose();
            //}

            int threads = Convert.ToInt32(textBox3.Text);

            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format32bppRgb);
            pictureBox1.Image = bitmap;

            BitmapData bmpData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.WriteOnly,
                bitmap.PixelFormat);



            int bytesPerPixel = 4;
            int stride = bmpData.Stride;
            byte[] fractalpixels = new byte[pictureBox1.Width * pictureBox1.Height * bytesPerPixel];

            IntPtr pixelDataPtr = bmpData.Scan0;
            Marshal.Copy(pixelDataPtr, fractalpixels, 0, fractalpixels.Length);

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();


            //Parallel.For(0, pictureBox1.Width, new ParallelOptions { MaxDegreeOfParallelism = threads }, x =>
            //{
            //    for (int y = 0; y < pictureBox1.Height; y++)
            //    {
            //        MyProc3(fractalpixels, re, im, x, y);
            //    }
            //});


            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    MyProc3(fractalpixels, re, im, x, y);
                }
            }



            stopwatch.Stop();
            label14.Text = $"{stopwatch.ElapsedMilliseconds} ms";

            Marshal.Copy(fractalpixels, 0, bmpData.Scan0, fractalpixels.Length);
            bitmap.UnlockBits(bmpData);


            pictureBox1.Image = bitmap;

        }


    }

}
