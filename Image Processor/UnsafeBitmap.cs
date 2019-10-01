using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processor
{
    public struct PixelData
    {
        public byte B;
        public byte G;
        public byte R;

    }
    public unsafe class UnsafeBitmap
    {
        Bitmap bitmap;

        // three elements used for MakeGreyUnsafe
        int width;
        BitmapData bitmapData = null;
        Byte* pBase = null;

        public UnsafeBitmap(Bitmap bitmap)
        {
            this.bitmap = new Bitmap(bitmap);
        }

        public UnsafeBitmap(int width, int height)
        {
            this.bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        }

        public void Dispose()
        {
            bitmap.Dispose();
        }

        public Bitmap Bitmap
        {
            get
            {
                return (bitmap);
            }
        }

        private Point PixelSize
        {
            get
            {
                GraphicsUnit unit = GraphicsUnit.Pixel;
                RectangleF bounds = bitmap.GetBounds(ref unit);

                return new Point((int)bounds.Width, (int)bounds.Height);
            }
        }

        public void LockBitmap()
        {
            GraphicsUnit unit = GraphicsUnit.Pixel;
            RectangleF boundsF = bitmap.GetBounds(ref unit);
            Rectangle bounds = new Rectangle((int)boundsF.X,
            (int)boundsF.Y,
            (int)boundsF.Width,
            (int)boundsF.Height);

            // Figure out the number of bytes in a row
            // This is rounded up to be a multiple of 4
            // bytes, since a scan line in an image must always be a multiple of 4 bytes
            // in length.
            width = (int)boundsF.Width * sizeof(PixelData);
            if (width % 4 != 0)
            {
                width = 4 * (width / 4 + 1);
            }
            bitmapData =
            bitmap.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            pBase = (Byte*)bitmapData.Scan0.ToPointer();
        }

        //public PixelData GetPixel(int x, int y)
        //{
        //    PixelData returnValue = x, y;
        //    return returnValue;
        //}

        public void SetPixel(int x, int y, PixelData colour)
        {
            PixelData* pixel = PixelAt(x, y);
            *pixel = colour;
        }

        public void UnlockBitmap()
        {
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            pBase = null;
        }
        public PixelData* PixelAt(int x, int y)
        {
            return (PixelData*)(pBase + y * width + x * sizeof(PixelData));
        }
    }
    /*struct Pixel : IEquatable<Pixel>
        {
            public byte Blue;
            public byte Green;
            public byte Red;
            public byte Alpha;

            public bool Equals(Pixel other)
            {
                return Red == other.Red && Green == other.Green && Blue == other.Blue && Alpha == other.Alpha;
            }
        }
        private Bitmap UnsafeCode(Bitmap bmp)
        {
            Bitmap one = bmp;

            unsafe
            {
                var oneBits = one.LockBits(new Rectangle(0, 0, one.Width, one.Height), ImageLockMode.ReadOnly, one.PixelFormat);

                int padding = oneBits.Stride - (one.Width * sizeof(Pixel));

                int width = one.Width;
                int height = one.Height;

                byte* ptr = (byte*)oneBits.Scan0;


                var pStart = (byte*)oneBits.Scan0;
                var pEnd = (byte*)(pStart + oneBits.Stride * oneBits.Height);

                while (pStart != pEnd)
                {
                    *pStart = 0; // R
                    *(pStart + 1) = 0; // G
                    *(pStart + 2) = 255; // B

                    pStart += 3;
                }
                one.UnlockBits(oneBits);
            }
            return bmp;
        }*/
}
