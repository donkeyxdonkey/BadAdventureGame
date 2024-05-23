using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Assignment7_V2
{
    public static class HelperMethods
    {
        /// <summary>return a nullable int from a string</summary>
        /// <param name="s">input string</param>
        public static int? ToNullableInt(string s)
        {
            int i;
            if (int.TryParse(s, out i))
                if (i > 0) return i;
            return null;
        }

        /// <summary>Loads an image to a picturebox after nulling it first</summary>
        /// <param name="pb"></param>
        /// <param name="newImage"></param>
        /// <returns></returns>
        public static Image ReloadImage(PictureBox pb, Image newImage)
        {
            if (pb.Image != null)
                pb.Image = null;

            return newImage;
        }

        /// <summary>Replaces underscore with space in any enum</summary>
        /// <param name="sEnum">input string</param>
        public static string ReplaceUnderscoreToString<T>(T tEnum) where T : Enum
        {
            string sEnum = $"{tEnum}";
            if (sEnum.Contains("_")) sEnum = sEnum.Replace("_", " ");
            return sEnum;
        }
        // i've selected C# 7.3 for "where T : Enum" to work

        //borrowed from, used 1 time at startup, https://stackoverflow.com/questions/4779027/changing-the-opacity-of-a-bitmap-image
        //only used for menuopening
        private const int bytesPerPixel = 4;

        /// <summary>
        /// Change the opacity of an image
        /// </summary>
        /// <param name="originalImage">The original image</param>
        /// <param name="opacity">Opacity, where 1.0 is no opacity, 0.0 is full transparency</param>
        /// <returns>The changed image</returns>
        public static Image ChangeImageOpacity(Image originalImage, double opacity)
        {
            if ((originalImage.PixelFormat & PixelFormat.Indexed) == PixelFormat.Indexed)
            {
                // Cannot modify an image with indexed colors
                return originalImage;
            }

            Bitmap bmp = (Bitmap)originalImage.Clone();

            // Specify a pixel format.
            PixelFormat pxf = PixelFormat.Format32bppArgb;

            // Lock the bitmap's bits.
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, pxf);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            // This code is specific to a bitmap with 32 bits per pixels 
            // (32 bits = 4 bytes, 3 for RGB and 1 byte for alpha).
            int numBytes = bmp.Width * bmp.Height * bytesPerPixel;
            byte[] argbValues = new byte[numBytes];

            // Copy the ARGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, argbValues, 0, numBytes);

            // Manipulate the bitmap, such as changing the
            // RGB values for all pixels in the the bitmap.
            for (int counter = 0; counter < argbValues.Length; counter += bytesPerPixel)
            {
                // argbValues is in format BGRA (Blue, Green, Red, Alpha)

                // If 100% transparent, skip pixel
                if (argbValues[counter + bytesPerPixel - 1] == 0)
                    continue;

                int pos = 0;
                pos++; // B value
                pos++; // G value
                pos++; // R value

                argbValues[counter + pos] = (byte)(argbValues[counter + pos] * opacity);
            }

            // Copy the ARGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(argbValues, 0, ptr, numBytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            return bmp;
        }
    }
}
