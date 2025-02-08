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
    /// Логика взаимодействия для AddEditJVPage.xaml
    /// </summary>
    public partial class AddEditJVPage : Page
    {
        DutyLog rar;
        bool checkNew;
        public AddEditJVPage( DutyLog c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new DutyLog();
                checkNew = true;
            }
            else
            {
                checkNew = false;
            }
                

            DataContext = rar = c;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Connect.cont.DutyLog.Add(rar);
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
