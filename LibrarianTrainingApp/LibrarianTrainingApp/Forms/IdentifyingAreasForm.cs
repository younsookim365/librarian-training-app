// References: https://www.youtube.com/watch?v=BtOEztT1Qzk&list=LL&index=1&t=1294s
//             https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-draw-a-line-on-a-windows-form?view=netframeworkdesktop-4.8
//             https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawline?view=windowsdesktop-7.0
//             https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-set-pen-width-and-alignment?view=netframeworkdesktop-4.8
//             https://mycolor.space/?hex=%23845EC2&sub=1

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibrarianTrainingApp.IdentifyingAreasClass;

namespace LibrarianTrainingApp
{
    public partial class IdentifyingAreasForm : Form
    {
        // Declaring variables
        private int seconds;
        private int GainedPoints = 100;
        private int LostPoints = -50;
        private int TimePoints = 300;
        private static int newRecord = 0;
        private static int nowPoints = 0;
        private Button[] leftButton;
        private Button[] rightButton;
        private int LeftButtonTotal = 4;
        private int RightButtonTotal = 7;

        //------------------------------------------------------------------------------------------------------------------------//
        public IdentifyingAreasForm()
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
            timer1.Start();
            userPointsLbl.Text = nowPoints.ToString();
            newRecordLbl.Text = newRecord.ToString();            

            leftButton = new Button[] { leftBtn1, leftBtn2, leftBtn3, leftBtn4 };
            rightButton = new Button[] { rightBtn1, rightBtn2, rightBtn3, rightBtn4, rightBtn5, rightBtn6, rightBtn7 };

            RandomlyGenerateCallNumber(leftButton, LeftButtonTotal, rightButton, RightButtonTotal);
            this.Refresh();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Closing the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IdentifyingAreasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Return to main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backBtn2_Click(object sender, EventArgs e)
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
        /// Button Click Events for Left Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftBtn1_Click(object sender, EventArgs e)
        {
            LeftButtonClick(sender);
        }

        private void leftBtn2_Click(object sender, EventArgs e)
        {
            LeftButtonClick(sender);
        }

        private void leftBtn3_Click(object sender, EventArgs e)
        {
            LeftButtonClick(sender);
        }

        private void leftBtn4_Click(object sender, EventArgs e)
        {
            LeftButtonClick(sender);
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Button Click Events for Right Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightBtn1_Click(object sender, EventArgs e)
        {
            RightButtonClick(sender, RightButtonTotal, rightButton, leftButton);
            this.Refresh();
        }

        private void rightBtn2_Click(object sender, EventArgs e)
        {
            RightButtonClick(sender, RightButtonTotal, rightButton, leftButton);
            this.Refresh();
        }

        private void rightBtn3_Click(object sender, EventArgs e)
        {
            RightButtonClick(sender, RightButtonTotal, rightButton, leftButton);
            this.Refresh();
        }

        private void rightBtn4_Click(object sender, EventArgs e)
        {
            RightButtonClick(sender, RightButtonTotal, rightButton, leftButton);
            this.Refresh();
        }

        private void rightBtn5_Click(object sender, EventArgs e)
        {
            RightButtonClick(sender, RightButtonTotal, rightButton, leftButton);
            this.Refresh();
        }

        private void rightBtn6_Click(object sender, EventArgs e)
        {
            RightButtonClick(sender, RightButtonTotal, rightButton, leftButton);
            this.Refresh();
        }

        private void rightBtn7_Click(object sender, EventArgs e)
        {
            RightButtonClick(sender, RightButtonTotal, rightButton, leftButton);
            this.Refresh();
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
        /// Checking if the matching is correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Check_Click(object sender, EventArgs e)
        {
            if (CheckMatch(leftButton, LeftButtonTotal, rightButton, RightButtonTotal))
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
                MessageBox.Show("Well done! The columns have been matched correctly! You scored: " + userPoints + " points!");

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
        /// Drawing lines on drawingboard with specified starting and ending x-axis coordinates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawingboard_Paint(object sender, PaintEventArgs e)
        {
            Pen orchidLine = new Pen(Color.Orchid, 4);
            Pen palevioletLine = new Pen(Color.PaleVioletRed, 4);
            Pen medvioletLine = new Pen(Color.MediumVioletRed, 4);
            Pen cyanLine = new Pen(Color.DarkCyan, 4);

            float x1 = 0.0F;
            float x2 = 220.0F;

            if (drawingLine["orchid"] != 0)
            {
                e.Graphics.DrawLine(orchidLine, x1, yAxis[0], x2, drawingLine["orchid"]);
            }
            
            if (drawingLine["paleviolet"] != 0)
            {
                e.Graphics.DrawLine(palevioletLine, x1, yAxis[1], x2, drawingLine["paleviolet"]);
            }

            if (drawingLine["medviolet"] != 0)
            {
                e.Graphics.DrawLine(medvioletLine, x1, yAxis[2], x2, drawingLine["medviolet"]);
            }

            if (drawingLine["cyan"] != 0)
            {
                e.Graphics.DrawLine(cyanLine, x1, yAxis[3], x2, drawingLine["cyan"]);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Viewing the correct answer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CorrectAnswer_Click(object sender, EventArgs e)
        {
            ViewAnswer(LeftButtonTotal, leftButton, RightButtonTotal, rightButton);
            BeginDeweyDecimalGame();
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//
