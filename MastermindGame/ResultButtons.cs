using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MastermindGame
{
    public class ResultButtons
    {
        public List<Button> ResultsButtons { get; set; } = new List<Button>();

        public ResultButtons(Point i_TopLeftLocation)
        {
            int row, col;

            for (int i = 0; i < 4; i++)
            {
                Button button = new Button();
                row = i / 2;
                col = i % 2;
                button.Size = new Size(15, 15);
                button.Location = new Point(i_TopLeftLocation.X + (col * 20), i_TopLeftLocation.Y + (row * 20));
                button.Enabled = false;
                ResultsButtons.Add(button);
            }
        }


        public void SetResultColor(Color i_Newcolor, int i_IndexOfButton)
        {
            ResultsButtons[i_IndexOfButton].BackColor = i_Newcolor;
        }
    }
}