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
    /// Логика взаимодействия для RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        //private List<Requests> _request = new List<Requests>();

        public RequestPage()
        {
            InitializeComponent();

            if (App.currentUser.RoleId == 1)
            {
                this.Title = "Просмотр заявок";
                btnAddReq.Visibility = Visibility.Collapsed;
                dataGridRequests.ItemsSource = App.db.Requests.OrderBy(p => p.Id).ToList();
            }
            else if (App.currentUser.RoleId == 2)
            {
                this.Title = "Мои заявки";
                btnAddReq.Visibility = Visibility.Visible;
                dataGridRequests.ItemsSource = App.db.Requests.Where(p => p.UsersId == App.currentUser.Id).ToList();
            }
            
        }

        //public RequestPage(List<Requests> requests)
        //{
            //InitializeComponent();
            //dataGridRequests.ItemsSource = requests;
            //foreach (var p in requests.OrderBy(p => p.Id).Distinct())
            //{

            //}
        //}

        private void btnAddReq_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new AddRequestPage());
        }

        private void btnViewReq_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridRequests.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите заявку, которую хотите просмотреть", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var row = dataGridRequests.SelectedItem as Requests;
                int result = row.Id;
                FrameObj.frameMain.Navigate(new ViewRequestPage(result));
            }
        }

        

    }
}
