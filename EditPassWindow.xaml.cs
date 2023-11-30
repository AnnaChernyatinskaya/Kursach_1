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
using System.Windows.Shapes;

namespace Kursach_1
{
    /// <summary>
    /// Логика взаимодействия для EditPassWindow.xaml
    /// </summary>
    public partial class EditPassWindow : Window
    {
        public EditPassWindow()
        {
            InitializeComponent();
            oldpass.Focus();
        }

        private void passsave_Click(object sender, RoutedEventArgs e)
        {
            if (oldpass.Password == "" || newpass.Password == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (oldpass.Password != App.currentUser.password)
            {
                MessageBox.Show("Старый пароль неверен!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                App.currentUser.password = newpass.Password;
                App.db.SaveChanges();
                MessageBox.Show("Пароль успешно изменен!", "У тебя получилось!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void oldpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                newpass.Focus();
            }
        }

        private void newpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                passsave_Click(sender, e);
            }
        }
    }
}
