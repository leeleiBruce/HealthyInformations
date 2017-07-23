using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HealthyInformation.FrameWork.Extension
{
    public static class BitmapSourceExtension
    {
        public static Bitmap ToBitmap(this BitmapSource src)
        {
            if (src == null)
            {
                return null;
            }
            int width = src.PixelWidth;
            int height = src.PixelHeight;
            Bitmap result = new Bitmap(width, height);
            BitmapData bits = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int size = width * height * 4;
            byte[] argb = new byte[size];
            src.CopyPixels(argb, bits.Stride, 0);
            Marshal.Copy(argb, 0, bits.Scan0, size);
            return result;
        }
    }
}
