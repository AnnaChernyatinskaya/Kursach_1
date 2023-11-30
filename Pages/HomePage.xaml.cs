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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            
            famtext.Text = App.currentUser.surname;
            nametext.Text = App.currentUser.name;
            surnametext.Text = App.currentUser.middlename;
            teltext.Text = App.currentUser.teltphone;
            mailtext.Text = App.currentUser.email;
            logintext.Text = App.currentUser.login;
        }

        private void btnedit_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new EditHomePage());
        }
    }
}
