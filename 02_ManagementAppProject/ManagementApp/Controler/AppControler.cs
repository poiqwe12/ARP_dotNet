using ManagementApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManagementApp.Controler
{
	static public class AppControler
	{
		public static void AddCollection(string name,string description )
		{
			using (var context = new Database1Entities())
			{
				var b = new Collections { ColletionName=name, Description = description };
				context.Collections.Add(b);
				context.SaveChanges();
			}
		}
		public static void AddPoint(int id, string name, Nullable<System.DateTime> deadline, Nullable<System.DateTime> copletedata,bool status,bool taskfortod, string description)
		{
			using (var context = new Database1Entities())
			{
				var b1 = context.Tasks
					   .Where(bs => bs.Tasks_Id == id);

				var b = new Points { Task_id = id, PointName = name, DeadLineDate=copletedata, CompletionDate=copletedata,ExecutionStatus=status,TaskForToday=taskfortod,Description=description};
				context.Points.Add(b);
				context.SaveChanges();
			}
		}
	}
}
