using System.Drawing;
using System.Windows.Forms;

namespace MastermindGame
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.m_ButtonStart = new System.Windows.Forms.Button();
            this.m_ButtonNumberOfChances = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_ButtonStart
            // 
            this.m_ButtonStart.Location = new System.Drawing.Point(178, 97);
            this.m_ButtonStart.Name = "m_ButtonStart";
            this.m_ButtonStart.Size = new System.Drawing.Size(92, 21);
            this.m_ButtonStart.TabIndex = 1;
            this.m_ButtonStart.Text = "Start";
            // 
            // m_ButtonNumberOfChances
            // 
            this.m_ButtonNumberOfChances.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_ButtonNumberOfChances.Location = new System.Drawing.Point(18, 20);
            this.m_ButtonNumberOfChances.Name = "m_ButtonNumberOfChances";
            this.m_ButtonNumberOfChances.Size = new System.Drawing.Size(250, 20);
            this.m_ButtonNumberOfChances.TabIndex = 0;
            this.m_ButtonNumberOfChances.Text = "Number of chances: 4";
            // 
            // StartForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 130);
            this.Controls.Add(this.m_ButtonNumberOfChances);
            this.Controls.Add(this.m_ButtonStart);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bool Pgia";
            this.ResumeLayout(false);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            m_ButtonNumberOfChances.Click += m_ButtonNumberOfChances_Click;
            m_ButtonStart.Click += m_ButtonStart_Click;
        }
    }
}