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
    /// Логика взаимодействия для CollectOrder.xaml
    /// </summary>
    public partial class CollectOrder : Page
    {

        private Entity.Order _order = new Entity.Order();

        public CollectOrder()
        {
            InitializeComponent();

            DataContext = _order;

        }

        private void saveData_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();


            if (_order.date < DateTime.Today)
            {
                error.AppendLine("Мы не доставляем в прошлое :)");
            }


            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_order.id == 0)
            {
                Entity.RestorauntEntities.GetContext().Order.Add(_order);
            }

            try
            {
                Entity.RestorauntEntities.GetContext().SaveChanges();
                Classes.ManagerClass.MainFrame.Navigate(new Pages.CreateOrder());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clearData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void countPersons_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
