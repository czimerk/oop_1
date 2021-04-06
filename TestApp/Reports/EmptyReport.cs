using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    internal class EmptyReport : Report
    {
        internal EmptyReport(string path) : base(path)
        {

        }

        public override double Calculate() 
        {
            return 0.0;
        }
    }
}
