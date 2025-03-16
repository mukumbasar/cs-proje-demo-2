using CSProjeDemo2.ClassLibrary.Entities.Abstracts;
using CSProjeDemo2.ClassLibrary.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.ClassLibrary.Entities.Concretes
{
    public class Manager : Personnel
    {
        public decimal MonthlyBonus;
        public Manager()
        {
            HourlyWage = 1000;
        }

        public override Payroll CalculateSalary(int workingHours)
        {
            Payroll payroll = base.CalculateSalary(workingHours);
            payroll.MonthlyBonus = MonthlyBonus;
            payroll.TotalPayment += MonthlyBonus;
            return payroll;
        }
    }
}
