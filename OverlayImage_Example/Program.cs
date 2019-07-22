using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace OverlayImage_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Source Image.
            string sourceimage_url = @" ";
            //Watermark Image.
            string watermarkimage_url = @" ";
            //Location to save image.
            string wheretosave_url = @" ";

            //Add Watermark to source image.
            try
            {
                using (Image source_image = Image.FromFile(sourceimage_url))
                using (Image watermark_image = Image.FromFile(watermarkimage_url))
                {
                    overlay_image images_Overlay = new overlay_image();
                    Image test = images_Overlay.OverlayImages(source_image, watermark_image, 5, 15);
               
                    string overlay_image = DateTime.Now.Month + ".jpg";

                    Directory.CreateDirectory(wheretosave_url);
                    string overlay_image_url = wheretosave_url + overlay_image;
                    test.Save(overlay_image_url, ImageFormat.Jpeg);               
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
           
        }
    }
}
