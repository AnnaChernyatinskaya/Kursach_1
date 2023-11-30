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
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        Users userSelect;

        public EditUserPage()
        {
            InitializeComponent();
        }

        public EditUserPage(int index)
        {
            InitializeComponent();

            Users use = App.db.User.Where(p => p.Id == index).FirstOrDefault();

            userSelect = use;
            nameText.Text = use.name;
            fioText.Text = use.surname; ;
            surText.Text = use.middlename;
            telText.Text = use.teltphone;
            emailText.Text = use.email;
            logText.Text = use.login;
            passText.Text = use.password;
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (logText.Text == "" || passText.Text == "")
            {
                MessageBox.Show("Логин и пароль должены быть обязательно, иначе как пользователь будет входить?",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                userSelect.name = nameText.Text;
                userSelect.surname = fioText.Text;
                userSelect.middlename = surText.Text;
                userSelect.teltphone = telText.Text;
                userSelect.email = emailText.Text;
                userSelect.login = logText.Text;
                userSelect.password = passText.Text;

                App.db.SaveChanges();

                MessageBox.Show("Данные успешно обновлены!",
                    "Ура!", MessageBoxButton.OK, MessageBoxImage.Information);

                FrameObj.frameMain.Navigate(new ViewUsersPage());
                //EditUserPage();
            }
        }
    }
}
