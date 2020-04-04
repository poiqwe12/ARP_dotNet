using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ManagementApp.DataBase;
using ManagementApp.Controler;


namespace ManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy TaskListView.xaml
    /// </summary>
    public partial class TaskListView : Page
    {

        public TaskListView()
        {

            InitializeComponent();
            ListView_TasksList.ItemsSource = AppControler.taskListSource;
        }


    }
}
