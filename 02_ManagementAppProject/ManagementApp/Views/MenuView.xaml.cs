using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ManagementApp.Vievs
{
    /// <summary>
    /// Logika interakcji dla klasy MenuView.xaml
    /// </summary>
    public partial class MenuView : Page
    {
        public MenuView()
        {
            InitializeComponent();

            List<TaskCollection> taskCollectionsList = new List<TaskCollection>();
            TaskCollection taskCollection = new TaskCollection();
            Task task = new Task();
            Model.Point point = new Model.Point();
            Task task1 = new Task();
            Model.Point point1 = new Model.Point();
  
            task.Points.Add(point);
            taskCollection.Tasks.Add(task);
            task.Points.Add(point1);
            taskCollection.Tasks.Add(task1);
            taskCollectionsList.Add(taskCollection);
            taskCollectionsList.Add(taskCollection);

            TreeViev_Menu1.ItemsSource = taskCollectionsList;
        }
    }
}
