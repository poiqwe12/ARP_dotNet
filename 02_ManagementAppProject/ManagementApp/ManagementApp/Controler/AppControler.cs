using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ManagementApp.DataBase;



namespace ManagementApp.Controler
{
	

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

		static public ObservableCollection<TaskCollection> menuTreeSource;
		static public ObservableCollection<Task> taskListSource;
		static public ObservableCollection<Point> pointListSource;

		//Konstruktor statyczny:
		static AppControler()
		{
			menuTreeSource = AppControler.ConvertListToObservableCollection_TaskCollection(AppControler.GetCollectionsList());
			taskListSource = AppControler.ConvertListToObservableCollection_Task(AppControler.GetTasksList());
			pointListSource = AppControler.ConvertListToObservableCollection_Point(AppControler.GetPointsList());
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
			//Trzeba wyczyścić i przepisać element po elemenci, żeby sama lista pozostała tą samą. 
			//Inaczej źródło się zmieni i nie będzie widać zmian!
			ObservableCollection<TaskCollection> newMenuTreeSource = AppControler.ConvertListToObservableCollection_TaskCollection(AppControler.GetCollectionsList());
			menuTreeSource.Clear();
			foreach (var item in newMenuTreeSource)
			{
				menuTreeSource.Add(item);
			}
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
		/********************************/

		// TODO: Poprawić dodawanie tak by generowany był niepowtażalny klucz własny! Teraz  chyba się nie generuje!
		
		//Dodawanie do bazy danych:
		public static void AddCollection(TaskCollection newCollection)
		{
			using (var context = new AppDataBase())
			{
				context.TaskCollection.Add(newCollection);
				context.SaveChanges();
			}
			menuTreeSourceUpdate(); //Aktualizacja menu
		}
		public static void AddTask(Task newTask)
		{
			using (var context = new AppDataBase())
			{
				context.Task.Add(newTask);
				context.SaveChanges();
			}
			menuTreeSourceUpdate(); //Aktualizacja menu
			taskListSourceUpdate(); //Aktualizacja menu i listy zadań
		}
		public static void AddPoint(Point newPoints)
		{
			using (var context = new AppDataBase())
			{
				context.Point.Add(newPoints);
				context.SaveChanges();
			}
		}
		/*************************/

		//Usuwanie z bazy danych:
		public static void DeleteCollection(int collection_ID)
		{
			using (var context = new AppDataBase())
			{
				var findedTaskCollection = context.TaskCollection.Where(s => s.TaskCollection_ID == collection_ID).FirstOrDefault<TaskCollection>();
				context.TaskCollection.Remove(findedTaskCollection);
				context.SaveChanges();
			}
		}

		/*
		 *  var student = ctx.Students
                  .Where(s => s.StudentName == name)
                  .FirstOrDefault<Student>()
		 */

		public static void DeleteTask(int collection_ID, int task_ID)
		{
			using (var context = new AppDataBase())
			{
				var findedTask = context.Task.Where(s => s.Task_ID == task_ID).FirstOrDefault<Task>();
				context.Task.Remove(findedTask);
				context.SaveChanges();
			}
		}
		public static void DeletePoint(int task_ID, int point_ID)
		{
			using(var context = new AppDataBase())
			{
				var findedPoint = context.Point.Where(s => s.Point_ID == point_ID).FirstOrDefault<Point>();
				context.Point.Remove(findedPoint);
				context.SaveChanges();


			}
		}
		/***********************/

		//Wprowadzanie zmian do elementów bazy danych:
		public static void ChangeCollectionProperties(int collection_ID, TaskCollection newCollection) //???
		{
			using (var context = new AppDataBase())
			{
				var findedTaskCollection = context.TaskCollection.Where(s => s.TaskCollection_ID == collection_ID).FirstOrDefault<TaskCollection>();		
				findedTaskCollection.Name = findedTaskCollection.Name;
				findedTaskCollection.Description = findedTaskCollection.Description;
				context.SaveChanges();
			}
		}

		public static void ChangeTaskProperties(int task_ID, Task newTask) //???
		{
			using (var context = new AppDataBase())
			{
				var findedTask = context.Task.Where(s => s.Task_ID == task_ID).FirstOrDefault<Task>();
				findedTask.Collection_ID = newTask.Collection_ID;
				findedTask.TaskName = newTask.TaskName;
				findedTask.Completion= newTask.Completion;
				findedTask.DeadLine = newTask.DeadLine;
				findedTask.Percenttarget = newTask.Percenttarget;
				findedTask.Description = newTask.Description;
				context.SaveChanges();
			}
		}
		public static void ChangePointProperties(int point_ID, Point newPoint)
		{
			using(var context = new AppDataBase())
			{
				var findedPoint = context.Point.Where(s => s.Point_ID == point_ID).FirstOrDefault<Point>();
				findedPoint.Task_ID = newPoint.Task_ID;
				findedPoint.Name = newPoint.Name;
				findedPoint.TaskForToday = newPoint.TaskForToday;
				findedPoint.ExecutionStatus = newPoint.ExecutionStatus;
				findedPoint.CompletionDate = newPoint.CompletionDate;
				findedPoint.DeadLineDate= newPoint.DeadLineDate;
				findedPoint.Description = newPoint.Description;
				context.SaveChanges();
			}
		}
		/********************************************/

		//Pobieranie elementów z bazy danych:
		public static TaskCollection GetTaskCollection(int collection_ID)
		{
			using (var context = new AppDataBase())
			{
				var findedTaskCollection = context.TaskCollection.Where(s => s.TaskCollection_ID == collection_ID).FirstOrDefault<TaskCollection>();				
				return findedTaskCollection;
			}
		}
		public static Task GetTask( int task_ID)
		{
			using (var context = new AppDataBase())
			{
				var findedTask = context.Task.Where(s => s.Task_ID == task_ID).FirstOrDefault<Task>();
				return findedTask;
			}
		}
		public static Point GetPoint(int point_ID)
		{
			using (var context = new AppDataBase())
			{
				var findedPoint = context.Point.Where(s => s.Point_ID == point_ID).FirstOrDefault<Point>();
				return findedPoint;
			}
		}
		/***********************************/


		// TODO: Poprawić funkcje tak by zwracały właściwe zbiory danych...
		// Pobieranie pełnych kolekcji z bazy danych:
		public static List<TaskCollection> GetCollectionsList()
		{
			using (var context = new AppDataBase())
			{
				List<TaskCollection> List = context.TaskCollection.ToList<TaskCollection>();
				return List;
			}
		}
		public static List<Task> GetTasksList()
		{
			using (var context = new AppDataBase())
			{
				List<Task> List = context.Task.ToList<Task>();
				return List;
			}
		}
		public static List<Point> GetPointsList()
		{
			using (var context = new AppDataBase())
			{
				List<Point> List = context.Point.ToList<Point>();
				return List;
			}
		}
		/*******************************************/



	}




}

