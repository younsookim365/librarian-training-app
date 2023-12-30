// References: https://www.youtube.com/watch?v=BtOEztT1Qzk&list=LL&index=1&t=1294s

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibrarianTrainingApp.FindingCallNumbersClass;

namespace LibrarianTrainingApp
{
    public partial class FindingCallNumbersForm : Form
    {
        // Declaring variables
        private Button[] answerButtons;
        private Label figureDescription;

        //------------------------------------------------------------------------------------------------------------------------//
        public FindingCallNumbersForm()
        {
            InitializeComponent();
            BeginDeweyDecimalGame();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Start/ Restart Game
        /// </summary>
        private void BeginDeweyDecimalGame()
        {
            seconds = 0;
            userPoints = 0;
            timeLbl.Text = seconds.ToString();
            newRecordLbl.Text = newRecord.ToString();
            userPointsLbl.Text = userPoints.ToString();
            answerButtons = new Button[] { answerBtn1, answerBtn2, answerBtn3, answerBtn4 };
            figureDescription = lblFigureDescription;
            AddRandomFirstLevel();
            AddNodes(answerButtons);
            DescriptionLabel(figureDescription);
            timer1.Start();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Closing the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindingCallNumbersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Return to main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backBtn3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            timeLbl.Text = seconds.ToString();

        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Button click events for possible answers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void answerBtn1_Click(object sender, EventArgs e)
        {
            if (ButtonClick(sender, answerButtons, userPointsLbl))
            {
                BeginDeweyDecimalGame();
            };
        }

        private void answerBtn2_Click(object sender, EventArgs e)
        {
            if (ButtonClick(sender, answerButtons, userPointsLbl))
            {
                BeginDeweyDecimalGame();
            };
        }

        private void answerBtn3_Click(object sender, EventArgs e)
        {
            if (ButtonClick(sender, answerButtons, userPointsLbl))
            {
                BeginDeweyDecimalGame();
            };
        }

        private void answerBtn4_Click(object sender, EventArgs e)
        {
            if (ButtonClick(sender, answerButtons, userPointsLbl))
            {
                BeginDeweyDecimalGame();
            };
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Restart the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            BeginDeweyDecimalGame();
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//