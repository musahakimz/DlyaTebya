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
    /// Логика взаимодействия для LookDish.xaml
    /// </summary>
    public partial class LookDish : Page
    {
        public LookDish()
        {
            InitializeComponent();
            DBGridModel.ItemsSource = Entity.RestorauntEntities.GetContext().Dish.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.ManagerClass.MainFrame.Navigate(new Pages.AddDish((sender as Button).DataContext as Entity.Dish));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteDish = DBGridModel.SelectedItems.Cast<Entity.Dish>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {deleteDish.Count()} элемента?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entity.RestorauntEntities.GetContext().Dish.RemoveRange(deleteDish);
                    Entity.RestorauntEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация удалена успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    DBGridModel.ItemsSource = Entity.RestorauntEntities.GetContext().Dish.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void firstPage_Click(object sender, RoutedEventArgs e)
        {
            Classes.ManagerClass.MainFrame.Navigate(new Pages.LookRestoraunt());
        }

        private void secondPage_Click(object sender, RoutedEventArgs e)
        {
            Classes.ManagerClass.MainFrame.Navigate(new Pages.LookDish());
        }

        private void thirdPage_Click(object sender, RoutedEventArgs e)
        {
            Classes.ManagerClass.MainFrame.Navigate(new Pages.LookTable());
        }
    }
}
