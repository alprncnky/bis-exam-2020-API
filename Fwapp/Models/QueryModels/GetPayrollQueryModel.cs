using WebAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.QueryModels
{
    public class GetPayrollQueryModel
    {
        public string CitizenshipIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public int WorkDay { get; set; }
        public int DailyInCome { get; set; }
        public int ShiftHour { get; set; }
        public int ShiftFee { get; set; }
        public DateTime Date { get; set; }
        public PayTypeEnum Type { get; set; }
    }
}
