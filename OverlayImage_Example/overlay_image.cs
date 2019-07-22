/// <remarks>
/// *****************************************************************
/// Snippet Title: Overlay Images
/// Code's author: Elektro
/// Date Modified: 30-April-2015
/// *****************************************************************
/// </remarks>
/// <summary>
/// Overlay an image over a background image.
/// </summary>
/// <param name="backImage">The background image.</param>
/// <param name="topImage">The topmost image.</param>
/// <param name="topPosX">An optional adjustment of the top image's "X" position.</param>
/// <param name="topPosY">An optional adjustment of the top image's "Y" position.</param>
/// <returns>The overlayed image.</returns>
/// <exception cref="ArgumentNullException">backImage or topImage</exception>
/// <exception cref="ArgumentException">Image bounds are greater than background image.;topImage</exception>

using System;
using System.Drawing;

namespace OverlayImage_Example
{
    class overlay_image
    {

        public Image OverlayImages(Image backImage, Image topImage, int topPosX = 0, int topPosY = 0)
        {

            if (backImage == null)
            {
                throw new ArgumentNullException(paramName: "backImage");

            }
            else if (topImage == null)
            {
                throw new ArgumentNullException(paramName: "topImage");

            }
            else if ((topImage.Width > backImage.Width) || (topImage.Height > backImage.Height))
            {
                throw new ArgumentException("Image bounds are greater than background image.", "topImage");

            }
            else
            {
                topPosX += Convert.ToInt32((backImage.Width / 2) - (topImage.Width / 2));
                topPosY += Convert.ToInt32((backImage.Height / 2) - (topImage.Height / 2));

                Bitmap bmp = new Bitmap(backImage.Width, backImage.Height);

                using (Graphics canvas = Graphics.FromImage(bmp))
                {
                    canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    canvas.DrawImage(image: backImage, destRect: new Rectangle(0, 0, bmp.Width, bmp.Height), srcRect: new Rectangle(0, 0, bmp.Width, bmp.Height), srcUnit: GraphicsUnit.Pixel);
                    canvas.DrawImage(image: topImage, destRect: new Rectangle(topPosX, topPosY, topImage.Width, topImage.Height), srcRect: new Rectangle(0, 0, topImage.Width, topImage.Height), srcUnit: GraphicsUnit.Pixel);

                    canvas.Save();
                }
                return bmp;
            }
        }

    }
}