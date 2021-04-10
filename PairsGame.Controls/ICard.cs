using System.Drawing;

namespace PairsGame.Controls
{
    interface ICard
    {
        bool IsOpenned { get; set; }
        Image Image { get; }
    }
}
