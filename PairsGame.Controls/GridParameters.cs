using System.Drawing;

namespace PairsGame.Controls
{
    public class GridParameters
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Image Shirt { get; set; }
        public Image[] Images { get; set; }

        public GridParameters(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
