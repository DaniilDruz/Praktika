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
using Druzhin1.Pages;

namespace Druzhin1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditJYZPage.xaml
    /// </summary>
    public partial class AddEditJYZPage : Page
    {
        ReportLog tat;
        bool check;
        public AddEditJYZPage( ReportLog c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new ReportLog();
                check = true;
            }
            else
            {
                check = false;
            }
            DataContext = tat = c;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (check)
            {
                 Connect.cont.ReportLog.Add(tat);
            }
            try
            {
                Connect.cont.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.MainFrame.GoBack();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
