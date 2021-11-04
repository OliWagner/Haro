using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Windows;


namespace HARO.Helpers
{
    public static class ImageHelper
	  {
	    public static void ResizeImage(string sourceFileName, string destFileName, int newWidth)
	    {
	      using (Image image = Image.FromFile(sourceFileName))
	      using(Image thumbImage = ResizeImage(image, newWidth))
	      {
	        thumbImage.Save(destFileName);
	      }
	    }

	    public static Image ResizeImage(Image image, int newWidth)
	    {
	      int width = newWidth;
	      int height = newWidth;
	
	      double factor = image.Width / (double)image.Height;
	 
	      if (factor > 1)
	        height = (int) (height / factor); // Querformat
	      else
	        width = (int) (width* factor); // Hochformat
	 
	      return image.GetThumbnailImage(width, height, null, IntPtr.Zero);
	    }
	  }
}