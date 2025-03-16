using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.ClassLibrary.Results
{
    public class Payroll
    {
        public string PersonnelName { get; set; }
        public int WorkingHours { get; set; }
        public decimal MainPayment { get; set; }
        public decimal OvertimePayment {  get; set; }
        public decimal MonthlyBonus { get; set; }
        public decimal TotalPayment { get; set; }
    }
}
