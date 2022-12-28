using System.Collections.Generic;
using System.Text.Json;
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
        {
            var tasksJson = JsonSerializer.Serialize<IList<Task>>(_tasks);
            Application.Current.Properties.Add(key, tasksJson);
        }

        private IList<Task> RetrieveFromProperties()
        {
            if (Application.Current.Properties.TryGetValue(key, out var json))
            {
                var tasks = JsonSerializer.Deserialize<IList<Task>>((string)json);
                return tasks ?? new List<Task>();
            }

            return new List<Task>();
        }
    }
}
