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
    /// Логика взаимодействия для AddRequestPage.xaml
    /// </summary>
    public partial class AddRequestPage : Page
    {
        DateTime date = DateTime.Now;
        //string now = date.Date.ToShortDateString();
        public AddRequestPage()
        {
            InitializeComponent();

            foreach (string row in App.db.Tema.OrderBy(p => p.Id).Select(p => p.name_tema))
                temaText.Items.Add(row);
            userNameText.Text += " " + App.currentUser.surname + " " + App.currentUser.name + " " + App.currentUser.middlename;
            
            string now = date.Date.ToShortDateString();
            dateText.Text = now;
        }

        private void btnAddReq_Click(object sender, RoutedEventArgs e)
        {
            if (temaText.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тему заявки!",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (discripText.Text == "")
            {
                MessageBox.Show("Введите описание",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Requests req = new Requests();
                req.UsersId = App.currentUser.Id;
                req.TemaId = temaText.SelectedIndex + 1;
                req.StatusId = 1;
                req.date_start = date;
                req.description = discripText.Text;
                App.db.Requests.Add(req);
                App.db.SaveChanges();

                MessageBox.Show("Заявка успешно добавлена",
                    "Ура!", MessageBoxButton.OK, MessageBoxImage.Information);

                FrameObj.frameMain.Navigate(new RequestPage());
            }
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            temaText.Text = "";
            discripText.Text = "";
        }
    }
}
