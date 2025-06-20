using System.Drawing;
using System.Windows.Forms;

namespace MastermindGame
{
    public class GuessButton : Button
    {
        public bool IsClicked { get; set; }
        public int NumberOfRow { get; set; }

        public GuessButton(int i_NumberOfRow)
        {
            NumberOfRow = i_NumberOfRow;
            this.Enabled = false;
            this.Size = new Size(40, 40);
            this.Left = 10;
            this.Top = 70;
        }
    }
}