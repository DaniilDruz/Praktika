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
    /// Логика взаимодействия для SelectPage.xaml
    /// </summary>
    public partial class SelectPage : Page
    {
        public SelectPage()
        {
            InitializeComponent();
            GuardDG.ItemsSource = Connect.cont.Guard.Select(x => new
            {
                x.GuardID,
                x.FullName,
                x.Position,
                x.PostID,
                x.TimeJob,
                x.Count,
                Raschet = x.TimeJob * x.Count, 
            }).ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
