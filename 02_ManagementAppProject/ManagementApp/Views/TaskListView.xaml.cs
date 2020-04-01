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

namespace ManagementApp
{
    /// <summary>
    /// Logika interakcji dla klasy TaskListView.xaml
    /// </summary>
    public partial class TaskListView : Page
    {
        public List<Task> taskList = new List<Task>();
        public TaskListView()
        {

            InitializeComponent();
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());
            taskList.Add(new Task());

            ListView_TaskList.ItemsSource = taskList;


        }


    }
}
