using CSProjeDemo2.ClassLibrary.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.ClassLibrary.Entities.Concretes
{
    public class CivilServant : Personnel
    {
        public decimal CivilServantDegree { get; set; }

        public CivilServant()
        {
            HourlyWage = HourlyWage + 50*CivilServantDegree;
        }
    }
}
