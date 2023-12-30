// References:https://www.geeksforgeeks.org/quick-sort/
//            https://www.csharpstar.com/csharp-program-quick-sort/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LibrarianTrainingApp
{
    class ReplacingBooksClass
    {
        // Declaring variables
        private static Random random = new Random();
        public static Button nowRandomButton;
        public static Button nowSortedButton;

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Randomly generating different call numbers
        /// </summary>
        /// <param name="callNumberRange"></param>
        /// <returns></returns>
        public static List<string> RandomlyGenerateCallNumber(int callNumberRange)
        {
            List<string> callNumber = new List<string>();
            callNumber.Clear();

            for (int i = 0; i < callNumberRange; i++)
            {
                var buildCallNumber = new StringBuilder();
                buildCallNumber.Append(RandomNumber(3));

                if (Int32.Parse(RandomNumber(1)) > 5)
                {
                    buildCallNumber.Append(".");
                    buildCallNumber.Append(random.Next(0, 999));
                }

                buildCallNumber.Append(" ");
                buildCallNumber.Append(RandomString(3));
                callNumber.Add(buildCallNumber.ToString());
            }
            return callNumber;

        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Quick Sort using recursion
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        static int Partition(List<string> arr, int left, int right)
        {
            int pivot = right;
            int i = left, j = right;
            string temp;
            while (i < j)
            {
                while (i < right && string.Compare(arr[i], arr[pivot]) < 0) i++;
                while (j > left && string.Compare(arr[j], arr[pivot]) > 0) j--;

                if (i < j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            temp = arr[pivot];
            arr[pivot] = arr[j];
            arr[j] = temp;
            return j;
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Quick Sort
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QuickSort(List<string> arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);
                QuickSort(arr, left, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, right);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//    
        /// <summary>
        /// Get unsorted random number buttons ready for user to sort
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="callNumberRange"></param>
        public static void readySortedButton(Button[] btn, int callNumberRange)
        {
            for (int i = 0; i < callNumberRange; i++)
            {
                btn[i].Text = (i + 1).ToString();
                btn[i].BackColor = Color.FromArgb(192, 255, 255);
                btn[i].ForeColor = Color.FromArgb(255, 192, 128);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Get unsorted random number buttons ready for user to sort
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="callNumber"></param>
        /// <param name="callNumberRange"></param>
        public static void readyRandomButton(Button[] btn, List<string> callNumber, int callNumberRange)
        {
            for (int i = 0; i < callNumberRange; i++)
            {
                btn[i].Text = callNumber[i];
                btn[i].BackColor = Color.FromArgb(255, 255, 192);
                btn[i].ForeColor = Color.FromArgb(128, 128, 255);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Generating random number
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string RandomNumber(int a)
        {
            const string cs = "0123456789";
            return new string(Enumerable.Repeat(cs, a).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Generating random string
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string RandomString(int a)
        {
            const string cs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(cs, a).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// User input
        /// </summary>
        /// <param name="user"></param>
        public static void RandomNumberClick(object user)
        {
            if (user != null)
            {
                if (nowRandomButton != null)
                {
                    nowRandomButton.BackColor = Color.FromArgb(255, 255, 192);
                    nowRandomButton.ForeColor = Color.FromArgb(128, 128, 255);
                    nowRandomButton = null;
                }

                if (nowRandomButton != (Button)user)
                {
                    nowRandomButton = (Button)user;
                    nowRandomButton.BackColor = Color.FromArgb(255, 128, 0);
                }
            }
            
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// User input
        /// </summary>
        /// <param name="user"></param>
        /// <param name="callNumberRange"></param>
        /// <param name="sortedButton"></param>
        /// <param name="randomButton"></param>
        public static void SortedButtonClick(object user, int callNumberRange, Button[] sortedButton, Button[] randomButton)
        {
            if (user != null)
            {
                nowSortedButton = (Button)user;
                CheckNumber(user, callNumberRange, sortedButton);

                if (nowRandomButton == null)
                {
                    if (nowSortedButton.Text.Length > 2)
                    {
                        nowRandomButton = (Button)user;
                        nowRandomButton.BackColor = Color.FromArgb(255, 128, 0);
                    }
                    return;
                }

                if (nowSortedButton.Text.Length > 2)
                {
                    unDarken(callNumberRange, randomButton);
                }
                nowSortedButton.Text = nowRandomButton.Text;
                nowSortedButton.BackColor = Color.FromArgb(255, 255, 192);
                nowSortedButton.ForeColor = Color.FromArgb(128, 128, 255);



                for (int i = 0; i < callNumberRange; i++)
                {
                    if (nowRandomButton == sortedButton[i])
                    {
                        nowRandomButton.Text = (i + 1).ToString();
                    }
                }

                nowRandomButton.BackColor = Color.FromArgb(192, 255, 255);
                nowRandomButton.ForeColor = Color.FromArgb(255, 192, 128);
                nowRandomButton = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Change button colour
        /// </summary>
        /// <param name="callNumberRange"></param>
        /// <param name="randomButton"></param>
        private static void unDarken(int callNumberRange, Button[] randomButton)
        {
            for (int i = 0; i < callNumberRange; i++)
            {
                if (randomButton[i].Text.Equals(nowSortedButton.Text))
                {
                    randomButton[i].BackColor = Color.FromArgb(255, 255, 192);
                    randomButton[i].ForeColor = Color.FromArgb(128, 128, 255);
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Change button colour
        /// </summary>
        /// <param name="user"></param>
        /// <param name="callNumberRange"></param>
        /// <param name="sortedButton"></param>
        public static void CheckNumber(object user, int callNumberRange, Button[] sortedButton)
        {
            Button button = (Button)user;
            for (int i = 0; i < callNumberRange; i++)
            {
                if (sortedButton[i] != button)
                {
                    if (sortedButton[i].Text.Equals(button.Text))
                    {
                        sortedButton[i].Text = (i + 1).ToString();
                        sortedButton[i].BackColor = Color.FromArgb(192, 255, 255);
                        sortedButton[i].ForeColor = Color.FromArgb(255, 192, 128);
                    }
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Checking whether the sorted books are in the correct order
        /// </summary>
        /// <param name="callNumberRange"></param>
        /// <param name="sortedButton"></param>
        /// <param name="callNumber"></param>
        /// <returns></returns>
        public static bool checkSortedOutput(int callNumberRange, Button[] sortedButton, List<string> callNumber)
        {
            for (int i = 0; i < callNumberRange; i++)
            {
                if (!sortedButton[i].Text.Equals(callNumber[i]))
                {
                    return false;
                }
            }
            return true;
        }

    }   
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//