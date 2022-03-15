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

namespace CursWorkWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new Entity.RestorauntEntities())
            {
                foreach(var item in db.Users)
                {
                    if (loginName.Text == item.loginUser && passwordName.Password == item.passwordUser && item.roleUser == "1")
                    {
                        MessageBox.Show("Добро пожаловать в аккаунт:)", "Welcome, friend!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Windows.AdminWindows aW = new Windows.AdminWindows();
                        aW.Show();
                        this.Hide();
                        return;
                    }
                    else if (loginName.Text == item.loginUser && passwordName.Password == item.passwordUser && item.roleUser == "0")
                    {
                        MessageBox.Show("Добро пожаловать в аккаунт:)", "Welcome, friend!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Windows.UserWindow uW = new Windows.UserWindow();
                        uW.Show();
                        this.Hide();
                        return;
                    }
                }
            }    
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены в этом?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                Windows.RegistrationWindow rW = new Windows.RegistrationWindow();
                rW.Show();
                this.Hide();
            }
        }
    }
}
