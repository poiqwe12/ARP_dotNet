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

using ManagementApp.Controler;
using ManagementApp.DataBase;

namespace ManagementApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MiddleFieldView.Source = new Uri("Views/ManagementView.xaml", UriKind.Relative);
            AddDataBaseComponentForTest();
        }

        
        private void AddDataBaseComponentForTest()
        {
            TaskCollection taskCollection1 = new TaskCollection()
            {
                Name = "Kolekcja do testów",
                Description = "Jakiś przykładowy opis utworzony na potrzeby testów. Piszę dalej bo musi być długi i najlepiej taki, żeby się zawijał w" +
                "oknie do tego przeznaczonym."
            };
            TaskCollection taskCollection2 = new TaskCollection()
            {
                Name = "Kolekcja do testów",
                Description = "Jakiś przykładowy opis utworzony na potrzeby testów. Piszę dalej bo musi być długi i najlepiej taki, żeby się zawijał w" +
                "oknie do tego przeznaczonym."
            };
            DateTime date = DateTime.Now;
            date.AddYears(21);

            DataBase.Task task1 = new DataBase.Task()
            {
                TaskName = "Nowe zadanie",
                Task_ID = 1,
                Collection_ID = 1,
                DeadLine = date,
                Completion = date,
                Description = "Jakiś przykładowy opis utworzony na potrzeby testów. Piszę dalej bo musi być długi i najlepiej taki, żeby się zawijał w" +
                "oknie do tego przeznaczonym.",
                Percenttarget = 50
            };
            DataBase.Task task2 = new DataBase.Task()
            {
                TaskName = "Nowe zadanie",
                Task_ID = 2,
                Collection_ID = 1,
                DeadLine = date,
                Completion = date,
                Description = "Jakiś przykładowy opis utworzony na potrzeby testów. Piszę dalej bo musi być długi i najlepiej taki, żeby się zawijał w" +
                "oknie do tego przeznaczonym.",
                Percenttarget = 20
            };
            DataBase.Task task3 = new DataBase.Task()
            {
                TaskName = "Nowe zadanie",
                Task_ID = 3,
                Collection_ID = 2,
                DeadLine = date,
                Completion = date,
                Description = "Jakiś przykładowy opis utworzony na potrzeby testów. Piszę dalej bo musi być długi i najlepiej taki, żeby się zawijał w" +
                "oknie do tego przeznaczonym.",
                Percenttarget = 40
            };
            DataBase.Task task4 = new DataBase.Task()
            {
                TaskName = "Nowe zadanie",
                Task_ID = 4,
                Collection_ID = 2,
                DeadLine = date,
                Completion = date,
                Description = "Jakiś przykładowy opis utworzony na potrzeby testów. Piszę dalej bo musi być długi i najlepiej taki, żeby się zawijał w" +
                "oknie do tego przeznaczonym.",
                Percenttarget = 70
            };

            DataBase.Point point1 = new DataBase.Point()
            {
                Name = "Nowy punkt",
                Task_ID = 1,
                Point_ID = 1,
                DeadLineDate = date,
                CompletionDate = date,
                TaskForToday = true
            };
            DataBase.Point point2 = new DataBase.Point()
            {
                Name = "Nowy punkt",
                Task_ID = 2,
                Point_ID = 2,
                DeadLineDate = date,
                CompletionDate = date,
                TaskForToday = true
            };
            DataBase.Point point3 = new DataBase.Point()
            {
                Name = "Nowy punkt",
                Task_ID = 3,
                Point_ID = 3,
                DeadLineDate = date,
                CompletionDate = date,
                TaskForToday = true
            };
            DataBase.Point point4 = new DataBase.Point()
            {
                Name = "Nowy punkt",
                Task_ID = 4,
                Point_ID = 4,
                DeadLineDate = date,
                CompletionDate = date,
                TaskForToday = true
            };


            AppControler.AddCollection(taskCollection1);
            AppControler.AddCollection(taskCollection1);
            AppControler.AddTask(task1);
            AppControler.AddTask(task2);
            AppControler.AddTask(task3);
            AppControler.AddTask(task4);
            AppControler.AddPoint(point1);
            AppControler.AddPoint(point2);
            AppControler.AddPoint(point3);
            AppControler.AddPoint(point4);

        }
        


        private void ManagementViewButton_Click(object sender, RoutedEventArgs e)
        {
            MiddleFieldView.Source = new Uri("Views/ManagementView.xaml", UriKind.Relative);
        }

        private void CalendarViewButton_Click(object sender, RoutedEventArgs e)
        {
            MiddleFieldView.Source = new Uri("Views/CalendarView.xaml", UriKind.Relative);
        }

        private void StatisticsViewButton_Click(object sender, RoutedEventArgs e)
        {
            MiddleFieldView.Source = new Uri("Views/StatisticsView.xaml", UriKind.Relative);
        }

        private void OptionViewButton_Click(object sender, RoutedEventArgs e)
        {
            MiddleFieldView.Source = new Uri("Views/OptionView.xaml", UriKind.Relative);
        }
    }
}
