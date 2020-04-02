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


namespace ManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MenuView.xaml
    /// </summary>
    /// 

    public partial class MenuView : Page
    {
        public MenuView()
        {
            InitializeComponent();
           // TreeViev_Menu.ItemsSource = taskCollectionsList;
        }


        private void TreeViev_Menu_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if(TreeViev_Menu.SelectedItem.GetType().ToString() == "ManagementApp.Model.TaskCollection")
            {
                tekst.Text = TreeViev_Menu.SelectedItem.ToString();

            }
            else if (TreeViev_Menu.SelectedItem.ToString() == "ManagementApp.Model.Task")
            {
                tekst.Text = TreeViev_Menu.SelectedItem.GetType().ToString();
            }
        }

        private void AddCollectionButton_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddPointButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
