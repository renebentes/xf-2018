using System.Collections.Generic;
using Xamarin.Forms;

namespace Tarefas.Models
{
    public class TaskManager
    {
        private const string key = "tasks";

        private readonly IList<Task> _tasks;

        public TaskManager()
            => _tasks = RetrieveFromProperties();

        public IEnumerable<Task> ListAll()
            => _tasks;

        public void Remove(Task task)
        {
            _tasks.Remove(task);
            PersistOnProperties();
        }

        public void Save(Task task)
        {
            _tasks.Add(task);
            PersistOnProperties();
        }

        private void PersistOnProperties()
            => Application.Current.Properties.Add(key, _tasks);

        private IList<Task> RetrieveFromProperties()
            => Application.Current.Properties.TryGetValue(key, out var tasks)
                ? tasks as IList<Task>
                : new List<Task>();
    }
}
