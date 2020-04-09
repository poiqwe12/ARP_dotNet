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

using ManagementApp.Model;
using ManagementApp.Controler;
using System.Windows.Threading;

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
            ListView_TasksList.ItemsSource = AppControler.TaskListSource;

            //DispatcherTimer start
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_ListUpdate);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Start();

        }

        private void DispatcherTimer_ListUpdate(object sender, EventArgs e)
        {
            Description.Content = AppControler.ActualDescriptionSource;

            if (AppControler.ActualChosenTypeInMenu == AppControler.TaskCollectionType)
            {
                Model.TaskCollection taskCollection = DataBase.GetTaskCollection(AppControler.ActualChosenIdInMenu);
                TaskCollectionName.Content = taskCollection.Name;
            }
        }


    }
}
