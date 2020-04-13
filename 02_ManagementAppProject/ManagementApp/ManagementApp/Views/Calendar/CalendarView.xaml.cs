﻿using System;
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

        private DateTime ActualDateTime { get; set; }


        private int QuantityOfDaysForActualMonth { get; set; }
        private DayOfWeek FirstDayOfTheMonth {get; set;}



        public CalendarView()
        {
            InitializeComponent();
            CreateCalendarGrid(DateTime.Now);
            SetMonthName(DateTime.Now);

        }

        private void CreateCalendarGrid(DateTime dateTime)
        {
            ActualDateTime = dateTime;
            DateTime firstDayOfTheMonthDateTime = new DateTime(ActualDateTime.Year, ActualDateTime.Month, 1);
            FirstDayOfTheMonth = firstDayOfTheMonthDateTime.DayOfWeek;
            QuantityOfDaysForActualMonth = DateTime.DaysInMonth(ActualDateTime.Year, ActualDateTime.Month);


            int f = (int)FirstDayOfTheMonth - 1;
            int days = QuantityOfDaysForActualMonth;
            for (int r = 1; r <= quantityOfRow; r++)
            {

                for (int c = 0; c < quantityOfColumns; c++)
                {
                    if (days != 0 && f <= c)
                    {  
                        DayFieldUserControl dayField = new DayFieldUserControl(firstDayOfTheMonthDateTime, GetPointsForDate(firstDayOfTheMonthDateTime));
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
        private void SetMonthName(DateTime dateTime)
        {
            MonthName.Text = dateTime.ToString("MMMM  yyyy");
        }
 
        private ObservableCollection<Model.Point> GetPointsForDate(DateTime dateTime)
        {
            ObservableCollection<Model.Point> pointsForDate = new ObservableCollection<Model.Point>();

            foreach (var item in AppControler.CalendarPointListSource)
            {
                if (item.DeadLineDate.Value.Day == dateTime.Day &&
                   item.DeadLineDate.Value.Month == dateTime.Month &&
                   item.DeadLineDate.Value.Year == dateTime.Year)
                {
                    pointsForDate.Add(item);
                }
            }

            return pointsForDate;
        }



        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime newdateTime;
            if (ActualDateTime.Month < 12)
            {
                newdateTime = new DateTime(ActualDateTime.Year, ActualDateTime.Month + 1, ActualDateTime.Day);
            }
            else
            {
                newdateTime = new DateTime(ActualDateTime.Year +1, 1, ActualDateTime.Day);
            }
                    
            CreateCalendarGrid(newdateTime);
            SetMonthName(newdateTime);
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime newdateTime;
            if (ActualDateTime.Month > 1)
            {
                newdateTime = new DateTime(ActualDateTime.Year, ActualDateTime.Month - 1, ActualDateTime.Day);
            }
            else
            {
                newdateTime = new DateTime(ActualDateTime.Year - 1, 12, ActualDateTime.Day);
            }

            CreateCalendarGrid(newdateTime);
            SetMonthName(newdateTime);
        }
    }
}
