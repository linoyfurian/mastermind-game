using System;
using System.Windows.Forms;

namespace MastermindGame
{
    public partial class StartForm : Form
    {
        private Button m_ButtonStart;
        private Button m_ButtonNumberOfChances;
        public bool ClosedByStart { get; set; } = false;
        public int NumberOfChances { get; set; } = 4;

        public StartForm()
        {
            InitializeComponent();
        }


        private void m_ButtonNumberOfChances_Click(object sender, EventArgs e)
        {
            NumberOfChances++;
            if (NumberOfChances == 11)
            {
                NumberOfChances = 4;
            }

            (sender as Button).Text = $"Number of chances: {NumberOfChances}";
        }


        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            this.Close();
            ClosedByStart = true;
        }
    }
}