// References: https://www.tutorialsteacher.com/csharp/csharp-dictionary

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarianTrainingApp
{
    static class IdentifyingAreasClass
    {
        // Declaring variables
        private static Random random = new Random();
        public static Button selectedLeftButton;
        public static Button selectedRightButton;
        public static bool isLeftButtons;

        //------------------------------------------------------------------------------------------------------------------------//
        // Call numbers and their descriptions
        public static Dictionary<string, string> storedCallNumbers = new Dictionary<string, string>()
        {
            { "000", "General Knowledge" },
            { "100", "Philosophy And Psychology" },
            { "200", "Religion" },
            { "300", "Social Sciences" },
            { "400", "Languages" },
            { "500", "Science" },
            { "600", "Technology" },
            { "700", "Arts And Recreation" },
            { "800", "Literature" },
            { "900", "History And Geography" }
        };

        //------------------------------------------------------------------------------------------------------------------------//
        // Lines drawn on drawingboard
        public static Dictionary<string, float> drawingLine = new Dictionary<string, float>()
        {
            { "orchid", 0 },
            { "paleviolet", 0 },
            { "medviolet", 0 },
            { "cyan", 0 }
        };

        //------------------------------------------------------------------------------------------------------------------------//
        // y-axis coordinates
        public static List<float> yAxis = new List<float>()
        {
            22.0F,
            85.0F,
            150.0F,
            215.0F,
            282.0F,
            346.0F,
            415.0F
        };

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Preparing for the game
        /// </summary>
        /// <param name="leftButton"></param>
        /// <param name="leftButtonTotal"></param>
        /// <param name="rightButton"></param>
        /// <param name="rightButtonTotal"></param>
        public static void RandomlyGenerateCallNumber(Button[] leftButton, int leftButtonTotal, Button[] rightButton, int rightButtonTotal)
        {
            drawingLine["orchid"] = 0;
            drawingLine["paleviolet"] = 0;
            drawingLine["medviolet"] = 0;
            drawingLine["cyan"] = 0;

            isLeftButtons = false;
            ColorRightButton(rightButton, rightButtonTotal);

            if (random.Next(0, 2) == 0)
            {
                isLeftButtons = true;
            }

            ReadyButtons(leftButton, leftButtonTotal, rightButton, rightButtonTotal);
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Generating random questions and answers
        /// </summary>
        /// <param name="leftButton"></param>
        /// <param name="leftButtonTotal"></param>
        /// <param name="rightButton"></param>
        /// <param name="rightButtonTotal"></param>
        public static void ReadyButtons(Button[] leftButton, int leftButtonTotal, Button[] rightButton, int rightButtonTotal)
        {
            List<string> leftSide = new List<string>();
            List<string> rightSide = new List<string>();

            while (leftSide.Count < leftButtonTotal)
            {
                int a = random.Next(0, 10);
                string s;
                string sr;

                if (isLeftButtons)
                {
                    s = storedCallNumbers.ElementAt(a).Key;
                    sr = storedCallNumbers.ElementAt(a).Value;
                }
                else
                {
                    s = storedCallNumbers.ElementAt(a).Value;
                    sr = storedCallNumbers.ElementAt(a).Key;
                }

                if (!leftSide.Contains(s))
                {
                    leftSide.Add(s);
                    rightSide.Add(sr);
                }
            }

            while (rightSide.Count < rightButtonTotal)
            {
                int a = random.Next(0, 10);
                string sr;
                
                if (isLeftButtons)
                {
                    sr = storedCallNumbers.ElementAt(a).Value;
                }
                else
                {
                    sr = storedCallNumbers.ElementAt(a).Key;
                }

                if (!rightSide.Contains(sr))
                {
                    rightSide.Add(sr);
                }
            }

            for (int i = 0; i < leftButtonTotal; i++)
            {
                leftButton[i].Text = leftSide[i];
            }

            Mix(rightSide);

            for (int i = 0; i < rightButtonTotal; i++)
            {
                rightButton[i].Text = rightSide[i];
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Mixing the list randomly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Mix<T>(this IList<T> list)
        {
            int b = list.Count;
            while (b > 1)
            {
                b--;
                int c = random.Next(b + 1);
                T t = list[c];
                list[c] = list[b];
                list[b] = t;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Resetting the right side buttons
        /// </summary>
        /// <param name="rightButton"></param>
        /// <param name="rightButtonTotal"></param>
        public static void ColorRightButton(Button[] rightButton, int rightButtonTotal)
        {
            for (int i = 0; i < rightButtonTotal; i++)
            {
                rightButton[i].Text = (i + 1).ToString();
                rightButton[i].BackColor = Color.BurlyWood;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Left-button click event
        /// </summary>
        /// <param name="ready"></param>
        public static void LeftButtonClick(object ready)
        {
            if (ready != null)
            {
                if (selectedLeftButton != null)
                {
                    selectedLeftButton.FlatStyle = FlatStyle.Flat;
                    selectedLeftButton = null;
                }

                if (selectedLeftButton != (Button)ready)
                {
                    selectedLeftButton = (Button)ready;
                    selectedLeftButton.FlatStyle |= FlatStyle.Popup;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Right-button click event
        /// </summary>
        /// <param name="ready"></param>
        /// <param name="rightButtonTotal"></param>
        /// <param name="rightButton"></param>
        /// <param name="leftButton"></param>
        public static void RightButtonClick(object ready, int rightButtonTotal, Button[] rightButton, Button[] leftButton)
        {
            if (ready == null)
            {
                return;
            }

            if (selectedLeftButton == null)
            {
                return;
            }

            selectedRightButton = (Button)ready;
            MatchCheck(rightButtonTotal, rightButton);
            selectedRightButton.BackColor = selectedLeftButton.BackColor;
            selectedRightButton.ForeColor = selectedLeftButton.ForeColor;
            DrawLine(rightButtonTotal, rightButton);

            selectedLeftButton.FlatStyle = FlatStyle.Flat;
            selectedLeftButton = null;
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Drawing lines between selected left-buttons and right-buttons
        /// </summary>
        /// <param name="rightButtonTotal"></param>
        /// <param name="rightButton"></param>
        public static void DrawLine(int rightButtonTotal, Button[] rightButton)
        {
            if (selectedLeftButton.BackColor == Color.MediumOrchid)
            {
                for (int i = 0; i < rightButtonTotal; i++)
                {
                    if (rightButton[i].BackColor == Color.MediumOrchid)
                    {
                        drawingLine["orchid"] = yAxis[i];

                        if (drawingLine["paleviolet"] == drawingLine["orchid"])
                        {
                            drawingLine["paleviolet"] = 0;
                        }

                        if (drawingLine["medviolet"] == drawingLine["orchid"])
                        {
                            drawingLine["medviolet"] = 0;
                        }

                        if (drawingLine["cyan"] == drawingLine["orchid"])
                        {
                            drawingLine["cyan"] = 0;
                        }
                    }
                }
            }

            if (selectedLeftButton.BackColor == Color.PaleVioletRed)
            {
                for (int i = 0; i < rightButtonTotal; i++)
                {
                    if (rightButton[i].BackColor == Color.PaleVioletRed)
                    {
                        drawingLine["paleviolet"] = yAxis[i];

                        if (drawingLine["orchid"] == drawingLine["paleviolet"])
                        {
                            drawingLine["orchid"] = 0;
                        }

                        if (drawingLine["medviolet"] == drawingLine["paleviolet"])
                        {
                            drawingLine["medviolet"] = 0;
                        }

                        if (drawingLine["cyan"] == drawingLine["paleviolet"])
                        {
                            drawingLine["cyan"] = 0;
                        }
                    }
                }
            }

            if (selectedLeftButton.BackColor == Color.MediumVioletRed)
            {
                for (int i = 0; i < rightButtonTotal; i++)
                {
                    if (rightButton[i].BackColor == Color.MediumVioletRed)
                    {
                        drawingLine["medviolet"] = yAxis[i];

                        if (drawingLine["paleviolet"] == drawingLine["medviolet"])
                        {
                            drawingLine["paleviolet"] = 0;
                        }

                        if (drawingLine["orchid"] == drawingLine["medviolet"])
                        {
                            drawingLine["orchid"] = 0;
                        }

                        if (drawingLine["cyan"] == drawingLine["medviolet"])
                        {
                            drawingLine["cyan"] = 0;
                        }
                    }
                }
            }

            if (selectedLeftButton.BackColor == Color.DarkCyan)
            {
                for (int i = 0; i < rightButtonTotal; i++)
                {
                    if (rightButton[i].BackColor == Color.DarkCyan)
                    {
                        drawingLine["cyan"] = yAxis[i];

                        if (drawingLine["paleviolet"] == drawingLine["cyan"])
                        {
                            drawingLine["paleviolet"] = 0;
                        }

                        if (drawingLine["medviolet"] == drawingLine["cyan"])
                        {
                            drawingLine["medviolet"] = 0;
                        }

                        if (drawingLine["orchid"] == drawingLine["cyan"])
                        {
                            drawingLine["orchid"] = 0;
                        }
                    }
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Showing if the right-buttons have been matched with the left-buttons with colour
        /// </summary>
        /// <param name="rightButtonTotal"></param>
        /// <param name="rightButton"></param>
        public static void MatchCheck(int rightButtonTotal, Button[] rightButton)
        {
            for (int i = 0; i < rightButtonTotal; i++)
            {
                if (rightButton[i].BackColor == selectedLeftButton.BackColor)
                {
                    rightButton[i].BackColor = Color.BurlyWood;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Checking if the matching is correct
        /// </summary>
        /// <param name="leftButton"></param>
        /// <param name="leftButtonTotal"></param>
        /// <param name="rightButton"></param>
        /// <param name="rightButtonTotal"></param>
        /// <returns></returns>
        public static bool CheckMatch(Button[] leftButton, int leftButtonTotal, Button[] rightButton, int rightButtonTotal)
        {
            int matching = 0;

            for (int i = 0; i < leftButtonTotal; i++)
            {
                for (int j = 0; j < rightButtonTotal; j++)
                {
                    if (leftButton[i].BackColor == rightButton[j].BackColor)
                    {
                        matching++;

                        if (isLeftButtons)
                        {
                            if (rightButton[j].Text != storedCallNumbers[leftButton[i].Text])
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (leftButton[i].Text != storedCallNumbers[rightButton[j].Text])
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            if (matching != 4)
            {
                return false;
            }
            return true;
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Viewing the correct answer
        /// </summary>
        /// <param name="leftButtonTotal"></param>
        /// <param name="leftButton"></param>
        /// <param name="rightButtonTotal"></param>
        /// <param name="rightButton"></param>
        public static void ViewAnswer(int leftButtonTotal, Button[] leftButton, int rightButtonTotal, Button[] rightButton)
        {
            string answer = "";
            int j;

            if (isLeftButtons)
            {
                for (int i = 0; i < leftButtonTotal; i++)
                {
                    j = i + 1;
                    answer += j + ".  " + leftButton[i].Text;
                    answer += "  --->  " + storedCallNumbers[leftButton[i].Text];
                    answer += "\n";
                }
                MessageBox.Show(answer, "Answer", MessageBoxButtons.OK);
                return;
            }
            for (int i = 0; i < leftButtonTotal; i++)
            {
                j = i + 1;
                answer += j + ".  " + storedCallNumbers[rightButton[i].Text];
                answer += "  --->  " + rightButton[i].Text;
                answer += "\n";
            }
            MessageBox.Show(answer, "Answer", MessageBoxButtons.OK);
            return;
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//
