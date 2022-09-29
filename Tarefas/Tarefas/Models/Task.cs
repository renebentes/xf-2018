using System;

namespace Tarefas.Models
{
    public class Task
    {
        public DateTime FinishDate { get; set; }

        public string Name { get; set; }

        public Priority Priority { get; set; }
    }
}
