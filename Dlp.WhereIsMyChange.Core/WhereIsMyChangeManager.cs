using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core
{
    public class WhereIsMyChangeManager
    {
        public double CalculateChange(double productAmount, double paidAmount) {
            return paidAmount - productAmount;
        }
    }
}
