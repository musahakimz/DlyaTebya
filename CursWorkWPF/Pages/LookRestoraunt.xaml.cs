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
    /// Логика взаимодействия для LookRestoraunt.xaml
    /// </summary>
    public partial class LookRestoraunt : Page
    {
        public LookRestoraunt()
        {
            InitializeComponent();
            DBGridModel.ItemsSource = Entity.RestorauntEntities.GetContext().Restoraunt.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.ManagerClass.MainFrame.Navigate(new Pages.AddRestoraunt((sender as Button).DataContext as Entity.Restoraunt));
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

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteRes = DBGridModel.SelectedItems.Cast<Entity.Restoraunt>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {deleteRes.Count()} элемента?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entity.RestorauntEntities.GetContext().Restoraunt.RemoveRange(deleteRes);
                    Entity.RestorauntEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация удалена успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    DBGridModel.ItemsSource = Entity.RestorauntEntities.GetContext().Restoraunt.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
