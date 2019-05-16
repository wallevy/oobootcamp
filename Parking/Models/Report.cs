using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking.Models
{
    public class Report
    {
        string Role { get; }
        long Capacity { get; }
        long UsedCount { get; }
        IList<Report> SubReports { get; }

        readonly string NewLine = Environment.NewLine;

        public Report(string role, long capacity, long usedCount)
        {
            Role = role;
            Capacity = capacity;
            UsedCount = usedCount;
            SubReports = new List<Report>();
        }

        public Report(string role, IList<Report> subReports)
        {
            Role = role;
            SubReports = new List<Report>(subReports);
            Capacity = SubReports.Sum(report => report.Capacity);
            UsedCount = SubReports.Sum(report => report.UsedCount);
        }

        public override string ToString()
        {
            var summary = $"{Role} {UsedCount} {Capacity}";
            return SubReports.Aggregate(summary, (cur, sub) => cur + NewLine + Padding(sub.ToString(), "  "));
        }

        static string Padding(string text, string padding)
        {
            return string.Join("\n", text.Split('\n').Select(line => padding + line));
        }
    }
}