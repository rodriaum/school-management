using System;
using System.Collections.Generic;

namespace SchoolManagement.Util
{
    public class DateUtil
    {
        public static string FormatTime(DateTime start, DateTime end)
        {
            TimeSpan diff = end - start;

            int days = diff.Days;
            int hours = diff.Hours;
            int minutes = diff.Minutes;
            int seconds = diff.Seconds;

            List<string> parts = new List<string>();

            if (days > 0)
                parts.Add($"{days} dia{(days > 1 ? "s" : "")}");

            if (hours > 0)
                parts.Add($"{hours} hora{(hours > 1 ? "s" : "")}");

            if (minutes > 0)
                parts.Add($"{minutes} minuto{(minutes > 1 ? "s" : "")}");

            if (seconds > 0 || parts.Count == 0)
                parts.Add($"{seconds} segundo{(seconds > 1 ? "s" : "")}");

            return string.Join(", ", parts);
        }
    }
}
