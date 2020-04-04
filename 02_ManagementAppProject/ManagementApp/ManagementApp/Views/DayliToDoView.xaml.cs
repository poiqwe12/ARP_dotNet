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

namespace ManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy DayliToDoView.xaml
    /// </summary>
    public partial class DayliToDoView : Page
    {
        public DayliToDoView()
        {
            InitializeComponent();
            DateTime date = DateTime.Now;
            Haeder.Text = "TO DO (" + date.ToShortDateString() + ")";

            DayliToDoList.ItemsSource = AppControler.dayliToDopointListSource;

        }

        // TODO: Dodać ContextMenu do DayliToDO 

    }
}
