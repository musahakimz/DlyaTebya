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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            MainFrames.Navigate(new Pages.CollectOrder());
            Classes.ManagerClass.MainFrame = MainFrames;
        }

        private void createOrder_Click(object sender, RoutedEventArgs e)
        {
            MainFrames.Navigate(new Pages.CollectOrder());
        }

        private void goCart_Click(object sender, RoutedEventArgs e)
        {
            MainFrames.Navigate(new Pages.UserCart());
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MainFrames_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrames.CanGoBack)
            {
                backButton.Visibility = Visibility.Visible;
            }
            else
            {
                backButton.Visibility = Visibility.Hidden;
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.ManagerClass.MainFrame.GoBack();
        }

        private void createDish_Click(object sender, RoutedEventArgs e)
        {
            MainFrames.Navigate(new Pages.CreateOrder());
        }

        private void goCart_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrames.Navigate(new Pages.UserCart());
        }
    }
}
