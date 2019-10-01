using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processor
{
    static class ImageProcessor
    {

        public static Bitmap Convolution(Bitmap input, int windowDemension = 5, double[,] window = null)
        {
            if (window == null)
            {
                window = GenRandomWindow(windowDemension);
            }

            Bitmap resultBmp = input;
            int borderWidth = windowDemension / 2;
            int x, y;
            double r, g, b;
            Color c;

            for (y = borderWidth; y < input.Height - borderWidth; y++)
            {
                for (x = borderWidth; x < input.Width - borderWidth; x++)
                {
                    r = 0; g = 0; b = 0;
                    for (int i = -1 * borderWidth; i <= borderWidth; i++)
                        for (int j = -1 * borderWidth; j <= borderWidth; j++)
                        {
                            c = input.GetPixel(x + i, y + j);
                            //r += c.R / 25; g += c.G / 25; b += c.B / 25;
                            r += c.R * window[i + borderWidth, j + borderWidth];
                            g += c.G * window[i + borderWidth, j + borderWidth];
                            b += c.B * window[i + borderWidth, j + borderWidth];
                        }
                    if (r < 0)
                        r = 0;
                    else if (r > 255)
                        r = 255;
                    if (g < 0)
                        g = 0;
                    else if (g > 255)
                        g = 255;
                    if (b < 0)
                        b = 0;
                    else if (b > 255)
                        b = 255;
                    c = Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
                    resultBmp.SetPixel(x, y, c);
                }

            }
            return resultBmp;
        }
        public static Bitmap Convolution(Bitmap inputBmp, double[,] window)
        {
            Bitmap resultBmp = inputBmp;
            int borderWidth = window.GetLength(0) / 2;
            double r, g, b;
            Color c;

            unsafe
            {
                BitmapData bitmapData = inputBmp.LockBits(new Rectangle(0, 0, inputBmp.Width, inputBmp.Height), ImageLockMode.ReadWrite, inputBmp.PixelFormat);
                BitmapData output_bitmapData = resultBmp.LockBits(new Rectangle(0, 0, inputBmp.Width, inputBmp.Height), ImageLockMode.ReadWrite, inputBmp.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(inputBmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;
                byte* output_ptrFirstPixel = (byte*)output_bitmapData.Scan0;

                for (int y = borderWidth; y < heightInPixels - borderWidth; y++)
                {
                    byte* input_currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    byte* output_currentLine = output_ptrFirstPixel + (y * output_bitmapData.Stride);
                    for (int x = borderWidth; x < widthInBytes - borderWidth; x = x + bytesPerPixel)
                    {
                        //r = 0; g = 0; b = 0;
                        //for (int i = -1 * borderWidth; i <= borderWidth; i++)
                        //    for (int j = -1 * borderWidth; j <= borderWidth; j++)
                        //    {
                        //        c = input.GetPixel(x + i, y + j);
                        //        //r += c.R / 25; g += c.G / 25; b += c.B / 25;
                        //        r += c.R * window[i + borderWidth, j + borderWidth];
                        //        g += c.G * window[i + borderWidth, j + borderWidth];
                        //        b += c.B * window[i + borderWidth, j + borderWidth];
                        //    }
                        int oldBlue = input_currentLine[x];
                        int oldGreen = input_currentLine[x + 1];
                        int oldRed = input_currentLine[x + 2];

                        // calculate new pixel value
                        output_currentLine[x] = (byte)oldBlue;
                        output_currentLine[x + 1] = (byte)oldGreen;
                        output_currentLine[x + 2] = (byte)oldRed;
                    }
                }
                inputBmp.UnlockBits(bitmapData);
                resultBmp.UnlockBits(output_bitmapData);
            }
            return resultBmp;
        }

        private static double[,] GenRandomWindow(int demension)
        {
            double[,] window = new double[demension, demension];
            int lastN = 0;
            int startN = 101;
            Random rnd = new Random();
            for (int i = 0; i < demension; i++)
                for (int j = 0; j < demension; j++)
                {
                    startN -= lastN;
                    lastN = rnd.Next(0, startN);
                    window[i, j] = ((double)lastN) / 100;
                }
            PrintWindow(window);
            return window;
        }

        private static void PrintWindow(double[,] window)
        {
            String result = "";
            String row = "";
            for (int i = 0; i < window.GetLength(0); i++)
            {
                for (int j = 0; j < window.GetLength(1); j++)
                {
                    row += window[i, j].ToString() + "\t";
                }
                result += row + "\n";
                row = String.Empty;
            }
            Console.Write(result);
            Console.ReadLine();
        }

        //Bitmap bmp2 = (Bitmap)pictureBox1.Image.Clone();
        //int x, y, r, g, f, b; Color c;
        //for (x = 0; x < bmp2.Height; ++x)
        //{
        //    for (y = 0; y < bmp2.Width; ++y)
        //    {
        //        c = bmp2.GetPixel(y, x);
        //        r = c.R;
        //        g = c.G;
        //        b = c.B;

        //        f = (r + g + b) / 3;

        //        //c = Color.FromArgb(255-r,255-g,255-b); //инверсия
        //        //c = Color.FromArgb(f, f, f); // чб
        //        c = Color.FromArgb(r, g, b);
        //        bmp2.SetPixel(y, x, c);
        //    }
        //}


        ////Bitmap bmp1 = (Bitmap)pictureBox1.Image.Clone();
        ////Bitmap bmp2 = new Bitmap(bmp1.Width,bmp1.Height);
        //Bitmap bmp2 = new Bitmap(100, 100);
        //int x, y, f; Color c;
        //double u = 0.1, v = 0.2, F = 100;
        //for (y = 0; y < bmp2.Height; ++y)
        //{
        //    for (x = 0; x < bmp2.Width; ++x)
        //    {
        //        f = 128 + Convert.ToInt32(F * Math.Cos(u * x + v * y));
        //        c = Color.FromArgb(f, f, f);
        //        bmp2.SetPixel(x, y, c);
        //    }
        //}


        //Random rnd = new Random();
        //Bitmap bmp2 = (Bitmap)pictureBox1.Image.Clone();
        //int x, y, r, g, f, b; Color c;
        //double D = 50, d;
        //for (x = 0; x < bmp2.Height; ++x)
        //{
        //    for (y = 0; y < bmp2.Width; ++y)
        //    {
        //        c = bmp2.GetPixel(y, x);
        //        r = c.R;
        //        g = c.G;
        //        b = c.B;

        //        f = (r + g + b) / 3;

        //        //c = Color.FromArgb(255-r,255-g,255-b); //инверсия
        //        //c = Color.FromArgb(f, f, f); // чб
        //        d = GaussRandom(rnd);
        //        //r += Convert.ToInt32(D*(rnd.NextDouble()-0.5));
        //        //g += Convert.ToInt32(D * (rnd.NextDouble() - 0.5));
        //        //b += Convert.ToInt32(D * (rnd.NextDouble() - 0.5));
        //        r += Convert.ToInt32(D * (d));
        //        g += Convert.ToInt32(D * (d));
        //        b += Convert.ToInt32(D * (d));
        //        if (r < 0)
        //            r = 0;
        //        else if (r > 255)
        //            r = 255;
        //        if (g < 0)
        //            g = 0;
        //        else if (g > 255)
        //            g = 255;
        //        if (b < 0)
        //            b = 0;
        //        else if (b > 255)
        //            b = 255;
        //        c = Color.FromArgb(r, g, b);
        //        bmp2.SetPixel(y, x, c);
        //    }
        //}

        private static double GaussRandom(Random rnd)
        {
            double sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += rnd.NextDouble();
            }
            return sum - 6;
        }
        private static int GaussRandomInt(Random rnd, int s, int f)
        {
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += rnd.Next(s, f);
            }
            return sum - f / 2;
        }

        //Random rnd = new Random();
        //Bitmap bmp2 = (Bitmap)pictureBox1.Image.Clone();
        //int x, y, r, g, f, b; Color c;
        //double D = 50, d;
        //int МосьСила = 8000;
        //int rndX, rndY, rndColor;
        //for (int n = 0; n < МосьСила; n++)
        //{
        //    rndX = rnd.Next(0, bmp2.Width);
        //    rndY = rnd.Next(0, bmp2.Height);
        //    rndColor = rnd.Next(0, 2);
        //    if (rndColor == 1)
        //        bmp2.SetPixel(rndX, rndY, Color.White);
        //    else
        //        bmp2.SetPixel(rndX, rndY, Color.Black);
        //}

        private static void ProcessUsingLockbitsAndUnsafe(Bitmap processedBitmap)
        {
            unsafe
            {
                BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        // calculate new pixel value
                        currentLine[x] = (byte)oldBlue;
                        currentLine[x + 1] = (byte)oldGreen;
                        currentLine[x + 2] = (byte)oldRed;
                    }
                }
                processedBitmap.UnlockBits(bitmapData);
            }
        }
    }
}
