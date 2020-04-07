using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
		static public int ActualChosenCollectionInMenu = -1;
		static public int ActualChosenTaskInMenu = -1;
		static public string ActualChosenTypeInMenu = NullType;


		static public ObservableCollection<Task> taskListSource { get; set; }
		static public ObservableCollection<Point> pointListSource { get; set; }
		static public ObservableCollection<Point> dayliToDopointListSource { get; set; }

		//Konstruktor statyczny:
		static AppControler()
		{
			ObservableCollection<Task> taskListSource = new ObservableCollection<Task>();
			ObservableCollection<Point> pointListSource = new ObservableCollection<Point>();
			ObservableCollection<Point> dayliToDopointListSource = new ObservableCollection<Point>();

		}

		//Konwersja typów:
		public static ObservableCollection<TaskCollection> ConvertListToObservableCollection_TaskCollection(List<TaskCollection> taskCollectionsToConvert)
		{
			ObservableCollection<TaskCollection> newTaskObservableCollections = new ObservableCollection<TaskCollection>();
			foreach (var item in taskCollectionsToConvert)
			{
				newTaskObservableCollections.Add(item);
			}
			return newTaskObservableCollections;
		}

		public static ObservableCollection<Task> ConvertListToObservableCollection_Task(List<Task> taskToConvert)
		{
			ObservableCollection<Task> newTaskObservableCollections = new ObservableCollection<Task>();
			foreach (var item in taskToConvert)
			{
				newTaskObservableCollections.Add(item);
			}
			return newTaskObservableCollections;
		}

		public static ObservableCollection<Point> ConvertListToObservableCollection_Point(List<Point> pointToConvert)
		{
			ObservableCollection<Point> newPointObservableCollections = new ObservableCollection<Point>();
			foreach (var item in pointToConvert)
			{
				newPointObservableCollections.Add(item);
			}
			return newPointObservableCollections;
		}
		/***************/

		//Aktualizacja zasobów dla widoku:
		public static void menuTreeSourceUpdate()
		{
		}
		public static void taskListSourceUpdate()
		{
			//Trzeba wyczyścić i przepisać element po elemenci, żeby sama lista pozostała tą samą. 
			//Inaczej źródło się zmieni i nie będzie widać zmian!
			ObservableCollection<Task> newTaskListSource = AppControler.ConvertListToObservableCollection_Task(AppControler.GetTasksList());
			taskListSource.Clear();
			foreach (var item in newTaskListSource)
			{
				taskListSource.Add(item);
			}
		}
		public static void pointListSourceUpdate()
		{
			//Trzeba wyczyścić i przepisać element po elemenci, żeby sama lista pozostała tą samą. 
			//Inaczej źródło się zmieni i nie będzie widać zmian!
			ObservableCollection<Point> newPointListSource = AppControler.ConvertListToObservableCollection_Point(AppControler.GetPointsList());
			pointListSource.Clear();
			foreach (var item in newPointListSource)
			{
				pointListSource.Add(item);
			}
		}

		// TODO: Poprawić dayliToDopointListSourceUpdate funkcje tak by dawała listę właściwych punktów:

		public static void dayliToDopointListSourceUpdate()
		{
			//Trzeba wyczyścić i przepisać element po elemenci, żeby sama lista pozostała tą samą. 
			//Inaczej źródło się zmieni i nie będzie widać zmian!
			ObservableCollection<Point> newPointListSource = AppControler.ConvertListToObservableCollection_Point(AppControler.GetPointsList());
			dayliToDopointListSource.Clear();
			foreach (var item in newPointListSource)
			{
				dayliToDopointListSource.Add(item);
			}
		}
		/********************************/

		// TODO: Poprawić dodawanie tak by generowany był niepowtażalny klucz własny! Teraz  chyba się nie generuje!
		// TODO: Napisać testy jednostkowe do wszystkich funkcji komunikujących się z bazą danych!
		// TODO: Wdrożyć obsługę wyjątkuw dla wszystkich funkcji komunikujących się z bazą danych!
		// TODO: Poprawić funkcje tak by zwracały właściwe zbiory danych...

	}



}

