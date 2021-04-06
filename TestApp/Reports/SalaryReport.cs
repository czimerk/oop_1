using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestApp
{
    internal class SalaryReport : Report
    {
        private List<Bonus> _bonuses { get; set; }
        internal SalaryReport(string path, string bonusPath) : base(path)
        {
            if (File.Exists(bonusPath))
            {
                var lines = File.ReadAllLines(bonusPath);
                _bonuses = new List<Bonus>();
                foreach (var line in lines)
                {
                    var parts = line.Split(',');

                    _bonuses.Add(
                        new Bonus()
                        {

                            Name = parts[0],
                            BonusValue = Convert.ToDouble(parts[1].Replace(".", ","))
                        });
                }
            }
        }

        public override double Calculate()
        {
            var baseSum = base.Calculate();
            var bonusSum = _bonuses.Select(x => x.BonusValue).ToList().Sum();

            return baseSum + bonusSum;
        }

    }
}
