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
using System.Windows.Threading;
using ManagementApp.Controler;
using ManagementApp.Model;

namespace ManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy PointListView.xaml
    /// </summary>
    public partial class PointListView : Page
    {
        public PointListView()
        {
            InitializeComponent();

            ListView_PointsList.ItemsSource = AppControler.PointListSource;


            //DispatcherTimer start
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_ListUpdate);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Start();

        }

        private void DispatcherTimer_ListUpdate(object sender, EventArgs e)
        {
            Description.Content = AppControler.ActualDescriptionSource;
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in AppControler.PointListSource)
            {
                DataBase.ChangePointProperties(item.Id, item);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in AppControler.PointListSource)
            {
                DataBase.ChangePointProperties(item.Id, item);
            }
        }

        private void AddToDayliToDo_Click(object sender, RoutedEventArgs e)
        {
            Model.Point point = (Model.Point)ListView_PointsList.SelectedItem;
            if (point != null)
            {
                point.IsTaskForToday = !point.IsTaskForToday;

                DataBase.ChangePointProperties(point.Id, point);
                AppControler.UpDateListSource();
            }
        }

        private void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            Model.Point point = (Model.Point)ListView_PointsList.SelectedItem;
            if (point != null)
            {
                if (point.IsTaskForToday == false)
                {
                    AddToDayliToDo.Header = "Dodaj zadanie do dzisiejszego TO DO";
                }
                if (point.IsTaskForToday == true)
                {
                    AddToDayliToDo.Header = "Usuń zadanie z dzisiejszego TO DO";
                }
            }
        }
    }
}
