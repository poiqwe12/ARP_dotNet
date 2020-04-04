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
        public MenuView()
        {
            InitializeComponent();
            TreeViev_Menu.ItemsSource = AppControler.menuTreeSource;
        }


        private void TreeViev_Menu_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {/*
            if(TreeViev_Menu.SelectedItem.GetType().ToString() == "ManagementApp.DataBase.Collection")
            {
                tekst.Text = TreeViev_Menu.SelectedItem.GetType().ToString();

            }
            else if (TreeViev_Menu.SelectedItem.GetType().ToString() == "ManagementApp.Model.Task")
            {
                tekst.Text = TreeViev_Menu.SelectedItem.GetType().ToString();
            }
            */
        }

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
            TreeViev_Menu.ItemsSource = AppControler.menuTreeSource;
        }
    }
}
