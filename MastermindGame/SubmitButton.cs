using System.Drawing;
using System.Windows.Forms;

namespace MastermindGame
{
    public class SubmitButton : Button
    {
        public int NumberofRow { get; set; }

        public SubmitButton(int i_NumberOfRow)
        {
            NumberofRow = i_NumberOfRow;
            this.Text = "-->>";
            this.Enabled = false;
            this.Size = new Size(40, 20);
        }
    }
}