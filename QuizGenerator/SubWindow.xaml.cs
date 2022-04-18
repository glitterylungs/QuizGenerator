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

        // konstruktor by przekazac nazwe quizu z MainWindow
        public SubWindow(string quizNameText) : this()
        {
            quizName.Text = quizNameText;
        }

        // obsluga przycisku Add
        private void addButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                // sprawdzenie czy wszystkie textBoxy zostały wypełnione
                if (isNoEmpty(questionTextBox) & isNoEmpty(answerOne) & isNoEmpty(answerTwo) & isNoEmpty(answerThree) & isNoEmpty(answerFour))
                {
                    // stworzenie listy odpowiedzi poprawnych
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

                    // sprawdzenie czy zaznaczono jakas prawidlowa odpowiedz
                    if (!correct.Any())
                    {
                        MessageBox.Show("Select the correct answer/answers using checkboxes.");
                    }
                    else
                    {
                        Question question = new Question(questionTextBox.Text, answerOne.Text, answerTwo.Text, answerThree.Text, answerFour.Text, correct);

                        listBox.Items.Add(question);
                        listBox.SelectedItem = null;

                        clearTextBoxes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        // obsługa przycisku Modify
        private void modifyButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Question selectedQuestion = listBox.SelectedItem as Question;
                if(selectedQuestion != null)
                {
                    if (isNoEmpty(questionTextBox) & isNoEmpty(answerOne) & isNoEmpty(answerTwo) & isNoEmpty(answerThree) & isNoEmpty(answerFour))
                    {
                        // stworzenie listy odpowiedzi poprawnych
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

                        // sprawdzenie czy zaznaczono jakas prawidlowa odpowiedz
                        if (!correct.Any())
                        {
                            MessageBox.Show("Select the correct answer/answers using checkboxes.");
                        }
                        else
                        {
                            selectedQuestion.Name = questionTextBox.Text;
                            selectedQuestion.answerOne = answerOne.Text;
                            selectedQuestion.answerTwo = answerTwo.Text;
                            selectedQuestion.answerThree = answerThree.Text;
                            selectedQuestion.answerFour = answerFour.Text;
                            selectedQuestion.correctAnswers = correct;

                            listBox.Items.Refresh();
                            listBox.SelectedItem = null;

                            clearTextBoxes();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // obsługa przycisku Delete
        private void deleteButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                listBox.Items.Remove(listBox.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // po wybraniu danego pola w listBox zostaje ono wpisane w formularz
        private void listBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Question selectedQuestion = listBox.SelectedItem as Question; 
                if (selectedQuestion != null)
                {
                    questionTextBox.Text = selectedQuestion.Name;
                    answerOne.Text = selectedQuestion.answerOne;
                    answerTwo.Text = selectedQuestion.answerTwo;
                    answerThree.Text = selectedQuestion.answerThree;
                    answerFour.Text = selectedQuestion.answerFour;

                    if (selectedQuestion.correctAnswers.Contains(answerOne.Text))
                    {
                        answerOneCorrect.IsChecked = true;
                    }
                    if (selectedQuestion.correctAnswers.Contains(answerTwo.Text))
                    {
                        answerTwoCorrect.IsChecked = true;
                    }
                    if (selectedQuestion.correctAnswers.Contains(answerThree.Text))
                    {
                        answerThreeCorrect.IsChecked = true;
                    }
                    if (selectedQuestion.correctAnswers.Contains(answerFour.Text))
                    {
                        answerFourCorrect.IsChecked = true;
                    }
                }
                else
                {
                    clearTextBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearTextBoxes()
        {
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
    }
}
