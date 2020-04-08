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
using ManagementApp.Model;
using ManagementApp.Controler;

namespace ManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy TaskCollectionAddWindow.xaml
    /// </summary>
    public partial class TaskCollectionEditWindow : Window
    {
        private readonly int taskCollection_Id;
        public TaskCollectionEditWindow(int taskCollection_Id)
        {
            InitializeComponent();
            this.taskCollection_Id = taskCollection_Id;
            Model.TaskCollection editTaskCollection = DataBase.GetTaskCollection(taskCollection_Id);

            NameTextBox.Text = editTaskCollection.Name;
            DescriptionTextBox.Text = editTaskCollection.Description;

        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameTextBox.Text == "") //Jeśli puste pole
            {
                InformationText.Text = "Proszę uzupełnij nazwę zbioru.";
            }
            else
            {
                TaskCollection newTaskCollection = new TaskCollection()
                {
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text
                };

                DataBase.ChangeCollectionProperties(taskCollection_Id, newTaskCollection);
                AppControler.MenuTreeSourceUpdate();
                this.Close();
            }
        }
    }
}
