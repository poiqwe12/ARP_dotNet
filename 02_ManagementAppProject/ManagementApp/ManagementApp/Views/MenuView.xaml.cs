using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ManagementApp.DataBase;
using ManagementApp.Controler;


namespace ManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MenuView.xaml
    /// </summary>
    /// 

    public partial class MenuView : Page 
    {
        private bool isMouseEnter;

        public MenuView()
        {
            InitializeComponent();
            //TreeViev_Menu.ItemsSource = AppControler.menuTreeSource;
        }


        //Kontrola czy mysz jest nad menu:
        private void TreeViev_Menu_MouseEnter(object sender, MouseEventArgs e)
        {
            isMouseEnter = true;
        }
        private void TreeViev_Menu_MouseLeave(object sender, MouseEventArgs e)
        {
            isMouseEnter = false;
        }



        private void TreeViev_Menu_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            if (isMouseEnter) //Zabezpieczenie przed wywołaniem w czasie zmian
            {

                if (TreeViev_Menu.SelectedItem.ToString() == AppControler.TaskCollectionType) // Jeśli nie działą to przez funkcje ToString
                {
                    tekst.Text = AppControler.TaskCollectionType;
                    AppControler.ActualChosenTypeInMenu = AppControler.TaskCollectionType;
                    TaskCollection actualTaskCollection = new TaskCollection();
                    actualTaskCollection = (TaskCollection)TreeViev_Menu.SelectedItem;
                    AppControler.ActualChosenCollectionInMenu = actualTaskCollection.TaskCollection_ID;
                }
                else if (TreeViev_Menu.SelectedItem.GetType().ToString() == AppControler.TaskType) // Jeśli nie działą to przez funkcje ToString
                {
                    tekst.Text = AppControler.TaskType;
                    AppControler.ActualChosenTypeInMenu = AppControler.TaskType;
                    Task actualTask = new Task();
                    actualTask = (Task)TreeViev_Menu.SelectedItem;
                    AppControler.ActualChosenCollectionInMenu = actualTask.Collection_ID;
                    AppControler.ActualChosenTaskInMenu = actualTask.Task_ID;
                }
                else
                {
                    tekst.Text = AppControler.NullType;
                    AppControler.ActualChosenTypeInMenu = AppControler.NullType;
                    AppControler.ActualChosenCollectionInMenu = -1;
                    AppControler.ActualChosenTaskInMenu = -1;
                }
            }
            else tekst.Text = "Poza";

        }

        //Obsługa zdarzeń z paska zadań:
        private void AddCollectionButton_Click(object sender, RoutedEventArgs e)
        {
            Views.TaskCollectionAddWindow pointAddWindow = new Views.TaskCollectionAddWindow();
            pointAddWindow.Show();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Views.TaskAddWindow pointAddWindow = new Views.TaskAddWindow();
            pointAddWindow.Show();
        }
        private void AddPointButton_Click(object sender, RoutedEventArgs e)
        {
            Views.PointAddWindow pointAddWindow = new Views.PointAddWindow();
            pointAddWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TreeViev_Menu.ItemsSource = AppControler.menuTreeSource;
        }
        /******************************/

        // TODO: Dodać funkcje do pasków w menu
        // TODO: Okomentować bloki o takiej samej funkcjonalności
        // TODO: Spróbować stworzyć 3 poziomowe drzewko  w menu !!! 


        //Obsługa zdarzeń pochodzących od contextMenu:
        private void AddTaskCollectionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Views.TaskCollectionAddWindow pointAddWindow = new Views.TaskCollectionAddWindow();
            pointAddWindow.Show();
        }
        private void AddTaskMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Views.TaskAddWindow pointAddWindow = new Views.TaskAddWindow();
            pointAddWindow.Show();
        }
        private void DeleteCollectionMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditCollectionMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPointMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Views.PointAddWindow pointAddWindow = new Views.PointAddWindow();
            pointAddWindow.Show();
        }

        private void DeleteTaskMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }


        private void EditTaskMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        //*******************************************/
    }
}
