using System;
using Tarefas.Enums;

namespace Tarefas.Models
{
    public class Task
    {
        public bool Done => FinishDate is not null;

        public DateTime? FinishDate { get; set; }

        public string Name { get; set; } = string.Empty;

        public Priority Priority { get; set; }
    }
}
