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
using System.Windows.Shapes;

namespace QuizGenerator
{
    /// <summary>
    /// Logika interakcji dla klasy SubWindow.xaml
    /// </summary>
    public partial class SubWindow : Window
    {
        public SubWindow()
        {
            TextBoxWithErrorProvider.BrushForAll = Brushes.Red;
            InitializeComponent();
        }

        public SubWindow(string quizNameText) : this()
        {
            quizName.Text = quizNameText;
        }

        private bool isNoEmpty(TextBoxWithErrorProvider tb)
        {
            if (tb.Text.Trim() == "")
            {
                tb.SetError("Fill in the field");
                return false;
            }
            tb.SetError("");
            return true;
        }

        private void addButtonClick(object sender, RoutedEventArgs e)
        {
            if(isNoEmpty(questionTextBox) & isNoEmpty(answerOne) & isNoEmpty(answerTwo) & isNoEmpty(answerThree) & isNoEmpty(answerFour))
            {
                List<string> correct = new List<string>();

                if (answerOneCorrect.IsChecked == true)
                {
                    correct.Add(answerOne.Text);
                }
                if (answerTwoCorrect.IsChecked == true)
                {
                    correct.Add(answerTwo.Text);
                }
                if (answerThreeCorrect.IsChecked == true)
                {
                    correct.Add(answerThree.Text);
                }
                if (answerFourCorrect.IsChecked == true)
                {
                    correct.Add(answerFour.Text);
                }

                Question question = new Question(questionTextBox.Text, answerOne.Text, answerTwo.Text, answerThree.Text, answerFour.Text, correct);

                listBox.Items.Add(question);
                listBox.SelectedItem = null;

                questionTextBox.Text = "";
                answerOne.Text = "";
                answerTwo.Text = "";
                answerThree.Text = "";
                answerFour.Text = "";
                answerOneCorrect.IsChecked = false;
                answerThreeCorrect.IsChecked = false;
                answerThreeCorrect.IsChecked = false;
                answerFourCorrect.IsChecked = false;
            }
        }
    }
}
