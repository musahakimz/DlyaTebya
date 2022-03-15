using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для AddRestoraunt.xaml
    /// </summary>
    public partial class AddRestoraunt : Page
    {

        private Entity.Restoraunt _restoraunt = new Entity.Restoraunt();

        public AddRestoraunt(Entity.Restoraunt selectedRestoraunt)
        {
            InitializeComponent();

            if(selectedRestoraunt != null)
            {
                _restoraunt = selectedRestoraunt;
            }

            DataContext = _restoraunt;

        }

        private void saveData_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_restoraunt.addres))
            {
                error.AppendLine("Укажите адрес ресторана!");
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(_restoraunt.openTime)))
            {
                error.AppendLine("Укажите начало работы ресторана!");
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(_restoraunt.closeTime)))
            {
                error.AppendLine("Укажите конец работы ресторана!");
            }


            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_restoraunt.id == 0)
            {
                Entity.RestorauntEntities.GetContext().Restoraunt.Add(_restoraunt);
            }

            try
            {
                Entity.RestorauntEntities.GetContext().SaveChanges();
                Classes.ManagerClass.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clearData_Click(object sender, RoutedEventArgs e)
        {
            adressRes.Text = null;
            openRes.Text = null;
            closeRes.Text = null;
        }
    }
}
