using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManagementApp.DataBase;


namespace ManagementApp.Controler
{ 
	public struct ArgsPoint
	{
		public int idT;
		public string name;
		public int deadlineDay, deadlineMonth, deadlineYear;
		public int completeDay, completeMonth, completeYear;
		public bool status;
		public bool task4today;
		public string description;
	}

	static public class AppControler
	{
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
	}
}

