using System;
using System.Collections.Generic;
using System.Drawing;
using MastermindGame;

namespace MastermindGame
{
    public class GameLogic
    {
        private Color[] m_ValidColorsForSecretCode = new Color[]
        {
            Color.Yellow, Color.Orange, Color.IndianRed, Color.LightPink,
            Color.MediumPurple, Color.LightBlue, Color.MidnightBlue, Color.ForestGreen
        };
        private const int k_SecretCodeLength = 4;
        private static readonly Random sr_Random = new Random();
        public List<Color> SecretCode { get; set; } = new List<Color>();
        public bool IsWinning { get; set; }


        public void GenerateRandomSecretCodeForGame()
        {
            int randomNumber;
            List<Color> availableColors = new List<Color>(m_ValidColorsForSecretCode);

            for (int i = 0; i < k_SecretCodeLength; i++)
            {
                randomNumber = sr_Random.Next(availableColors.Count);
                SecretCode.Add(availableColors[randomNumber]);
                availableColors.RemoveAt(randomNumber);
            }
        }


        public Result EvaluateGuessAgainstSecretCode(List<Color> i_CurrentGuess)
        {
            int exactMatchesCount = 0, partialMatchesCount = 0;
            Result result = new Result();

            for (int i = 0; i < k_SecretCodeLength; i++)
            {
                for (int j = 0; j < k_SecretCodeLength; j++)
                {
                    if (i_CurrentGuess[i] == SecretCode[j])
                    {
                        if (i == j)
                        {
                            exactMatchesCount++;
                        }
                        else
                        {
                            partialMatchesCount++;
                        }

                        break;
                    }
                }
            }

            if (exactMatchesCount == 4)
            {
                IsWinning = true;
            }

            result.PartialHitsCount = partialMatchesCount;
            result.ExactHitsCount = exactMatchesCount;

            return result;
        }
    }
}