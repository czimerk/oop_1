using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestApp
{
    class Report
    {
        private List<User> _users;


        internal Report(string path)
        {
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                _users = new List<User>();
                foreach (var line in lines)
                {
                    var parts = line.Split(',');

                    _users.Add(
                        new User() 
                        { 
                            Name = parts[0], 
                            Hours = Convert.ToDouble(parts[1].Replace(".", ",")), 
                            Rate = Convert.ToDouble(parts[2].Replace(".", ",")) 
                        });
                }
            }
        }
        public virtual double Calculate()
        {
            var costs = _users.Select(u => u.Rate * u.Hours).ToList();
            var sum = costs.Sum();
            return sum;
        }

        public int NumberOfUsers()
        {
            return _users.Count;
        }
    }
}
