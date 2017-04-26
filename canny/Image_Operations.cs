using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


namespace canny
{
    class Image_Operations
    {
        private static int newWidth = 64; //srcImage.Width;//
        private static int newHeight = 48; //srcImage.Height;//

        public static double[] OpenImage_Resized(string ImagePath)
        {
            // Open the img
            Bitmap srcImage = new Bitmap(ImagePath);

            // Resize it
            Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                gr.Dispose();
            }

            Bitmap original_bm = newImage;

            // Then Normalize the resized one
            double[,] normalizedimage = FillNormalizedArray(original_bm);

            // Convert the img from 2D to 1D
            return TwoDtoOneD(normalizedimage);
        }

        public static Bitmap OpenImage_ResizedImage(string ImagePath)
        {
            // Open the img
            Bitmap srcImage = new Bitmap(ImagePath);

            // Resize it
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                gr.Dispose();
            }

            Bitmap original_bm = newImage;

            return original_bm;
        }

        private static Bitmap Matrix_to_Image(double[] input)
        {

            // Copy into bitmap
            Bitmap bitmap;
            unsafe
            {
                fixed (double* intPtr = &input[0])
                {
                    bitmap = new Bitmap(newWidth, newHeight, newWidth, PixelFormat.Format32bppRgb, new IntPtr(intPtr));
                }
            }
            return bitmap;
        }

        private static double[,] FillNormalizedArray(Bitmap original_bm)
        {
            double[,] NormalizedRGBimage = new double[original_bm.Width, original_bm.Height];

            for (int x = 0; x < original_bm.Width; x++)
            {
                for (int y = 0; y < original_bm.Height; y++)
                {
                    Color clr = original_bm.GetPixel(x, y);
                    int red = clr.R;
                    int green = clr.G;
                    int blue = clr.B;
                    int pixel = (int)NormalizePixel(red, green, blue);
                    NormalizedRGBimage[x, y] = CalculateNormalizedRGB(pixel);
                }
            }
            return NormalizedRGBimage;
        }

        private static double CalculateNormalizedRGB(int pixel)
        {
            int alpha = (pixel >> 24) & 0xff;
            int red = (pixel >> 16) & 0xff;
            int green = (pixel >> 8) & 0xff;
            int blue = (pixel) & 0xff;
            return NormalizePixel(red, green, blue);
        }

        private static double NormalizePixel(int red, int green, int blue)
        {
            int normalized;
            float temp = (red + green + blue) / 3;
            normalized = (int)Math.Round(temp);
            return temp;
        }

        private static double[] TwoDtoOneD(double[,] twoD)
        {
            double[] temp = new double[twoD.GetLength(1) * twoD.GetLength(0)];
            int k = 0;
            for (int i = 0; i < twoD.GetLength(0); i++)
            {
                for (int j = 0; j < twoD.GetLength(1); j++)
                {
                    temp[k] = twoD[i, j];
                    k++;

                }
            }

            // Normalize Features
            double MaxFeature, MeanFeature;
            MaxFeature = temp.Max();
            MeanFeature = temp.Sum() / temp.Count();
            for (int i = 0; i < temp.Count(); i++)
                temp[i] = (temp[i] - MeanFeature) / (MaxFeature);

            return temp;
        }
        
    }
}
