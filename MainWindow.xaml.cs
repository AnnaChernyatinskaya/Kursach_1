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
using Kursach_1.Pages;

namespace Kursach_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameObj.frameMain = myFrame;
            myFrame.Navigate(new AutorizationPage());
            
        }

        private void myFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (!myFrame.CanGoBack)
            {
                UserNameTxb.Text = "";
                UserNameTxb.Visibility = Visibility.Collapsed;
                goBack.Visibility = Visibility.Collapsed;
                userСheck.Visibility = Visibility.Collapsed;
                myRequest.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (App.currentUser != null)
                {
                    UserNameTxb.Text = "В системе Администратор";
                    UserNameTxb.Visibility = Visibility.Visible;
                    goBack.Visibility = Visibility.Visible;
                    if (App.currentUser.RoleId == 1)
                    {
                        userСheck.Visibility = Visibility.Visible;
                        myRequest.Content = "Просмотр заявок";
                        //myRequest.Visibility = Visibility.Visible;
                    }
                    else if (App.currentUser.RoleId == 2)
                    {
                        UserNameTxb.Text = "В системе пользователь: " + App.currentUser.Id;
                        userСheck.Visibility = Visibility.Collapsed;
                        myRequest.Content = "Мои заявки";
                        //myRequest.
                    }
                    myRequest.Visibility = Visibility.Visible;
                }
            }
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            if (myFrame.CanGoBack)
                myFrame.GoBack();
            else if (!myFrame.CanGoBack && App.currentUser != null)
            {
                App.currentUser = null;
            }
        }

        private void myRequest_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new RequestPage());
        }

        private void userСheck_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new ViewUsersPage());
            userСheck.Visibility = Visibility.Collapsed;
        }
    }
}
