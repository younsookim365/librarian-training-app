// References: https://www.youtube.com/watch?v=DMgllqg9y8A&list=LL&index=1

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibrarianTrainingApp.ReplacingBooksClass;

namespace LibrarianTrainingApp
{
    public partial class ReplacingBooksForm : Form
    {
        // Declaring variables
        private int CallNumberRange = 10;
        private List<string> callNumber = new List<string>();
        private Button[] sortedButton;
        private Button[] randomButton;
        private int seconds;
        private int GainedPoints = 100;
        private int LostPoints = -50;
        private int TimePoints = 300;
        private static int newRecord = 0;
        private static int nowPoints = 0;

        //------------------------------------------------------------------------------------------------------------------------//
        public ReplacingBooksForm()
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
            timeLbl.Text = seconds.ToString();
            newRecordLbl.Text = newRecord.ToString();

            callNumber = RandomlyGenerateCallNumber(CallNumberRange);

            sortedButton = new Button[] { sortedBtn1, sortedBtn2, sortedBtn3, sortedBtn4, sortedBtn5, sortedBtn6, sortedBtn7, sortedBtn8, sortedBtn9, sortedBtn10 };
            randomButton = new Button[] {randomBtn1, randomBtn2, randomBtn3, randomBtn4, randomBtn5, randomBtn6, randomBtn7, randomBtn8, randomBtn9, randomBtn10};
            
            readyRandomButton(randomButton, callNumber, CallNumberRange);
            readySortedButton(sortedButton, CallNumberRange);

            QuickSort(callNumber, 0, callNumber.Count - 1);
            userPointsLbl.Text = nowPoints.ToString();
            timer1.Start();

        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Button Click Events for Sorted Books
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortedBtn1_Click(object sender, EventArgs e)
        {
            SortedButtonClick(sender, CallNumberRange, sortedButton, randomButton);
        }

        private void sortedBtn2_Click(object sender, EventArgs e)
        {
            SortedButtonClick(sender, CallNumberRange, sortedButton, randomButton);
        }

        private void sortedBtn3_Click(object sender, EventArgs e)
        {
            SortedButtonClick(sender, CallNumberRange, sortedButton, randomButton);
        }

        private void sortedBtn4_Click(object sender, EventArgs e)
        {
            SortedButtonClick(sender, CallNumberRange, sortedButton, randomButton);
        }

        private void sortedBtn5_Click(object sender, EventArgs e)
        {
            SortedButtonClick(sender, CallNumberRange, sortedButton, randomButton);
        }

        private void sortedBtn6_Click(object sender, EventArgs e)
        {
            SortedButtonClick(sender, CallNumberRange, sortedButton, randomButton);
        }

        private void sortedBtn7_Click(object sender, EventArgs e)
        {
            SortedButtonClick(sender, CallNumberRange, sortedButton, randomButton);
        }

        private void sortedBtn8_Click(object sender, EventArgs e)
        {
            SortedButtonClick(sender, CallNumberRange, sortedButton, randomButton);
        }

        private void sortedBtn9_Click(object sender, EventArgs e)
        {
            SortedButtonClick(sender, CallNumberRange, sortedButton, randomButton);
        }

        private void sortedBtn10_Click(object sender, EventArgs e)
        {
            SortedButtonClick(sender, CallNumberRange, sortedButton, randomButton);
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Button Click Events for Random Books
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void randomBtn1_Click(object sender, EventArgs e)
        {
            RandomNumberClick(sender);
        }

        private void randomBtn2_Click(object sender, EventArgs e)
        {
            RandomNumberClick(sender);
        }

        private void randomBtn3_Click(object sender, EventArgs e)
        {
            RandomNumberClick(sender);
        }

        private void randomBtn4_Click(object sender, EventArgs e)
        {
            RandomNumberClick(sender);
        }

        private void randomBtn5_Click(object sender, EventArgs e)
        {
            RandomNumberClick(sender);
        }

        private void randomBtn6_Click(object sender, EventArgs e)
        {
            RandomNumberClick(sender);
        }

        private void randomBtn7_Click(object sender, EventArgs e)
        {
            RandomNumberClick(sender);
        }

        private void randomBtn8_Click(object sender, EventArgs e)
        {
            RandomNumberClick(sender);
        }

        private void randomBtn9_Click(object sender, EventArgs e)
        {
            RandomNumberClick(sender);
        }

        private void randomBtn10_Click(object sender, EventArgs e)
        {
            RandomNumberClick(sender);
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Closing the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplacingBooksForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Restart the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Restart_Click(object sender, EventArgs e)
        {
            BeginDeweyDecimalGame();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Viewing the correct order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CorrectOrder_Click(object sender, EventArgs e)
        {
            string correctOrder = "";
            int j;
            for (int i = 0; i < CallNumberRange + 1; i++)
            {
                j = i + 1;
                if (i == CallNumberRange - 1)
                {
                    correctOrder += j + ".\t" + callNumber[i];
                    break;
                }
                correctOrder += j + ".\t" + callNumber[i] + "\n";
            }
            MessageBox.Show(correctOrder, "Correct Order", MessageBoxButtons.OK);
            BeginDeweyDecimalGame();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Checking if the sorted order is correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Check_Click(object sender, EventArgs e)
        {
            if (checkSortedOutput(CallNumberRange, sortedButton, callNumber))
            {
                timer1.Stop();
                if (seconds == 0)
                {
                    seconds = 1;
                }

                // Calculate points obtained
                int userPoints = GainedPoints + (TimePoints / seconds);
                
                // Check if it is a new record
                if (userPoints > newRecord)
                {
                    newRecord = userPoints;
                }

                // Average Points
                nowPoints += userPoints;
                userPointsLbl.Text = nowPoints.ToString();

                // Message for user
                MessageBox.Show("Well done! The books have been ordered correctly! You scored: " + userPoints + " points!");

                // Restart Dewey Decimal Game
                BeginDeweyDecimalGame();
            }
            else
            {
                // Deduct points
                nowPoints += LostPoints;
                userPointsLbl.Text = nowPoints.ToString();

                // Message for user
                MessageBox.Show("Incorrect! You scored: " + LostPoints + " points!");
                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Click(object sender, EventArgs e)
        {
            seconds++;
            timeLbl.Text = seconds.ToString();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Return to main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//