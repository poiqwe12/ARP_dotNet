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

using ManagementApp.Model;
using ManagementApp.Controler;


namespace ManagementApp.Views
{
    public partial class MenuView : Page 
    {
        public MenuView()
        {
            InitializeComponent();
            TreeViewMenu.ItemsSource = AppControler.MenuTreeSource;
        }

        /*
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
            TreeViewMenu.ItemsSource = AppControler.menuTreeSource;
        }
        /******************************/

        //Określenie typu i Id wybranego z menu elementu
        private void TreeViewMenu_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
                Controler.MenuItem selectedItem = (Controler.MenuItem)TreeViewMenu.SelectedItem;
            if (selectedItem != null)
            {
                AppControler.ActualChosenTypeInMenu = selectedItem.Type;
                AppControler.ActualChosenIdInMenu = selectedItem.Id;

                if (selectedItem.Type == AppControler.TaskCollectionType)
                {
                    tekst.Text = AppControler.TaskCollectionType; // Tylko do testów

                }
                else if (selectedItem.Type == AppControler.TaskType)
                {
                    tekst.Text = AppControler.TaskType; // Tylko do testów
                }
                else if (selectedItem.Type == AppControler.PointType)
                {
                    tekst.Text = AppControler.PointType; // Tylko do testów
                }
                else
                {
                    tekst.Text = AppControler.NullType;
                    AppControler.ActualChosenTypeInMenu = AppControler.NullType;
                    AppControler.ActualChosenIdInMenu = -1;
                }
            }
        }
        //*********************************************/


        //Obsługa zdarzeń pochodzących od contextMenu:
        private void AddTaskCollectionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Views.TaskCollectionAddWindow taskCollectionAddWindow = new Views.TaskCollectionAddWindow();
            taskCollectionAddWindow.Show();
        }

        private void TreeContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            ContextMenu contextMenu = (ContextMenu)sender;
            contextMenu.Items.Clear();

            System.Windows.Controls.MenuItem newAddMenuItem = new System.Windows.Controls.MenuItem();
            System.Windows.Controls.MenuItem newDeleteMenuItem = new System.Windows.Controls.MenuItem();
            System.Windows.Controls.MenuItem newEditMenuItem = new System.Windows.Controls.MenuItem();

            newAddMenuItem.Name = "AddMenuItem";
            newAddMenuItem.Click += AddMenuItem_Click;

            newDeleteMenuItem.Name = "DeleteMenuItem";
            newDeleteMenuItem.Click += DeleteMenuItem_Click;

            newEditMenuItem.Name = "EditMenuItem";
            newEditMenuItem.Click += EditMenuItem_Click;

            if (AppControler.ActualChosenTypeInMenu == AppControler.TaskCollectionType)
            {
                newAddMenuItem.Header = "Dodaj zadanie";
                newDeleteMenuItem.Header = "Usuń kolekcje";
                newEditMenuItem.Header = "Edytuj kolekcje";

                contextMenu.Items.Add(newAddMenuItem);
                contextMenu.Items.Add(newDeleteMenuItem);
                contextMenu.Items.Add(newEditMenuItem);

            }
            else if (AppControler.ActualChosenTypeInMenu == AppControler.TaskType)
            {
                newAddMenuItem.Header = "Dodaj punkt";
                newDeleteMenuItem.Header = "Usuń zadanie";
                newEditMenuItem.Header = "Edytuj zadanie";

                contextMenu.Items.Add(newAddMenuItem);
                contextMenu.Items.Add(newDeleteMenuItem);
                contextMenu.Items.Add(newEditMenuItem);
            }
            else if (AppControler.ActualChosenTypeInMenu == AppControler.PointType)
            {
                newDeleteMenuItem.Header = "Usuń punkt";
                newEditMenuItem.Header = "Edytuj punkt";

                contextMenu.Items.Add(newDeleteMenuItem);
                contextMenu.Items.Add(newEditMenuItem);
            }
        }

        private void AddMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (AppControler.ActualChosenTypeInMenu == AppControler.TaskCollectionType)
            {
                Views.TaskAddWindow taskAddWindow = new Views.TaskAddWindow(AppControler.ActualChosenIdInMenu);
                taskAddWindow.Show();
            }
            else if (AppControler.ActualChosenTypeInMenu == AppControler.TaskType)
            {
                Views.PointAddWindow pointAddWindow = new Views.PointAddWindow(AppControler.ActualChosenIdInMenu);
                pointAddWindow.Show();
            }
            else if (AppControler.ActualChosenTypeInMenu == AppControler.PointType)
            {
                return;
            }
        }
        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (AppControler.ActualChosenTypeInMenu == AppControler.TaskCollectionType)
            {
                DataBase.DeleteCollection(AppControler.ActualChosenIdInMenu);
            }
            else if (AppControler.ActualChosenTypeInMenu == AppControler.TaskType)
            {
                DataBase.DeleteTask(AppControler.ActualChosenIdInMenu);
            }
            else if (AppControler.ActualChosenTypeInMenu == AppControler.PointType)
            {
                DataBase.DeletePoint(AppControler.ActualChosenIdInMenu);
            }
            AppControler.MenuTreeSourceUpdate();
        }
        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (AppControler.ActualChosenTypeInMenu == AppControler.TaskCollectionType)
            {
                Views.TaskCollectionEditWindow taskCollectionEditWindow = new Views.TaskCollectionEditWindow(AppControler.ActualChosenIdInMenu);
                taskCollectionEditWindow.Show();
            }
            else if (AppControler.ActualChosenTypeInMenu == AppControler.TaskType)
            {
                Views.TaskEditWindow taskEditWindow = new Views.TaskEditWindow(AppControler.ActualChosenIdInMenu);
                taskEditWindow.Show();
            }
            else if (AppControler.ActualChosenTypeInMenu == AppControler.PointType)
            {
                Views.PointEditWindow pointEditWindow = new Views.PointEditWindow(AppControler.ActualChosenIdInMenu);
                pointEditWindow.Show();
            }
            AppControler.MenuTreeSourceUpdate();
        }
        //*******************************************/
    }
}
