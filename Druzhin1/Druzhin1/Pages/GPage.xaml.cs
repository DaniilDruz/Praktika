using Druzhin1.AppData;
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

namespace Druzhin1.Pages
{
    /// <summary>
    /// Логика взаимодействия для GPage.xaml
    /// </summary>
    public partial class GPage : Page
    {
        public GPage()
        {
            InitializeComponent();
            GuardDG.ItemsSource = Connect.cont.Guard.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditGPage(null));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GuardDG.ItemsSource = Connect.cont.Guard.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditGPage((sender as Button).DataContext as Guard));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var delAuto = GuardDG.SelectedItems.Cast<Guard>().ToList();
            foreach (var del in delAuto)
                if (Connect.cont.Guard.Any(x => x.GuardID == del.GuardID))
                {
                    MessageBox.Show("Данные испеолзуются в таблице Журнал выхода ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить {delAuto} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.cont.Guard.RemoveRange(delAuto);
            try
            {
                Connect.cont.SaveChanges();
                GuardDG.ItemsSource = Connect.cont.Guard.ToList();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GuardDG.ItemsSource = Connect.cont.Guard.ToList();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            GuardDG.ItemsSource = Connect.cont.Guard.OrderBy(x => x.GuardID).ToList();  
        }
    }
}
