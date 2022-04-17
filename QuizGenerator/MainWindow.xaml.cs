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
using Microsoft.Win32;

namespace QuizGenerator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void textBoxGotFocus(object sender, RoutedEventArgs e) //usuwanie label po kliknieciu w textbox
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= textBoxGotFocus;
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            string quizName = quizNameTextBox.Text;
            string content = "Quiz Name";
            MessageBox.Show(quizName);
            if ( quizName != content || quizName != "")
            {
                SubWindow subWindow = new SubWindow();
                Close();
                subWindow.Show();
            }
            else
            {
                MessageBox.Show("Enterr Quiz Name");
            }
        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true) ;
        }
    }
}
