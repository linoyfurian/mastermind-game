using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using MastermindGame;

namespace MastermindGame
{
    public class GuessRow
    {
        private const int m_SizeOfSpace = 5;
        private int m_NumberOfRow;
        public ResultButtons ResultButtons { get; set; }
        public List<GuessButton> GuessButtons { get; set; } = new List<GuessButton>();
        public Button SubmitGuess { get; set; }

        public GuessRow(int i_NumberOfRow)
        {
            m_NumberOfRow = i_NumberOfRow;
            initGuessButtons(i_NumberOfRow);
            SubmitGuess = new SubmitButton(i_NumberOfRow);
            SubmitGuess.Left = GuessButtons[3].Left + GuessButtons[3].Width + m_SizeOfSpace;
            SubmitGuess.Top = GuessButtons[3].Top + (GuessButtons[3].Width / 2) - (SubmitGuess.Height / 2);
            ResultButtons = new ResultButtons(new Point(SubmitGuess.Left + SubmitGuess.Width + 10, GuessButtons[3].Top + 5));
        }


        private void initGuessButtons(int i_RowNumber)
        {
            for (int i = 0; i < 4; i++)
            {
                GuessButton newGuessButton = new GuessButton(i_RowNumber);

                GuessButtons.Add(newGuessButton);
                if (i != 0)
                {
                    GuessButtons[i].Left = GuessButtons[i - 1].Left + GuessButtons[i - 1].Width + m_SizeOfSpace;
                }

                GuessButtons[i].Top = GuessButtons[i].Top + (GuessButtons[i].Height + m_SizeOfSpace) * i_RowNumber;
            }
        }


        public bool AreAllColorsInRowSelected()
        {
            bool IsAllSelected = true;

            foreach (GuessButton button in GuessButtons)
            {
                if (!button.IsClicked)
                {
                    IsAllSelected = false;
                    break;
                }
            }

            return IsAllSelected;
        }
    }
}