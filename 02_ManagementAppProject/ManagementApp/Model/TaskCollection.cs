using System;
using System.Collections.Generic;
using System.Text;


namespace ManagementApp.Model
{
    public class TaskCollection
    {
        public string Name { get; set; }
        public string Descriptions { get; set; }
        bool IsChosenInMenu { get; set; }
        public List<Task> Tasks { get; set; }


        public TaskCollection()
        {
            this.Tasks = new List<Task>();
            Name = "Jakiś tam zbiór zadań";
            IsChosenInMenu = false;
        }
    }
}
