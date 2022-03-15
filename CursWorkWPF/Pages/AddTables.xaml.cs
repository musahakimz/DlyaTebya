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
    /// Логика взаимодействия для AddTables.xaml
    /// </summary>
    public partial class AddTables : Page
    {

        private Entity.Table _table = new Entity.Table();

        public AddTables(Entity.Table selectedTable)
        {
            InitializeComponent();

            if (selectedTable != null)
            {
                _table = selectedTable;
            }

            DataContext = _table;

        }

        private void saveData_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (_table.persons < 1)
            {
                error.AppendLine("Столик не может быть меньше чем 1 человека");
            }

            if (_table.place < 1 || _table.place > 5)
            {
                error.AppendLine("В нашем ресторане лишь 5 видов столиков");
            }

            if (_table.isFree > 1 || _table.isFree < 0)
            {
                error.AppendLine("Если столик свободен, то 1, если нет, то 0!");
            }


            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_table.id == 0)
            {
                Entity.RestorauntEntities.GetContext().Table.Add(_table);
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
            isFree.Text = "";
            countPersons.Text = "";
            viewRes.Text = "";
        }
    }
}
