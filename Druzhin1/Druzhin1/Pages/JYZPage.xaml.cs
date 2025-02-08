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
    /// Логика взаимодействия для JYZPage.xaml
    /// </summary>
    public partial class JYZPage : Page
    {
        public JYZPage()
        {
            InitializeComponent();
            ReportLogDG.ItemsSource = Connect.cont.ReportLog.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ReportLogDG.ItemsSource = Connect.cont.ReportLog.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditJYZPage(null));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditJYZPage((sender as Button).DataContext as ReportLog ));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var delAuto = ReportLogDG.SelectedItems.Cast<ReportLog>().ToList();
            foreach (var del in delAuto)
                if (Connect.cont.Guard.Any(x => x.GuardID == del.GuardID))
                {
                    MessageBox.Show("Данные испеолзуются в таблице Журнал выхода ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить {delAuto} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.cont.ReportLog.RemoveRange(delAuto);
            try
            {
                Connect.cont.SaveChanges();
                ReportLogDG.ItemsSource = Connect.cont.ReportLog.ToList();
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

       
    }
}
