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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ManagementApp.Views.Calendar
{
    /// <summary>
    /// Logika interakcji dla klasy DayFieldMaximized.xaml
    /// </summary>
    public partial class DayFieldMaximizedWindow : Window
    {
        public DayFieldMaximizedWindow(DateTime dateForNewDay, ObservableCollection<Model.Point> pointListSourse)
        {
            InitializeComponent();
            NumberOfDay.Text = dateForNewDay.ToShortDateString();
            PointList.ItemsSource = pointListSourse;
            //RoutinList
        }
    }
}
