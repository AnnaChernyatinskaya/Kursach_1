using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Kursach_1.Classes;
using Kursach_1.Migrations;


namespace Kursach_1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Users currentUser = null;
        public static ApplicationContext db = new ApplicationContext();
    }
}
