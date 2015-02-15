using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace grades
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// some changes for GIT
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            gradeInput.Focus(); // place focus in gradeInput textbox
            gradeInput.SelectAll(); // select gradeInput textbox text
        }

        // Display letter grade
        private void DisplayMessage(String letterGrade)
        {
            gradeResult.Text = ("Your grade is: " + letterGrade);
            errorMessage.Visibility = System.Windows.Visibility.Hidden; // hide error message
            gradeInput.Focus();
            gradeInput.SelectAll();
        }

        // Display Error Message
        private void DisplayError()
        {
            gradeResult.Text = "";
            errorMessage.Visibility = System.Windows.Visibility.Visible; // error message visible
            errorMessage.Text = "Numeric grade required between 0 and 100.";
            gradeInput.Text = "Enter Numeric Grade"; // reset gradeInput.Text text
            gradeInput.Focus();
            gradeInput.SelectAll();
        }

        // Determine letter grade from numeric value
        private void LetterGrade()
        {
            decimal grade = 0;
            // Display error message for gradeInput.Text
            // if empty or non-numeric value
            // else display letter grade
            if (decimal.TryParse(gradeInput.Text, out grade))
            {
                if (grade > 100)
                {
                    DisplayError();
                }
                else if (grade >= 95 && grade <= 100)
                {
                    DisplayMessage("A+");
                }
                else if (grade >= 90 && grade < 95)
                {
                    DisplayMessage("A-");
                }
                else if (grade >= 85 && grade < 90)
                {
                    DisplayMessage("B+");
                }
                else if (grade >= 80 && grade < 85)
                {
                    DisplayMessage("B-");
                }
                else if (grade >= 75 && grade < 80)
                {
                    DisplayMessage("C+");
                }
                else if (grade >= 70 && grade < 75)
                {
                    DisplayMessage("C-");
                }
                else if (grade < 70)
                {
                    DisplayMessage("Failed");
                }
            }
            else
            {
                DisplayError();
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            LetterGrade();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}