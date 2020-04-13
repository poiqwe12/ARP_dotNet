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
using System.Collections.ObjectModel;
using ManagementApp.Model;


namespace ManagementApp.Views.Calendar
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class DayFieldUserControl : UserControl
    {
        private  DateTime date { get; }
        private ObservableCollection<Model.Point> PointListSourse { get; }
        private bool IsActive { get; }
        private bool IsDayPassed { get; }


        public DayFieldUserControl(DateTime dataForNewDay, ObservableCollection<Model.Point> pointListSourse)
        {
            InitializeComponent();
            date = dataForNewDay;
            NumberOfDay.Text = date.Day.ToString();
            PointListSourse = pointListSourse;
            PointList.ItemsSource = PointListSourse;
            //RoutinList
                   
            IsActive = true;

            if (dataForNewDay.Day < DateTime.Now.Day && dataForNewDay.Month <= DateTime.Now.Month && dataForNewDay.Year <= DateTime.Now.Year)
            {
                DayField.Background = new SolidColorBrush(Colors.Gray);
            }
            else
            {
                if (dataForNewDay.Day == DateTime.Now.Day && dataForNewDay.Month == DateTime.Now.Month && dataForNewDay.Year == DateTime.Now.Year)
                {
                    Thickness thickness = new Thickness(3);
                    DayField.BorderThickness = thickness;
                }
                DayField.Background = new SolidColorBrush(Colors.Silver);
            }
        }
        public DayFieldUserControl()
        {
            InitializeComponent();

            NumberOfDay.Text = "";

            DayField.Background = new SolidColorBrush(Colors.Gray);
            IsActive = false;
        }

        private void DayField_Click(object sender, RoutedEventArgs e)
        {
            if (IsActive)
            {
                DayFieldMaximizedWindow dayFieldMaximizedWindow = new DayFieldMaximizedWindow(date, PointListSourse);
                dayFieldMaximizedWindow.Show();
            }
        }
    }
}
