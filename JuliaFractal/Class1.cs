using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace JuliaFractal
{
    public class Class1
    {

        private const int MaxIterations = 1000;
        private const double Zoom = 1;
        private const double OffsetX = 0;
        private const double OffsetY = 0;

        static public void DrawJuliaFractal(Graphics g, double cX, double cY, int numThreads, System.Windows.Forms.PictureBox picturebox)
        {

            Bitmap bitmap = new Bitmap(picturebox.Width, picturebox.Height);

            Parallel.For(0, picturebox.Width, new ParallelOptions { MaxDegreeOfParallelism = numThreads }, x =>
            {
                for (int y = 0; y < picturebox.Height; y++)
                {
                    double zx = 1.5 * (x - picturebox.Width / 2) / (0.5 * Zoom * picturebox.Width) + OffsetX;
                    double zy = (y - picturebox.Height / 2) / (0.5 * Zoom * picturebox.Height) + OffsetY;

                    int iteration = 0;
                    double temp = zx * zx + zy * zy;
                    while (zx * zx + zy * zy < 4 && iteration < MaxIterations)
                    {
                        double tmp = zx * zx - zy * zy + cX;
                        zy = 2 * zx * zy + cY;
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


            picturebox.Image = bitmap;
        }

        static public void DrawJuliaFractal2(Graphics g, double cX, double cY, int numThreads, System.Windows.Forms.PictureBox picturebox)
        {

            Bitmap bitmap = new Bitmap(picturebox.Width, picturebox.Height);

            for (int x = 0; x < picturebox.Width; x++)
            {
                for (int y = 0; y < picturebox.Height; y++)
                {
                    double t = picturebox.Width / 2;
                    double zx = 1.5 * (x - picturebox.Width / 2) / (0.5 * Zoom * picturebox.Width) + OffsetX;
                    double zy = (y - picturebox.Height / 2) / (0.5 * Zoom * picturebox.Height) + OffsetY;

                    int iteration = 0;
                    double temp = zx * zx + zy * zy;
                    while (temp < 4 && iteration < MaxIterations)
                    {
                        double temp_2 = zx * zx + zy * zy;
                        double tmp = zx * zx - zy * zy + cX;
                        zy = 2 * zx * zy + cY;
                        zx = tmp;
                        double ss = zx * zx + zy * zy;
                        iteration++;
                        temp = (int)(zx * zx + zy * zy);
                    }


                    if (iteration == MaxIterations)
                    {

                        bitmap.SetPixel(x, y, Color.Black);

                    }
                    else
                    {
                        double ratio = (double)iteration / MaxIterations;
                        int red = (int)(9 * (1 - ratio) * ratio * ratio * ratio * 255);
                        int green = (int)(15 * (1 - ratio) * (1 - ratio) * ratio * ratio * 255);
                        int blue = (int)(8.5 * (1 - ratio) * (1 - ratio) * (1 - ratio) * ratio * 255);
                        Color color = Color.FromArgb(red, green, blue);


                        bitmap.SetPixel(x, y, color);


                    }

                }
            }


            picturebox.Image = bitmap;
        }

    }

    
}
