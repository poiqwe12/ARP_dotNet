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
    /// Logika interakcji dla klasy ManagementViev.xaml
    /// </summary>
    public partial class ManagementView : Page
    {
        public ManagementView()
        {
            InitializeComponent();

            //DispatcherTimer start
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_ListUpdate);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        //Cykliczne przerwanie odświeżające okno z listami:
        private void dispatcherTimer_ListUpdate(object sender, EventArgs e)
        {
            TaskListToRender.Visibility = Visibility.Hidden;
            PoinListToRender.Visibility = Visibility.Hidden;
            if (AppControler.ActualChosenTypeInMenu == AppControler.TaskCollectionType)
            {
                TaskListToRender.Visibility = Visibility.Visible;
            }
            else if(AppControler.ActualChosenTypeInMenu == AppControler.TaskType)
            {
                PoinListToRender.Visibility = Visibility.Visible;
            }
        }


    }
}
