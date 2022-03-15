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

namespace CursWorkWPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindows.xaml
    /// </summary>
    public partial class AdminWindows : Window
    {
        public AdminWindows()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.LookRestoraunt());
            Classes.ManagerClass.MainFrame = MainFrame;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.ManagerClass.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                backButton.Visibility = Visibility.Visible;
            }
            else
            {
                backButton.Visibility = Visibility.Hidden;
            }
        }

        private void addRestoraunt_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.AddRestoraunt(null));
        }

        private void addDish_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.AddDish(null));
        }

        private void addTable_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.AddTables(null));
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
