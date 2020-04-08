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

		static public string ActualDescriptionSource { get; set; }

		static public ObservableCollection<MenuItem> MenuTreeSource { get; set; }
		static public ObservableCollection<Model.Task> TaskListSource { get; set; }
		static public ObservableCollection<Model.Point> PointListSource { get; set; }
		static public ObservableCollection<Model.Point> DayliToDopointListSource { get; set; }

		//Konstruktor statyczny:
		static AppControler()
		{
			MenuTreeSource = new ObservableCollection<MenuItem>();
			TaskListSource = new ObservableCollection<Model.Task>();
			PointListSource = new ObservableCollection<Model.Point>();
			DayliToDopointListSource = new ObservableCollection<Point>();
			ActualDescriptionSource = "Opis:";

			UpDateAllSource();
		}

		//Aktualizacja zasobów dla widoku:
		public static void UpDateAllSource() //W przypadku Add, Edit itp.
		{
			MenuTreeSourceUpdate();
			TaskListSourceUpdate();
			PointListSourceUpdate();
		}

		public static void UpDateListSource() //W przypadku zmiany elementu
		{
			TaskListSourceUpdate();
			PointListSourceUpdate();
			ActualDescriptionSourceUpdate();
		}



		public static void MenuTreeSourceUpdate()
		{
			MenuTreeSource.Clear();

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
				MenuTreeSource.Add(newCollectionItem);
			}
		}

		public static void TaskListSourceUpdate()
		{
			if(ActualChosenTypeInMenu == AppControler.TaskCollectionType)
			{
				TaskListSource.Clear();
				foreach (var item in DataBase.GetTasksList(ActualChosenIdInMenu))
				{
					TaskListSource.Add(item);
				} 
			}
		}
		public static void PointListSourceUpdate()
		{
			if (ActualChosenTypeInMenu == AppControler.TaskType)
			{
				PointListSource.Clear();
				foreach (var item in DataBase.GetPointsList(ActualChosenIdInMenu))
				{
					PointListSource.Add(item);
				}
			}
			else if (ActualChosenTypeInMenu == AppControler.PointType)
			{
				Model.Point temporaryPoint = DataBase.GetPoint(ActualChosenIdInMenu);

				PointListSource.Clear();
				foreach (var item in DataBase.GetPointsList(temporaryPoint.TaskId))
				{
					PointListSource.Add(item);
				}
			}
		}

		public static void ActualDescriptionSourceUpdate()
		{
			if (ActualChosenTypeInMenu == AppControler.TaskCollectionType)
			{
				TaskCollection taskCollection = DataBase.GetTaskCollection(AppControler.ActualChosenIdInMenu);
				ActualDescriptionSource = taskCollection.Description;
			}
			else if (AppControler.ActualChosenTypeInMenu == AppControler.TaskType)
			{
				Model.Task task = DataBase.GetTask(AppControler.ActualChosenIdInMenu);
				ActualDescriptionSource = task.Description;
			}
			else if (ActualChosenTypeInMenu == AppControler.PointType)
			{
				Model.Point temporaryPoint = DataBase.GetPoint(ActualChosenIdInMenu);
				Model.Task task = DataBase.GetTask(temporaryPoint.TaskId);
				ActualDescriptionSource = task.Description;
			}
		}

		// TODO: Poprawić dayliToDopointListSourceUpdate funkcje tak by dawała listę właściwych punktów:

		public static void DayliToDopointListSourceUpdate()
		{

		}
		/********************************/

		// TODO: Napisać testy jednostkowe do wszystkich funkcji komunikujących się z bazą danych!
		// TODO: Wdrożyć obsługę wyjątkuw dla wszystkich funkcji komunikujących się z bazą danych!

	}



}

