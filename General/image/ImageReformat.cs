using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using DataAccess;

namespace General
{
    public class ImageReformat
    {
        public void uploadImage(Stream imgStream, string _path)
        {
            
            System.Drawing.Image image = System.Drawing.Image.FromStream(imgStream);
            System.Drawing.Bitmap size = new Bitmap(resizing(image));
            MemoryStream memStream = new MemoryStream();
            imgStream.Dispose();
            size.Save(_path, ImageFormat.Jpeg);
            size.Dispose();
        }

        public Bitmap resizing(Image image)
        {
            int max_width = 700;
            int max_height = 650;
            int width;
            int height;
            double ratio = (double)image.Width / (double)image.Height;
            System.Drawing.Bitmap size = new Bitmap(image);

            if (image.Width > max_width && image.Height > max_height)
            {
                if (image.Width > image.Height)
                {
                    height = Convert.ToInt32(max_width / ratio);
                    Bitmap nsize = new Bitmap(image, new Size(max_width, height));
                    return nsize;
                }
                else
                {
                    width = Convert.ToInt32(max_height / ratio);
                    Bitmap nsize = new Bitmap(image, new Size(width, max_height));
                    return nsize;
                }
            }
            if (image.Width > max_width)
            {
                height = Convert.ToInt32(max_width / ratio);
                Bitmap nsize = new Bitmap(image, new Size(max_width, height));
                return nsize;
            }
            else
            {
                width = Convert.ToInt32(max_height / ratio);
                Bitmap nsize = new Bitmap(image, new Size(width, max_height));
                return nsize;
            }
        }
    }
}
