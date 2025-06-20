using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MastermindGame;

namespace MastermindGame
{
    public partial class GameForm : Form
    {
        private List<BlackButton> m_BlackButtons = new List<BlackButton>();
        private List<GuessRow> m_GuessesRows = new List<GuessRow>();
        private int m_NumberOfRows;
        private GameLogic m_GameLogic;

        public GameForm(int i_NumberOfRows)
        {
            m_GameLogic = new GameLogic();
            m_NumberOfRows = i_NumberOfRows;
            InitializeComponent();
            addBlackButtondToGameForm();
            addButtonsRowsToGameForm();
            addResultButtonsToGameForm();
            m_GameLogic.GenerateRandomSecretCodeForGame();
        }


        private void addBlackButtondToGameForm()
        {
            for (int i = 0; i < 4; i++)
            {
                BlackButton newblackButton = new BlackButton();
                m_BlackButtons.Add(newblackButton);

                if (i != 0)
                {
                    m_BlackButtons[i].Left = m_BlackButtons[i - 1].Left + m_BlackButtons[i - 1].Width + 5;
                }

                this.Controls.Add(m_BlackButtons[i]);
            }
        }


        private void addButtonsRowsToGameForm()
        {
            for (int i = 0; i < m_NumberOfRows; i++)
            {
                GuessRow newGuessRow = new GuessRow(i);
                m_GuessesRows.Add(newGuessRow);

                foreach (GuessButton guessButton in newGuessRow.GuessButtons)
                {
                    guessButton.Click += buttonGuess_Click;
                    if (i == 0)
                    {
                        guessButton.Enabled = true;
                    }

                    this.Controls.Add(guessButton);
                }

                newGuessRow.SubmitGuess.Click += submitGuessButton_Click;
                this.Controls.Add(newGuessRow.SubmitGuess);
            }
        }


        private void buttonGuess_Click(object sender, EventArgs e)
        {
            List<Color> usedColors = new List<Color>();

            usedColors = getUsedColorsInGuessRow(m_GuessesRows[(sender as GuessButton).NumberOfRow].GuessButtons, (sender as GuessButton));
            ColorsForm colorsForm = new ColorsForm((sender as GuessButton), usedColors);
            colorsForm.Left = this.Left - 150;
            colorsForm.Top = this.Top + (this.Height / 2) - (colorsForm.Height / 2);
            colorsForm.ShowDialog();
            if (m_GuessesRows[(sender as GuessButton).NumberOfRow].AreAllColorsInRowSelected())
            {
                m_GuessesRows[(sender as GuessButton).NumberOfRow].SubmitGuess.Enabled = true;
            }
        }

        private List<Color> getUsedColorsInGuessRow(List<GuessButton> i_GuessButtonsRow, GuessButton i_SelectedButton)
        {
            List<Color> usedColors = new List<Color>();

            for (int i = 0; i < i_GuessButtonsRow.Count; i++)
            {
                GuessButton currentButton = i_GuessButtonsRow[i];
                if (currentButton.IsClicked && currentButton != i_SelectedButton)
                {
                    usedColors.Add(currentButton.BackColor);
                }
            }

            return usedColors;
        }


        private void submitGuessButton_Click(object sender, EventArgs e)
        {
            Result result = new Result();
            List<Color> listColorGuess = new List<Color>();

            listColorGuess = getColorsInGuess((sender as SubmitButton).NumberofRow);
            result = m_GameLogic.EvaluateGuessAgainstSecretCode(listColorGuess);
            setFeedbackButtonsFromGuessResult(result, (sender as SubmitButton).NumberofRow);
            (sender as SubmitButton).Enabled = false;
            disableCurrentRow((sender as SubmitButton).NumberofRow);
            if (m_GameLogic.IsWinning)
            {
                exposeSecretCode();
            }
            else if (!enableNextRow((sender as SubmitButton).NumberofRow + 1))
            {
                exposeSecretCode();
            }
        }


        private void exposeSecretCode()
        {
            for (int i = 0; i < 4; i++)
            {
                m_BlackButtons[i].BackColor = m_GameLogic.SecretCode[i];
            }
        }


        private void disableCurrentRow(int i_NumberOfRow)
        {
            foreach (GuessButton button in m_GuessesRows[i_NumberOfRow].GuessButtons)
            {
                button.Enabled = false;
            }
        }


        private bool enableNextRow(int i_NumberNextRow)
        {
            bool isNextRowEnabled = true;

            if (i_NumberNextRow >= m_NumberOfRows)
            {
                isNextRowEnabled = false;
            }
            else
            {
                foreach (GuessButton button in m_GuessesRows[i_NumberNextRow].GuessButtons)
                {
                    button.Enabled = true;
                }

                isNextRowEnabled = true;
            }

            return isNextRowEnabled;
        }


        private void setFeedbackButtonsFromGuessResult(Result i_Result, int i_NumberOfRow)
        {
            for (int i = 0; i < i_Result.ExactHitsCount; i++)
            {
                m_GuessesRows[i_NumberOfRow].ResultButtons.SetResultColor(Color.Black, i);
            }

            for (int i = 0; i < i_Result.PartialHitsCount; i++)
            {
                m_GuessesRows[i_NumberOfRow].ResultButtons.SetResultColor(Color.Yellow, i + i_Result.ExactHitsCount);
            }
        }


        private List<Color> getColorsInGuess(int i_NumberOfRow)
        {
            List<Color> listColorGuess = new List<Color>();

            for (int i = 0; i < 4; i++)
            {
                listColorGuess.Add(m_GuessesRows[i_NumberOfRow].GuessButtons[i].BackColor);
            }

            return listColorGuess;
        }


        private void addResultButtonsToGameForm()
        {
            List<Button> buttonListResult;

            foreach (GuessRow row in m_GuessesRows)
            {
                buttonListResult = row.ResultButtons.ResultsButtons;
                foreach (Button button in buttonListResult)
                {
                    this.Controls.Add(button);
                }
            }
        }
    }
}