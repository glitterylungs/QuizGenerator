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
using System.IO;
using System.Text.Json;

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
            try
            {
                string quizName = quizNameTextBox.Text;
                string content = "Quiz Name";
                if (quizName == content || quizName == "")
                {
                    MessageBox.Show("Enter Quiz Name");

                }
                else
                {
                    SubWindow subWindow = new SubWindow(quizNameTextBox.Text);
                    Close();
                    subWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    // ścieżka do pliku
                    string filename = null;
                    filename = openFileDialog.FileName;
                    filename = filename.Replace("\\", "/");
                    MessageBox.Show(filename);

                    // nazwa pliku --> nazwa quizu
                    string name = null;
                    name = System.IO.Path.GetFileNameWithoutExtension(filename);
                    MessageBox.Show(name);
                    
                    SubWindow subWindow = new SubWindow(name, filename);
                    Close();
                    subWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
