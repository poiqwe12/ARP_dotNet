using System;
using System.Collections.Generic;
using System.Text;


namespace ManagementApp.Model
{
    public class Point
    {
        public string Name { get; set; }
        public string DeadlineDate { get; set; }
        public string CompletionDate { get; set; }
        public bool ExecutionStatus { get; set; }
        public bool TaskForToday { get; set; }


        public Point()
        {
            Name = "Jakiś tam pinkt";
        }
    }
}
