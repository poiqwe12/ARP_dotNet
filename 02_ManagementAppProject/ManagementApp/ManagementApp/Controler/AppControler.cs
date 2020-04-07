using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using ManagementApp.Model;




namespace ManagementApp.Controler
{

	// TODO: Zmienić drzewko menu na takie na bazie jednolitej struktury:
	public class MenuItem
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public int Id { get; set; }
		public ObservableCollection<MenuItem> Items { get; set; }

		public MenuItem(string newName, string newType, int newId)
		{
			Name = newName;
			Type = newType;
			Id = newId;
			this.Items = new ObservableCollection<MenuItem>();
		}
	}


	static public class AppControler
	{
		//Stałe:
		public const string TaskCollectionType = "TaskCollection";
		public const string TaskType = "Task";
		public const string PointType = "Point";
		public const string NullType = "Null";

		//Dane:
		static public int ActualChosenIdInMenu = -1;
		static public string ActualChosenTypeInMenu = NullType;

		static public ObservableCollection<MenuItem> menuTreeSource { get; set; }
		static public ObservableCollection<Model.Task> taskListSource { get; set; }
		static public ObservableCollection<Model.Point> pointListSource { get; set; }
		static public ObservableCollection<Model.Point> dayliToDopointListSource { get; set; }

		//Konstruktor statyczny:
		static AppControler()
		{
			menuTreeSource = new ObservableCollection<MenuItem>();
			taskListSource = new ObservableCollection<Model.Task>();
			pointListSource = new ObservableCollection<Model.Point>();
			dayliToDopointListSource = new ObservableCollection<Point>();

			menuTreeSourceUpdate(); //Inicjalizacja menu
		}



		//Aktualizacja zasobów dla widoku:
		public static void menuTreeSourceUpdate()
		{
			menuTreeSource.Clear();

			foreach (var item1 in DataBase.GetCollectionsList())
			{
				MenuItem newCollectionItem = new MenuItem(item1.Name, TaskCollectionType, item1.Id);

				foreach (var item2 in DataBase.GetTasksList(item1.Id))
				{
					MenuItem newTaskItem = new MenuItem(item2.Name, TaskType, item2.Id);
					
					foreach (var item3 in DataBase.GetPointsList(item2.Id))
					{
						MenuItem newPointItem = new MenuItem(item3.Name, PointType, item3.Id);
						newTaskItem.Items.Add(newPointItem);
					}
					newCollectionItem.Items.Add(newTaskItem);
				}
				menuTreeSource.Add(newCollectionItem);
			}
		}

		public static void taskListSourceUpdate()
		{

		}
		public static void pointListSourceUpdate()
		{

		}

		// TODO: Poprawić dayliToDopointListSourceUpdate funkcje tak by dawała listę właściwych punktów:

		public static void dayliToDopointListSourceUpdate()
		{

		}
		/********************************/

		// TODO: Napisać testy jednostkowe do wszystkich funkcji komunikujących się z bazą danych!
		// TODO: Wdrożyć obsługę wyjątkuw dla wszystkich funkcji komunikujących się z bazą danych!

	}



}

