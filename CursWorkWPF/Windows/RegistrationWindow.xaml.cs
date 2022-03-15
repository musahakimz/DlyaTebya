using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new Entity.RestorauntEntities())
            {
                Entity.Users users = new Entity.Users()
                {
                    loginUser = regName.Text,
                    passwordUser = regPassword.Password,
                    roleUser = yourRole.Text,
                    emailUser = regEmail.Text
                };
                db.Users.Add(users);
                db.SaveChanges();
            }
            MessageBox.Show("Поздравляю Вас с успешной регистрацией. Благодарим за выбор нашего сервиса :)", "Спасибо :)", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Hide();
        }

    }
}
