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
		public static IList<TaskCollection> GetCollectionsList()
		{
			using (var context = new AppDataBase())
			{
				IList<TaskCollection> List = context.TaskCollection.ToList<TaskCollection>();
				return List;
			}
		}
		public static IList<Task> GetTasksList()
		{
			using (var context = new AppDataBase())
			{
				IList<Task> List = context.Task.ToList<Task>();
				return List;
			}
		}
		public static IList<Point> GetPointsList()
		{
			using (var context = new AppDataBase())
			{
				IList<Point> List = context.Point.ToList<Point>();
				return List;
			}
		}



	}




}

