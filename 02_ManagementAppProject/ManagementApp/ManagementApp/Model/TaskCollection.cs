using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApp.Model
{
    public class TaskCollection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Task> Tasks { get; set; }

        public TaskCollection(string newName)
        {
            Name = newName;
            Tasks = new List<Task>();
        }
        public TaskCollection()
        {
            Tasks = new List<Task>();
        }
    }
}
