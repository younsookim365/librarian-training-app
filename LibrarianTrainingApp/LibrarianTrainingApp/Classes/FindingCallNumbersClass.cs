// References: https://csharpexamples.com/c-binary-search-tree-implementation/
//             https://www.c-sharpcorner.com/article/tree-data-structure/
//             https://introprogramming.info/english-intro-csharp-book/read-online/chapter-17-trees-and-graphs/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarianTrainingApp  
{
    static class FindingCallNumbersClass
    {
        // Declaring variables
        public static int seconds;
        public static int GainedPoints = 100;
        public static int LostPoints = -50;
        public static int TimePoints = 300;
        public static int newRecord = 0;
        public static int userPoints = 0;
        public static int TopLevelTotal = 10;
        public static int LevelTotal = 3;
        public static int OptionsTotal = 4;
        public static int levelNow;
        public static int topLevelNodeTotal;
        public static int[] chosen = new int[LevelTotal];
        public static string[] answers = new string[LevelTotal];
        static Node root;
        public static Random random = new Random();
        public static List<int> firstLevel = new List<int>();
        private static string DirectoryPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName).FullName + @"\datalist.txt";

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Tree node
        /// </summary>
        public class Node
        {
            public string data;
            public string data2;
            public List<Node> child = new List<Node>();
        };

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Making a new tree node
        /// </summary>
        /// <param name="data"></param>
        /// <param name="data2"></param>
        /// <returns></returns>
        public static Node makeNode(string data, string data2)
        {
            Node c = new Node();
            c.data = data;
            c.data2 = data2;
            return c;
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adding node to tree
        /// </summary>
        /// <param name="btn"></param>
        public static void AddNodes(Button[] btn)
        {
            root = makeNode("Librarian Training", "App");

            levelNow = 0;

            string[] rows = File.ReadAllLines(DirectoryPath);

            int a = 0;
            int b = 0;

            foreach (string row in rows)
            {
                string[] desc = row.Split('+'); 

                switch (desc[0])
                {
                    case "1": 
                        root.child.Add(makeNode(desc[1], desc[2]));
                        b = 0;
                        a++;
                        break;
                    case "2": 
                        root.child[a-1].child.Add(makeNode(desc[1], desc[2]));
                        b++;
                        break;
                    case "3":
                        root.child[a-1].child[b-1].child.Add(makeNode(desc[1], desc[2]));
                        break;
                }
            }
            topLevelNodeTotal = a;
            AddButtons(btn);
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Get call numbers and descriptions from tree
        /// </summary>
        /// <param name="btn"></param>
        public static void AddButtons(Button[] btn)
        {
            string[] returns = new string[OptionsTotal]; 

            switch (levelNow)
            {
                case 0:
                    for (int i = 0; i < OptionsTotal; i++)
                    {
                        returns[i] = root.child[firstLevel[i]].data + "\n" + root.child[firstLevel[i]].data2;
                    }
                    break;
                case 1:
                    for (int i = 0; i < OptionsTotal; i++)
                    {
                        returns[i] = root.child[chosen[0]].child[i].data + "\n" + root.child[chosen[0]].child[i].data2;
                    }
                    break;
                case 2:
                    for (int i = 0; i < OptionsTotal; i++)
                    {
                        returns[i] = root.child[chosen[0]].child[chosen[1]].child[i].data + "\n" + root.child[chosen[0]].child[chosen[1]].child[i].data2;
                    }
                    break;
            }

            for (int i = 0; i < btn.Length; i++)
            {
                btn[i].Text = returns[i];
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Add random numbers to first level
        /// </summary>
        public static void AddRandomFirstLevel()
        {
            firstLevel.Clear();
            while (firstLevel.Count != 4)
            {
                int d = random.Next(0, TopLevelTotal);
                if (!firstLevel.Contains(d))
                {
                    firstLevel.Add(d);
                }
            }
            firstLevel.Sort();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Correct answers
        /// </summary>
        public static void CorrectAnswers()
        {
            answers[0] = root.child[chosen[0]].data + "\n" + root.child[chosen[0]].data2;
            answers[1] = root.child[chosen[0]].child[chosen[1]].data + "\n" + root.child[chosen[0]].child[chosen[1]].data2;
            answers[2] = root.child[chosen[0]].child[chosen[1]].child[chosen[2]].data + "\n" + root.child[chosen[0]].child[chosen[1]].child[chosen[2]].data2;
        }

        //------------------------------------------------------------------------------------------------------------------------//
       /// <summary>
       /// Description label with top level description
       /// </summary>
       /// <param name="descriptionLabel"></param>
        public static void DescriptionLabel(Label descriptionLabel)
        {
            while (true)
            {
                int d = random.Next(0, TopLevelTotal);
                if (firstLevel.Contains(d))
                {
                    chosen[0] = d;
                    break;
                }
            }

            for (int i = 1; i < LevelTotal; i++)
            {
                chosen[i] = random.Next(0, LevelTotal);
            }

            CorrectAnswers();
            descriptionLabel.Text = root.child[chosen[0]].child[chosen[1]].child[chosen[2]].data2;
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Adding points
        /// </summary>
        /// <param name="descriptionLabel"></param>
        public static void PointsAdded(Label descriptionLabel)
        {
            if (seconds == 0)
            {
                seconds = 1;
            }
            userPoints += GainedPoints + (TimePoints / seconds);

            NewRecord(userPoints);

            descriptionLabel.Text = userPoints.ToString();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// New record
        /// </summary>
        /// <param name="points"></param>
        public static void NewRecord(int points)
        {
            if (points > newRecord)
            {
                newRecord = points;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Deducting points
        /// </summary>
        /// <param name="descriptionLabel"></param>
        public static void PointsDeducted(Label descriptionLabel)
        {
            userPoints += LostPoints;
            descriptionLabel.Text = userPoints.ToString();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Button click event for possible answers
        /// </summary>
        /// <param name="user"></param>
        /// <param name="btn"></param>
        /// <param name="descriptionLabel"></param>
        /// <returns></returns>
        public static bool ButtonClick(object user, Button[] btn, Label descriptionLabel)
        {
            Button bton = (Button)user;

            if (IsAnswerRight(bton.Text))
            {
                levelNow++;
                PointsAdded(descriptionLabel);
                if (levelNow == 3)
                {
                    MessageBox.Show("Well done! You have chosen the correct option! You scored: " + userPoints + " points!");
                    return true;
                }
                AddButtons(btn);
            }
            else
            {
                levelNow++;
                PointsDeducted(descriptionLabel);
                MessageBox.Show("Incorrect! The correct answer is: " + answers[levelNow - 1] + ". Try again!");
                if (levelNow == 3)
                {
                    return true;
                }
                AddButtons(btn);
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Checking whether if the chosen answer is correct
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public static bool IsAnswerRight(string answer)
        {
            if (!answer.Equals(answers[levelNow]))
            {
                return false;
            }
            return true;
        }                
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//