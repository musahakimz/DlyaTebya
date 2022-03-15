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
    /// Логика взаимодействия для AddDish.xaml
    /// </summary>
    public partial class AddDish : Page
    {

        private Entity.Dish _dish = new Entity.Dish();

        public AddDish(Entity.Dish selectedDish)
        {
            InitializeComponent();

            if (selectedDish != null)
            {
                _dish = selectedDish;
            }

            DataContext = _dish;

        }

        private void saveData_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_dish.names))
            {
                error.AppendLine("Укажите намеинование блюда!");
            }

            if (_dish.weights < 0)
            {
                error.AppendLine("Вес блюда не может быть меньше 0");
            }

            if (_dish.price < 0)
            {
                error.AppendLine("Цена блюда не может быть меньше 0");
            }

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_dish.id == 0)
            {
                Entity.RestorauntEntities.GetContext().Dish.Add(_dish);
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
            nameDish.Text = ""; 
            descrDish.Text = "";
            weightDish.Text = "";
            priceDish.Text = "";
        }
    }
}
