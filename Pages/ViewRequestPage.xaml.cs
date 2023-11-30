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
    /// Логика взаимодействия для ViewRequestPage.xaml
    /// </summary>
    public partial class ViewRequestPage : Page
    {
        Requests updateRequest;
        DateTime date = DateTime.Now;

        public ViewRequestPage()
        {
            InitializeComponent();
        }

        public ViewRequestPage(int index)
        {
            InitializeComponent();

            if (App.currentUser.RoleId == 2)
            {
                btnStart.Visibility = Visibility.Collapsed;
                btnFinish.Visibility = Visibility.Collapsed;
            }

            Requests req = App.db.Requests.Where(p => p.Id == index).FirstOrDefault();

            this.Title += req.Id;

            updateRequest = req;
            App.db.Entry(req).Reference(t => t.Users).Load();
            App.db.Entry(req).Reference(t => t.Tema).Load();
            App.db.Entry(req).Reference(r => r.Status).Load();
            userNameText.Text = req.Users.surname + " " + req.Users.surname + " " + req.Users.middlename;
            temaNameText.Text = req.Tema.name_tema;
            dateStartText.Text = req.date_start.Date.ToShortDateString();
            discripText.Text = req.description;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            
            updateRequest.StatusId = 2;
            App.db.SaveChanges();
            FrameObj.frameMain.Navigate(new RequestPage());
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            updateRequest.StatusId = 3;
            updateRequest.date_finish = date;
            App.db.SaveChanges();
            FrameObj.frameMain.Navigate(new RequestPage());
        }

        public string RequestUserString ()
        {
            Requests req = App.db.Requests.FirstOrDefault();
                App.db.Entry(req).Reference(r => r.Users).Load();
                return req.Users.surname + " " + req.Users.name + " " + req.Users.surname;
            
        }
    }
}
