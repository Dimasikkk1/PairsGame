using System.Drawing;
using System.Windows.Forms;

namespace PairsGame.Controls
{
    public partial class Card : Button, ICard
    {
        private Image shirtImage;

        public Image ShirtImage
        {
            get => shirtImage;
            set
            {
                shirtImage = value;
                Image = value;
            }
        }
        public Image HiddenImage { get; set; }
        public new Image Image { get => BackgroundImage; set => BackgroundImage = value; }
        public bool IsOpenned
        {
            get => Image == HiddenImage;
            set => Image = value ? HiddenImage : ShirtImage;
        }

        public Card()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
            BackgroundImageLayout = ImageLayout.Zoom;

            SetStyle(ControlStyles.Selectable, false); // Это для скрытия синий рамки после клика по кнопке
        }
    }
}
