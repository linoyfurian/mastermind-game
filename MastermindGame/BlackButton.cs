using System.Drawing;
using System.Windows.Forms;

namespace MastermindGame
{
    public class BlackButton : Button
    {
        public BlackButton()
        {
            this.Enabled = false;
            this.BackColor = Color.Black;
            this.Size = new Size(40, 40);
            this.Left = 10;
            this.Top = 10;
        }
    }
}