using System.Collections.Generic;
using System.Text.Json;
using Xamarin.Forms;

namespace Tarefas.Models
{
    public class TaskManager
    {
        private const string key = "tasks";

        public IEnumerable<Task> ListAll()
            => FromProperties();

        public void Remove(Task task)
        {
            var tasks = FromProperties();
            tasks.Remove(task);
            ToProperties(tasks);
        }

        public void Save(Task task)
        {
            var tasks = FromProperties();
            tasks.Add(task);
            ToProperties(tasks);
        }

        private IList<Task> FromProperties()
        {
            if (Application.Current.Properties.TryGetValue(key, out var json))
            {
                var tasks = JsonSerializer.Deserialize<IList<Task>>((string)json);
                return tasks ?? new List<Task>();
            }

            return new List<Task>();
        }

        private void ToProperties(IList<Task> tasks)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                Application.Current.Properties.Remove(key);
            }

            var json = JsonSerializer.Serialize(tasks);
            Application.Current.Properties.Add(key, json);
        }
    }
}
