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

using ManagementApp.Controler;
using ManagementApp.Model;

namespace ManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class PointEditWindow : Window
    {
        private readonly int point_Id;
        public PointEditWindow(int point_Id)
        {
            InitializeComponent();
            this.point_Id = point_Id;

            Model.Point editPoint = DataBase.GetPoint(point_Id);

            NameTextBox.Text = editPoint.Name;
            DayTextBox.Text = editPoint.DeadLineDate.Value.Day.ToString();
            MonthTextBox.Text = editPoint.DeadLineDate.Value.Month.ToString();
            YearTextBox.Text = editPoint.DeadLineDate.Value.Year.ToString();

        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime newDate;
            DateTime actulaData = DateTime.Now;

            if (NameTextBox.Text == "") //Jeśli pole puste
            {
                InformationText.Text = "Proszę uzupełnij nazwę zbioru.";
            }
            else if (DayTextBox.Text == "" || DayTextBox.Text == "" || YearTextBox.Text == "") //Jeśli którekolwiek pole puste
            {
                InformationText.Text = "Proszę uzupełnij  datę.";
            }
            else
            {
                //Sprawdzenie poprawności wprowadzonej daty:
                try
                {
                    newDate = new DateTime(Convert.ToInt32(YearTextBox.Text) + 2000, Convert.ToInt32(MonthTextBox.Text), Convert.ToInt32(DayTextBox.Text));
                }
                catch (Exception)
                {
                    InformationText.Text = "Proszę popraw datę.";
                    return;
                }
                if (newDate < actulaData)
                {
                    InformationText.Text = "Chcesz się cofnąć w czasie?";
                }
                else
                {
                    //Jeśli wszystko poszło dobrze to wysyłamy
                    Model.Point editPoint = DataBase.GetPoint(point_Id);
                    ManagementApp.Model.Point newPoint = new ManagementApp.Model.Point()
                    {
                        TaskId = editPoint.TaskId,
                        Name = NameTextBox.Text,
                        DeadLineDate = newDate,
                        ExecutionStatus = false
                    };

                    DataBase.ChangePointProperties(point_Id, newPoint);
                    AppControler.UpDateAllSource();
                    this.Close();
                }
            }

        }
    }
}
