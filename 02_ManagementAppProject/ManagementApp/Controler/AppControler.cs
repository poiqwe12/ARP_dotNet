using ManagementApp.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public static void AddCollection(Collections newCollection)
		{
			using (var context = new DBEntities())
			{
				context.Collections.Add(newCollection);
				context.SaveChanges();
			}
		}
		public static void AddPoint(Points newPoints)
		{
			using (var context = new  DBEntities())
			{
				context.Points.Add(newPoints);
				context.SaveChanges();
			}
		}
	}
}
