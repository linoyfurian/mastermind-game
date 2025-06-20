namespace MastermindGame
{
    public class Program
    {
        public static void Main()
        {
            StartForm form = new StartForm();

            form.ShowDialog();
            if (form.ClosedByStart)
            {
                GameForm boolPgia = new GameForm(form.NumberOfChances);
                boolPgia.ShowDialog();
            }
        }
    }
}