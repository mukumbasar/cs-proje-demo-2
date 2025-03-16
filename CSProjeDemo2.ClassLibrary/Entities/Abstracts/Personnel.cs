using CSProjeDemo2.ClassLibrary.Enums;
using CSProjeDemo2.ClassLibrary.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.ClassLibrary.Entities.Abstracts
{
    public abstract class Personnel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Title Title { get; set; }
        public decimal HourlyWage { get; set; } = 500;

        public virtual Payroll CalculateSalary(int workingHours)
        {
            int overtimeHours = Math.Max(0, workingHours - 180);
            decimal overtimePayment = overtimeHours * (HourlyWage * 1.5m);
            decimal mainPayment = (workingHours - overtimeHours) * HourlyWage;

            return new Payroll()
            {
                PersonnelName = $"{Name} {Surname}",
                WorkingHours = workingHours,
                OvertimePayment = overtimePayment,
                MainPayment = mainPayment,
                TotalPayment = mainPayment + overtimePayment
            };
        }
    }
}
