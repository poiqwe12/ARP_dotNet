using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ManagementApp.Model
{
	class DBContext : DbContext
	{
		public DbSet<Point> Points { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<TaskCollection> TaskCollections { get; set; }
	}
	static class DataBase 
	{

		//Dodawanie do bazy danych:
		public static void AddCollection(TaskCollection newCollection)
		{
			using (var context = new DBContext())
			{
					context.TaskCollections.Add(newCollection);
					context.SaveChanges();
			}
		}
		public static void AddTask(Task newTask)
		{
			using (var context = new DBContext())
			{
				context.Tasks.Add(newTask);
				context.SaveChanges();
			}
		}
		public static void AddPoint(Point newPoints)
		{
			using (var context = new DBContext())
			{
				context.Points.Add(newPoints);
				context.SaveChanges();
			}
		}
		/*************************/

		//Usuwanie z bazy danych:
		public static void DeleteCollection(int collection_ID)
		{
			using (var context = new DBContext())
			{
				var findedTaskCollection = context.TaskCollections.Where(s => s.Id == collection_ID).FirstOrDefault<TaskCollection>();
				context.TaskCollections.Remove(findedTaskCollection);
				context.SaveChanges();
			}
		}
		public static void DeleteTask(int task_ID)
		{
			using (var context = new DBContext())
			{
				var findedTask = context.Tasks.Where(s => s.Id == task_ID).FirstOrDefault<Task>();
				context.Tasks.Remove(findedTask);
				context.SaveChanges();
			}
		}
		public static void DeletePoint(int point_ID)
		{
			using (var context = new DBContext())
			{
				var findedPoint = context.Points.Where(s => s.Id == point_ID).FirstOrDefault<Point>();
				context.Points.Remove(findedPoint);
				context.SaveChanges();


			}
		}
		/***********************/

		//Wprowadzanie zmian do elementów bazy danych:
		public static void ChangeCollectionProperties(int collection_ID, TaskCollection newCollection) //???
		{
			using (var context = new DBContext())
			{
				var findedTaskCollection = context.TaskCollections.Where(s => s.Id == collection_ID).FirstOrDefault<TaskCollection>();
				findedTaskCollection.Name = newCollection.Name;
				findedTaskCollection.Description = findedTaskCollection.Description;
				context.SaveChanges();
			}
		}
		public static void ChangeTaskProperties(int task_ID, Task newTask) //???
		{
			using (var context = new DBContext())
			{
				var findedTask = context.Tasks.Where(s => s.Id == task_ID).FirstOrDefault<Task>();
				findedTask.Id = newTask.Id;
				findedTask.Name = newTask.Name;
				findedTask.CompletionDate = newTask.CompletionDate;
				findedTask.DeadLineDate = newTask.DeadLineDate;
				findedTask.PercentageCompletion = newTask.PercentageCompletion;
				findedTask.Description = newTask.Description;
				context.SaveChanges();
			}
		}
		public static void ChangePointProperties(int point_ID, Point newPoint)
		{
			using (var context = new DBContext())
			{
				var findedPoint = context.Points.Where(s => s.Id == point_ID).FirstOrDefault<Point>();
				findedPoint.Id = newPoint.Id;
				findedPoint.Name = newPoint.Name;
				findedPoint.CompletionDate = newPoint.CompletionDate;
				findedPoint.DeadLineDate = newPoint.DeadLineDate;
				findedPoint.IsTaskForToday = newPoint.IsTaskForToday;
				findedPoint.ExecutionStatus = newPoint.ExecutionStatus;
				context.SaveChanges();
			}
		}
		/********************************************/

		//Pobieranie elementów z bazy danych:
		public static TaskCollection GetTaskCollection(int collection_ID)
		{
			using (var context = new DBContext())
			{
				var findedTaskCollection = context.TaskCollections.Where(s => s.Id == collection_ID).FirstOrDefault<TaskCollection>();
				return findedTaskCollection;
			}
		}
		public static Task GetTask(int task_ID)
		{
			using (var context = new DBContext())
			{
				var findedTask = context.Tasks.Where(s => s.Id == task_ID).FirstOrDefault<Task>();
				return findedTask;
			}
		}
		public static Point GetPoint(int point_ID)
		{
			using (var context = new DBContext())
			{
				var findedPoint = context.Points.Where(s => s.Id == point_ID).FirstOrDefault<Point>();
				return findedPoint;
			}
		}
		/***********************************/

		// Pobieranie pełnych kolekcji z bazy danych:
		public static List<TaskCollection> GetCollectionsList()
		{
			using (var context = new DBContext())
			{
				List<TaskCollection> List = context.TaskCollections.ToList<TaskCollection>();
				return List;
			}
		}
		public static List<Task> GetTasksList(int collection_ID)
		{
			using (var context = new DBContext())
			{
				List<Task> List = new List<Task>();
				foreach (var item in context.Tasks)
				{
					if(item.TaskCollectionId == collection_ID)
					{
						List.Add(item);
					}
				}	
				return List;
			}
		}
		public static List<Point> GetPointsList(int task_ID)
		{
			using (var context = new DBContext())
			{
				List<Point> List = new List<Point>();
				foreach (var item in context.Points)
				{
					if (item.TaskId == task_ID)
					{
						List.Add(item);
					}
				}
				return List;
			}
		}
		/*******************************************/


	}
}
