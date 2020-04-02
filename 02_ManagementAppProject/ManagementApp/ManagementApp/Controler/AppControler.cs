using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManagementApp.DataBase;


namespace ManagementApp.Controler
{ 

	static public class AppControler
	{
		//Dane
		static public int ActualChosenElementInMenu = -1;
		static public string ActualChosenTypeInMenu = "Null";

		public static void AddCollection(TaskCollection newCollection)
		{
			using (var context = new AppDataBase())
			{
				context.TaskCollection.Add(newCollection);
				context.SaveChanges();
			}
		}
		public static void AddTask(Task newTask)
		{
			using (var context = new AppDataBase())
			{
				context.Task.Add(newTask);
				context.SaveChanges();
			}
		}
		public static void AddPoint(Point newPoints)
		{
			using (var context = new AppDataBase())
			{
				context.Point.Add(newPoints);
				context.SaveChanges();
			}
		}

		public static void DeleteCollection(int collection_ID)
		{
		}

		public static void DeleteTask(int collection_ID, int task_ID)
		{
		}
		public static void DeletePoint(int task_ID, int point_ID)
		{
		}

		public static void ChangeCollectionProperties(int collection_ID ) //???
		{
			//Jak to zgrabnie rozwiązać?
		}

		public static void ChangeTaskProperties(int collection_ID, int task_ID) //???
		{
			//Jak to zgrabnie rozwiązać?
		}
		public static void ChangePointProperties(int collection_ID, int task_ID, int point_ID) //???
		{
			//Jak to zgrabnie rozwiązać?
		}



		public static List<TaskCollection> GetCollectionsList()
		{
			return new List<TaskCollection>();
		}

		public static List<Task> GetTasksList(int collection_ID)
		{
			return new List<Task>();
		}
		public static List<Point> GetPointsList(int task_ID)
		{
			return new List<Point>();
		}



	}




}

