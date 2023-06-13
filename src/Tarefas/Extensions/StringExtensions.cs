using System;
using Tarefas.Enums;

namespace Tarefas.Extensions
{
    public static class StringExtensions
    {
        public static Priority ToPriority(this string color)
        {
            var priority = color.Replace("PriorityColor", string.Empty) ?? "Low";
            return (Priority)Enum.Parse(typeof(Priority), priority);
        }
    }
}
