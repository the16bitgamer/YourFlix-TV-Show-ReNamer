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
using System.Windows.Shapes;

namespace TV_Show_ReNamer
{
    /// <summary>
    /// Interaction logic for CompleteMessage.xaml
    /// </summary>
    public partial class CompleteMessage : Window
    {
        ProgressBar otherProgressBar;
        public CompleteMessage(int NumberOfTasks , ProgressBar PB)
        {
            InitializeComponent();
            TextBlock message = (TextBlock)FindName("CompleteMesg");

            message.Text = "Successfully Proccessed " + NumberOfTasks + " Videos";

            otherProgressBar = PB;
        }

        private void CloseMenu(object sender, RoutedEventArgs e)
        {
            otherProgressBar.Value = 0;
            Close();
        }
    }
}
