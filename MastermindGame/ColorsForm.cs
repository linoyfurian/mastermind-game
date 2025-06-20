using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MastermindGame;

namespace MastermindGame
{
    public partial class ColorsForm : Form
    {
        private GuessButton m_SourceButton;
        private List<Button> m_ColorButtonList = new List<Button>();
        private Color[] colors = new Color[]
        {
            Color.Yellow, Color.Orange, Color.IndianRed, Color.LightPink,
            Color.MediumPurple, Color.LightBlue, Color.MidnightBlue, Color.ForestGreen
        };

        public ColorsForm(GuessButton i_SourceButton, List<Color> i_UsedColors)
        {
            bool isUsedColor;

            InitializeComponent();
            m_SourceButton = i_SourceButton;

            for (int i = 0; i < 8; i++)
            {
                Button newButtonColor = new Button();
                isUsedColor = false;
                newButtonColor.BackColor = colors[i];
                newButtonColor.Size = new Size(40, 40);
                newButtonColor.Left = 10;
                newButtonColor.Top = 10;
                m_ColorButtonList.Add(newButtonColor);

                for (int j = 0; j < i_UsedColors.Count; j++)
                {
                    if (colors[i].Name == i_UsedColors[j].Name)
                    {
                        isUsedColor = true;
                        break;
                    }
                }

                if (isUsedColor)
                {
                    newButtonColor.Enabled = false;
                }
                else
                {
                    newButtonColor.Enabled = true;
                }

                if (i != 0 && i != 4)
                {
                    m_ColorButtonList[i].Left = m_ColorButtonList[i - 1].Left + m_ColorButtonList[i - 1].Width + 5;
                }

                if (i >= 4)
                {
                    m_ColorButtonList[i].Top = m_ColorButtonList[i].Top + m_ColorButtonList[i].Height + 5;
                }

                newButtonColor.Click += colorButton_Click;
                this.Controls.Add(newButtonColor);
            }
        }


        private void colorButton_Click(object sender, EventArgs e)
        {
            this.Close();
            m_SourceButton.BackColor = (sender as Button).BackColor;
            m_SourceButton.IsClicked = true;
        }
    }
}