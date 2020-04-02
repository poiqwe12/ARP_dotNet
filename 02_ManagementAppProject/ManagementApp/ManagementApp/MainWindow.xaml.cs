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

        private void AddPointButton_Click(object sender, RoutedEventArgs e)
        {
            Views.PointAddWindow pointAddWindow = new Views.PointAddWindow();
            pointAddWindow.Show();

        }
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Views.TaskAddWindow taskAddWindow = new Views.TaskAddWindow();
            taskAddWindow.Show();

        }
        private void AddCollectionButton_Click(object sender, RoutedEventArgs e)
        {
            Views.TaskCollectionAddWindow taskCollectionAddWindow = new Views.TaskCollectionAddWindow();
            taskCollectionAddWindow.Show();

        }
    }
}
