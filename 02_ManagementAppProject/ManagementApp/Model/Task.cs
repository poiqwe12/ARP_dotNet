using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementApp.Model
{
    public class Task
    {
        public string Name { get; set; }
        public string DeadlineDate { get; set; }
        public string CompletionDate { get; set; }
        public string Descriptions { get; set; }
        public int PercentageCompletion { get; set; }

        public List<Point> Points { get; set; }



        public Task()
        {
            this.Points = new List<Point>();

            Name = "Przykładowa nazwa zadania";
            DeadlineDate = "11.11.11r.";
            CompletionDate = "11.11.11r.";
            PercentageCompletion = 50;
        }

    }
}
