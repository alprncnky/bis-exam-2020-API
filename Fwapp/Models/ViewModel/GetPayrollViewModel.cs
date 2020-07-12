using System;

namespace WebAPI.Models.ViewModel
{
    public class GetPayrollViewModel
    {
        public string CitizenshipIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public int WorkDay { get; set; }
        public DateTime Date { get; set; }
    }
}
