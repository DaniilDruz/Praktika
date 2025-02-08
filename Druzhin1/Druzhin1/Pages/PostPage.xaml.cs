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
    /// Логика взаимодействия для PostPage.xaml
    /// </summary>
    public partial class PostPage : Page
    {
        public PostPage()
        {
            InitializeComponent();
            PostDG.ItemsSource = Connect.cont.Post.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PostDG.ItemsSource = Connect.cont.Post.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditPostPage(null));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditPostPage((sender as Button).DataContext as Post));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var delAuto = PostDG.SelectedItems.Cast<Post>().ToList();
            foreach (var del in delAuto)
                if (Connect.cont.Guard.Any(x => x.PostID == del.iD))
                {
                    MessageBox.Show("Данные испеолзуются в таблице Журнал выхода ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить {delAuto} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.cont.Post.RemoveRange(delAuto);
            try
            {
                Connect.cont.SaveChanges();
                PostDG.ItemsSource = Connect.cont.Post.ToList();
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
