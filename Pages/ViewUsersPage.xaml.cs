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
using Kursach_1.Classes;
using Kursach_1.Migrations;

namespace Kursach_1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewUsersPage.xaml
    /// </summary>
    public partial class ViewUsersPage : Page
    {
        public ViewUsersPage()
        {
            InitializeComponent();

            dataGridUsers.ItemsSource = App.db.User.Where(u => u.Id > 1).OrderBy(p => p.Id).ToList();

        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridUsers.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите пользователя, которого хотите отредактировать!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var row = dataGridUsers.SelectedItem as Users;
                int result = row.Id;
                FrameObj.frameMain.Navigate(new EditUserPage(result));
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new AddUserPage());
        }
    }
}
