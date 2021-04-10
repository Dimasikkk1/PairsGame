using PairsGame.Controls;
using PairsGame.Model;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PairsGame
{
    public partial class MainForm : Form
    {
        private GridParameters gridParameters;

        public MainForm()
        {
            InitializeComponent();

            gridParameters = new GridParameters(6, 4)
            {
                Shirt = Image.FromFile(Path.Combine(Application.StartupPath, "Resources\\Shirt.png")),
                Images = new ImageLoader().LoadImages(Path.Combine(Application.StartupPath, "Resources\\Images"))
            };

            mainTableControl.EndGame += MainTableControl_EndGame;

            mainTableControl.GridParameters = gridParameters;
            mainTableControl.SetCards(new PairsGenerator().GenerateCards(gridParameters));
        }

        private void MainTableControl_EndGame(object sender, EventArgs e)
        {
            MessageBox.Show($"Вы победили! Ваш счёт: {mainTableControl.Score}");
        }
    }
}
