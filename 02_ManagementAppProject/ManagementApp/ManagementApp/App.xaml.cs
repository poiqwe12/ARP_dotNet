﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementApp
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        static public MainWindow mainWindow = new MainWindow();
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            mainWindow.Show();
        }

    }
}
