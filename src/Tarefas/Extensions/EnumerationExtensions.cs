using Tarefas.Enums;
using Xamarin.Forms;

namespace Tarefas.Extensions
{
    public static class EnumerationExtensions
    {
        public static Color ToColor(this Priority priority)
            => Application.Current.Resources.TryGetValue($"{priority}PriorityColor", out object color)
                ? (Color)color
                : Color.Default;
    }
}
