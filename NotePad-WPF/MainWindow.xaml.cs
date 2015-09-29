using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace NotePad_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string fileName = "";
        public string defaultFileName = "Untitled";


        public MainWindow()
        {
            InitializeComponent();

        }
        

        private void MenuItem_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            bool? openFile = dialog.ShowDialog();

            if (openFile == true)
            {
                //Get the name of the file selected by the user
                fileName = dialog.FileName;

                //Open the file and read the contents into a string
                string fileContents = File.ReadAllText(fileName);

                //Assign the contents of the file to the textvox created in WPF
                TextBox_Editor.Text = fileContents;

            }



        }

        //Save Button
        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            if (fileName == "")
            {
                openSaveAs();

            }

           //check contents of fileName
           string fileNameContents = File.ReadAllText(fileName);

            //Check contents of TextBox_Editor
            string TextBoxEditorFiles = TextBox_Editor.Text;


            //Compare fileName Contents and TextBox_Editor
            if(fileNameContents == TextBoxEditorFiles)
            {
                //If equal || Return
                return;
            }

            //If not equal, save TextBoxEditor Content
            File.WriteAllText(fileName, TextBox_Editor.Text);




        }

        //Exit Button
        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit? Ensure your file is saved.", "Important Alert", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);

            }

        }


        //Save As
        private void MenutItem_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            openSaveAs();
        }

        //Create a new file
        private void MenuItem_New_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Are you sure you want to create a file? Any unsaved work will be lost.", "Important Alert", MessageBoxButton.YesNo);


            if (result == MessageBoxResult.Yes)
            {
                TextBox_Editor.Clear();

            }


        }
        public void openSaveAs()
        {
               //Opens Save file dialog box
               SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //Only allows .txt files to be saved
            saveFileDialog1.Filter = "Text Files|*.txt";

            //Users decision to act with SaveDialog
            bool? saveFileAs = saveFileDialog1.ShowDialog();
           

            //If user does press save
            if (saveFileAs == true)
            {
                //File Name of user choice
                string fileNameNew = saveFileDialog1.FileName;

                //Rename FileName
                fileName = fileNameNew;

                //Writes the text to the file
                File.WriteAllText(fileNameNew, TextBox_Editor.Text);

            }
            //If user decides not to save, do nothing.
            return;

        }
    }
}
