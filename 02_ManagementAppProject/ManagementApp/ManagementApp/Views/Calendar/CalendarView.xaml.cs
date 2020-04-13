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
using ManagementApp.Views.Calendar;
using ManagementApp.Controler;

namespace ManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy CalendarView.xaml
    /// </summary>
    public partial class CalendarView : Page
    {
        private const int quantityOfColumns = 7;
        private const int quantityOfRow = 6;
        public CalendarView()
        {
            InitializeComponent();
          

            for (int r = 0; r < quantityOfRow; r++)
            {
                for (int c = 0; c < quantityOfColumns; c++)
                {
                    DayFieldUserControl dayField = new DayFieldUserControl(DateTime.Now, AppControler.DayliToDopointListSource);
                    Grid.SetColumn(dayField, c);
                    Grid.SetRow(dayField, r);
                    CalendarGrid.Children.Add(dayField);  
                }
            }
        }
    }
}
