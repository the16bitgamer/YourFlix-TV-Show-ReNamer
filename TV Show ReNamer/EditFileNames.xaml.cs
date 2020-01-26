using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TV_Show_ReNamer
{
    /// <summary>
    /// Interaction logic for EditFileNames.xaml
    /// </summary>
    public partial class EditFileNames : Window
    {
        //<TextBlock HorizontalAlignment = "Left" Margin="20,10,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top"/>
        //<TextBox HorizontalAlignment="Center" Height="23" Margin="0,10,0,0" TextWrapping="Wrap" Text="TextBox" VerticalAlignment="Top" Width="112.5" TextChanged="TextBox_TextChanged_1"/>
        //<TextBox HorizontalAlignment = "Right" Height="23" Margin="0,10,20,0" TextWrapping="Wrap" Text="TextBox" VerticalAlignment="Top" Width="120" TextChanged="TextBox_TextChanged"/>

        Grid videoPanel;
        List<VideoStruct> videos;

        List<TextBox> FileNames;
        List<TextBox> VideoTitles;

        MainWindow mainWindow;

        public EditFileNames(List<VideoStruct> VIDEOS, MainWindow main)
        {
            InitializeComponent();

            videoPanel = (Grid)FindName("VideoPanel");

            mainWindow = main;
            videos = VIDEOS;

            FileNames = new List<TextBox>();
            VideoTitles = new List<TextBox>();

            PopulateVideoPanel();
        }

        void PopulateVideoPanel()
        {
            int yPos = 10;
            int height = 25;
            int width = 200;

            foreach (var video in videos)
            {
                TextBlock fileName = new TextBlock();
                TextBox editName = new TextBox();
                TextBox editTitle = new TextBox();

                fileName.Height = height;
                editName.Height = height;
                editTitle.Height = height;

                fileName.Width = width;
                editName.Width = width;
                editTitle.Width = width;

                fileName.HorizontalAlignment = HorizontalAlignment.Left;
                editName.HorizontalAlignment = HorizontalAlignment.Center;
                editTitle.HorizontalAlignment = HorizontalAlignment.Right;

                fileName.VerticalAlignment = VerticalAlignment.Top;
                editName.VerticalAlignment = VerticalAlignment.Top;
                editTitle.VerticalAlignment = VerticalAlignment.Top;

                fileName.Margin = new Thickness(20, yPos, 0, 0);
                editName.Margin = new Thickness(0, yPos, 0, 0);
                editTitle.Margin = new Thickness(0, yPos, 20, 0);

                fileName.Text = video.FileLocation;
                editName.Text = video.Name;
                editTitle.Text = video.Name;

                yPos += 30;

                FileNames.Add(editName);
                VideoTitles.Add(editTitle);

                videoPanel.Children.Add(fileName);
                videoPanel.Children.Add(editName);
                videoPanel.Children.Add(editTitle);
            }
        }

        private void Finished(object sender, RoutedEventArgs e)
        {
            ProccessNewEntieries();
            mainWindow.currentListOfVideos = videos;
            Close();
        }

        private void ProccessNewEntieries()
        {
            for (int i = 0; i < videos.Count; i++)
            {
                videos[i].FileName = FileString(FileNames[i].Text);
                videos[i].Name = VideoTitles[i].Text;
            }
        }

        private string FileString(string fileName)
        {
            string[] badCharacters = { "?", "/", "\\", ":", "*", "?", "\"", "<", ">", "|" };

            foreach(var badChar in badCharacters)
            {
                fileName = fileName.Replace(badChar, "");
            }
            
            return fileName;
        }
    }
}
