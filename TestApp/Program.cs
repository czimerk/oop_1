using System;
using System.Collections.Generic;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"TestFiles\users.csv";
            var bonusPath = @"TestFiles\bonus.csv";

            var r = new Report(path);
            var noUsers = r.NumberOfUsers();

            Report defaultReport = new DefaultReport(path);
            Report emptyReport = new EmptyReport(path);
            Report bonuses = new SalaryReport(path, bonusPath);

            var reports = new List<Report>() { defaultReport, bonuses, emptyReport };

            foreach (Report report in reports) 
            {
                Console.WriteLine(report.Calculate());
            }

        }
    }
}
