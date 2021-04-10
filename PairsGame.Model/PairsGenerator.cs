using PairsGame.Controls;
using System;
using System.Drawing;
using System.Linq;

namespace PairsGame.Model
{
    public class PairsGenerator
    {
        public CardParameters[] GenerateCards(GridParameters gridParameters)
        {
            int width = gridParameters.Width;
            int height = gridParameters.Height;

            if (width * height % 2 == 1)
                throw new ArgumentException("Количество ячеек должно быть чётным.");

            Image shirt = gridParameters.Shirt;
            Image[] images = gridParameters.Images;

            var cardParameters = new CardParameters[height, width];
            var random = new Random();

            int cardCounter = 0;

            while (cardCounter < width * height)
            {
                var hiddenImageForPair = images[random.Next(0, images.Length)];

                int pairsCounter = 0;

                do
                {
                    int column = random.Next(0, width);
                    int row = random.Next(0, height);

                    if (cardParameters[row, column] == null)
                    {
                        cardParameters[row, column] = new CardParameters(new Card()
                        {
                            ShirtImage = shirt,
                            HiddenImage = hiddenImageForPair
                        }, row, column);

                        ++pairsCounter;
                        ++cardCounter;
                    }
                } while (pairsCounter < 2);
            }

            return cardParameters.Cast<CardParameters>().ToArray();
        }
    }
}
