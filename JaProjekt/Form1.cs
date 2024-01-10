using System.Diagnostics;
using System.Globalization;


namespace JaProjekt
{
    public partial class Form1 : Form
    {

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
            int threads = Convert.ToInt32(GetSelectedRadioButtonText(groupBox1));
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            JuliaFractal.Class1.DrawJuliaFractal(this.CreateGraphics(), re, im, threads, pictureBox1);
            stopwatch.Stop();

            MessageBox.Show($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }
    }

}
