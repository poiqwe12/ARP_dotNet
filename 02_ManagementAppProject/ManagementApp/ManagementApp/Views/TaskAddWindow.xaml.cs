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

using ManagementApp.DataBase;
using ManagementApp.Controler;

namespace ManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy TaskAddWindow.xaml
    /// </summary>
    public partial class TaskAddWindow : Window
    {
        public TaskAddWindow()
        {
            InitializeComponent();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
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
                    newDate = new DateTime(Convert.ToInt32(YearTextBox.Text)+2000, Convert.ToInt32(MonthTextBox.Text), Convert.ToInt32(DayTextBox.Text));
                }
                catch (Exception)
                {
                    InformationText.Text = "Proszę popraw datę.";
                    return;
                }
                 if (newDate < actulaData)
                 {
                    InformationText.Text = "Chcesz się cofnąć w czasie?" ;
                 }
                 else
                 {
                    //Jeśli wszystko poszło dobrze to wysyłamy
                    ManagementApp.DataBase.Task newTask = new ManagementApp.DataBase.Task()
                    {
                        Collection_ID = 1,
                        Task_ID = 1 + DateTime.Now.Millisecond,
                        TaskName = NameTextBox.Text,
                        DeadLine = newDate,
                        Description = DescriptionTextBox.Text
                    };

                    AppControler.AddTask(newTask);
                    this.Close();
                }

            }

        }
    }
}
