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

        private int actualMonth;
        private int ActualMonth
        {
            get { return actualMonth; }
            set
            {
                if (value > 0 && value <= 12)
                {
                    actualMonth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Corect value is 1 to 12.");
                }
            }
        }

        private int QuantityOfDaysForActualMonth { get; set; }
        private DayOfWeek FirstDayOfTheMonth {get; set;}



        public CalendarView()
        {
            InitializeComponent();
            CreateCalendarGrid(DateTime.Now);


        }

        private void CreateCalendarGrid(DateTime dateTime)
        {
            DateTime actualDateTime = dateTime;
            ActualMonth = actualDateTime.Month;
            DateTime firstDayOfTheMonthDateTime = new DateTime(actualDateTime.Year, actualDateTime.Month, 1);
            FirstDayOfTheMonth = firstDayOfTheMonthDateTime.DayOfWeek;
            QuantityOfDaysForActualMonth = DateTime.DaysInMonth(actualDateTime.Year, ActualMonth);


            int f = (int)FirstDayOfTheMonth - 1;
            int days = QuantityOfDaysForActualMonth;
            for (int r = 0; r < quantityOfRow; r++)
            {

                for (int c = 0; c < quantityOfColumns; c++)
                {
                    if (days != 0 && f <= c)
                    {
                        DayFieldUserControl dayField = new DayFieldUserControl(firstDayOfTheMonthDateTime, AppControler.DayliToDopointListSource);
                        Grid.SetColumn(dayField, c);
                        Grid.SetRow(dayField, r);
                        CalendarGrid.Children.Add(dayField);
                        firstDayOfTheMonthDateTime = firstDayOfTheMonthDateTime.AddDays(1);
                        days--;
                    }
                    else
                    {
                        DayFieldUserControl dayField = new DayFieldUserControl();
                        Grid.SetColumn(dayField, c);
                        Grid.SetRow(dayField, r);
                        CalendarGrid.Children.Add(dayField);
                    }

                }
                f = 0;
            }
        }

    }
}
