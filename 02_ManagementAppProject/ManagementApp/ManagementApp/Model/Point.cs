using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp.Model
{
    public class Point
    {

        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public DateTime? DeadLineDate { get; set; }
        public DateTime? CompletionDate { get; set; }   
        public bool ExecutionStatus { get; set; }
        public bool IsTaskForToday { get; set; }

        public Point(string newName, int newTaskId, DateTime newDeadlineDate )
        {
            Name = newName;
            TaskId = newTaskId;
            DeadLineDate = newDeadlineDate;
            ExecutionStatus = false;
            IsTaskForToday = false;
        }
        public Point()
        {
        }
    }
}
