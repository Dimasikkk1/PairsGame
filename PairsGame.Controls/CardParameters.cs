namespace PairsGame.Controls
{
    public class CardParameters
    {
        public Card Card { get; }
        public int Row { get; }
        public int Column { get; }

        public CardParameters(Card card, int row, int column)
        {
            Card = card;
            Row = row;
            Column = column;
        }
    }
}
