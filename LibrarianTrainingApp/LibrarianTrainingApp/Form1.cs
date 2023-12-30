// Youn-Soo Kim
// ST10114702
// GROUP 8

// References:https://www.youtube.com/watch?v=iL6Kz8pjmkc&list=LL&index=10
//            https://www.youtube.com/watch?v=ep35DE6W6ak&list=LL&index=7
//            https://www.youtube.com/watch?v=DMgllqg9y8A&list=LL&index=1
//            https://www.youtube.com/watch?v=YfIdKoYfGi4

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarianTrainingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        // Disable X Button
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Open ReplacingBooksForm from Form1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadReplacingBooksForm(object sender, EventArgs e)
        {            
            ReplacingBooksForm replacingBooksForm = new ReplacingBooksForm();
            replacingBooksForm.Show();

            // Close Form1
            this.Close();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Open IdentifyingAreasForm from Form1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadIdentifyingAreasForm(object sender, EventArgs e)
        {             
            IdentifyingAreasForm identifyingAreasForm = new IdentifyingAreasForm();
            identifyingAreasForm.Show();

            // Close Form1
            this.Close();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /*/// <summary>
        /// Finding Call Numbers not available for Part 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFindingCallNumbersForm(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("This option is not available", "Dewey Decimal Game");
        }*/

        //------------------------------------------------------------------------------------------------------------------------//
        // Open FindingCallNumbersForm from Form1
        private void LoadFindingCallNumbersForm(object sender, EventArgs e)
        {
            FindingCallNumbersForm findingCallNumbersForm = new FindingCallNumbersForm();
            findingCallNumbersForm.Show();

            // Close Form1
            this.Close();
        }

        //------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Closing the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadExit(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//
