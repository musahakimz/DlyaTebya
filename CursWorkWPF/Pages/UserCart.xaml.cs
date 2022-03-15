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

namespace CursWorkWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserCart.xaml
    /// </summary>
    public partial class UserCart : Page
    {

        private Entity.Book _book = new Entity.Book();

        public UserCart()
        {
            InitializeComponent();
            DataContext = _book;
        }

        private void saveData_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Convert.ToString(_book.order)))
            {
                error.AppendLine("Укажите номер заказа!");
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(_book.table)))
            {
                error.AppendLine("Выберите блюдо");
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_book.id == 0)
            {
                Entity.RestorauntEntities.GetContext().Book.Add(_book);
            }

            try
            {
                Entity.RestorauntEntities.GetContext().SaveChanges();
                Classes.ManagerClass.MainFrame.Navigate(new Pages.UserCart());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clearData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
