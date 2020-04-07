using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp.Model
{
    class Task
    {
        public int Id { get; set; }
        public int TaskCollectionId { get; set; }
        public string Name { get; set; }
        public DateTime? DeadLineDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int PercentageCompletion { get; set; }
        public string Description { get; set; }

        public virtual List<Point> Points { get; set; }

        public Task(string newName, int newTaskCollectionId, DateTime newDeadlineDate)
        {
            Name = newName;
            TaskCollectionId = newTaskCollectionId;
            DeadLineDate = newDeadlineDate;
            PercentageCompletion = 0;
            Points = new List<Point>();
        }
        public Task()
        {
            Points = new List<Point>();
        }

    }
}
