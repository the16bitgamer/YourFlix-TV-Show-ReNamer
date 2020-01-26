using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TV_Show_ReNamer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string fileLocation = @"C:\Users\Andre\Videos";
        FindFolder fileFolder;
        TextBlock folderLocationText;
        TextBox seriesName;
        TextBox seriesSufx;
        RetreveFiles retrever;
        string currentTag = "";

        public List<VideoStruct> currentListOfVideos;

        public MainWindow()
        {
            InitializeComponent();
            fileFolder = new FindFolder(fileLocation);

            folderLocationText = (TextBlock)FindName("Folder_Location");
            seriesName = (TextBox)FindName("Series_Name");
            seriesSufx = (TextBox)FindName("Series_Sufx");

            folderLocationText.Text = fileLocation;
            retrever = new RetreveFiles();

            currentListOfVideos = retrever.RetreveFilesFromFolder(fileLocation);
        }

        public void SetFolder(object sender, RoutedEventArgs e)
        {
            fileLocation = fileFolder.SelectFolder();
            folderLocationText.Text = fileLocation;

            currentListOfVideos = retrever.RetreveFilesFromFolder(fileLocation);
        }

        public void EditVideoNames(object sender, RoutedEventArgs e)
        {
            EditFileNames win3 = new EditFileNames(currentListOfVideos, this);
            win3.Show();
        }

        public void ProcessFolder(object sender, RoutedEventArgs e)
        {
            seriesSufx.BorderBrush = Brushes.Black;
            seriesName.BorderBrush = Brushes.Black;
            if (seriesName.Text == string.Empty || seriesSufx.Text == string.Empty)
            {
                if(seriesName.Text == string.Empty)
                {
                    seriesName.BorderBrush = Brushes.Red;
                }

                if (seriesSufx.Text == string.Empty)
                {
                    seriesSufx.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                currentTag = seriesName.Text + " " + seriesSufx.Text;
                new VideoRetitler().RenameVideos(currentListOfVideos, currentTag, (ProgressBar)FindName("P_Bar"));
                CompleteMessage win2 = new CompleteMessage(currentListOfVideos.Count, (ProgressBar)FindName("P_Bar"));
                win2.Show();
            }
            System.Media.SystemSounds.Beep.Play();
        }
    }
}
