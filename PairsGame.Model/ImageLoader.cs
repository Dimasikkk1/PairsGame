using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace PairsGame.Model
{
    public class ImageLoader
    {
        public Image[] LoadImages(string path)
        {
            string[] imagePathArray = Directory.GetFiles(path);

            List<Image> images = new List<Image>(imagePathArray.Length);

            foreach (var imagePath in imagePathArray)
            {
                images.Add(Image.FromFile(imagePath));
            }

            return images.ToArray();
        }
    }
}
