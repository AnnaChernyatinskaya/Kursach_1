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

namespace Kursach_1.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditHomePage.xaml
    /// </summary>
    public partial class EditHomePage : Page
    {
        public EditHomePage()
        {
            InitializeComponent();

            famtext.Text = App.currentUser.surname;
            nametext.Text = App.currentUser.name;
            surnametext.Text = App.currentUser.middlename;
            teltext.Text = App.currentUser.teltphone;
            mailtext.Text = App.currentUser.email;
            logintext.Text = App.currentUser.login;
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            if (logintext.Text != null)
            {
                App.currentUser.surname = famtext.Text;
                App.currentUser.name = nametext.Text;
                App.currentUser.middlename = surnametext.Text;
                App.currentUser.teltphone = teltext.Text;
                App.currentUser.email = mailtext.Text;
                App.currentUser.login = logintext.Text;
                App.db.SaveChanges();
                MessageBox.Show("Данные успешно обновлены!", "У тебя получилось!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Логин должен быть обязательно, иначе как ты входить будешь?",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btneditpass_Click(object sender, RoutedEventArgs e)
        {
            var window = new EditPassWindow();
            window.ShowDialog();
        }
    }
}
