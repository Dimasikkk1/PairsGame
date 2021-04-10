using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PairsGame.Controls
{
    public partial class TableControl : UserControl
    {
        private GridParameters gridParameters;
        private ICard previewSelectedCard;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Bindable(false)]
        [Browsable(false)]
        public GridParameters GridParameters
        {
            get => gridParameters;
            set
            {
                gridParameters = value;

                SetGridSize(value.Width, value.Height);
            }
        }

        public int ShowingDelay { get; set; } = 500;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Bindable(false)]
        [Browsable(false)]
        public int Score { get; private set; }

        public TableControl() => InitializeComponent();

        public void Clear() => mainTableLayoutPanel.Controls.Clear();

        public void SetCard(CardParameters cardParameter) => mainTableLayoutPanel.Controls.Add(cardParameter.Card, cardParameter.Column, cardParameter.Row);

        public void SetCards(CardParameters[] cardParameters)
        {
            foreach (var cardParameter in cardParameters)
            {
                cardParameter.Card.Click += SelectCard;

                SetCard(cardParameter);
            }
        }

        private void SetGridSize(int width, int height)
        {
            mainTableLayoutPanel.RowCount = height;
            mainTableLayoutPanel.RowStyles.Clear();

            for (int i = 0; i < height; i++)
            {
                mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            }

            mainTableLayoutPanel.ColumnCount = width;
            mainTableLayoutPanel.ColumnStyles.Clear();

            for (int i = 0; i < width; i++)
            {
                mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            }
        }

        private async void SelectCard(object sender, EventArgs args)
        {
            var card = (ICard)sender;

            card.IsOpenned = true;

            if (previewSelectedCard == null)
            {
                previewSelectedCard = card;

                return;
            }

            if (card != previewSelectedCard)
            {
                // Задежка после открытия двух карточек
                mainTableLayoutPanel.Enabled = false;

                await Task.Delay(ShowingDelay);

                mainTableLayoutPanel.Enabled = true;
                // Конец задержки

                if (card.Image == previewSelectedCard.Image)
                {
                    RemoveCard(card);
                    RemoveCard(previewSelectedCard);
                }
                else
                    card.IsOpenned = previewSelectedCard.IsOpenned = false;
            }
            else
                card.IsOpenned = false;

            previewSelectedCard = null;
        }

        private void RemoveCard(ICard card)
        {
            var control = (Card)card;

            control.Click -= SelectCard;

            mainTableLayoutPanel.Controls.Remove(control);

            ++Score;

            if (mainTableLayoutPanel.Controls.Count == 0)
                EndGame?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler EndGame;
    }
}
