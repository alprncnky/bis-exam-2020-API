using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repository.Queries
{
    public interface ICommandText
    {
        string GET_PAYROLL { get; }
    }

    public class CommandText : ICommandText
    {
        public string GET_PAYROLL =>
            @"select usr.CitizenshipIdentifier, usr.FirstName, usr.LastName, py.Salary, py.WorkDay, py.DailyInCome, py.ShiftHour, py.ShiftFee, py.Date, py.Type from Pay py
              inner join [User] usr ON usr.UserId = py.UserId
              where py.Date between @startDate and @endDate and (usr.FirstName LIKE '%'+ @search +'%' or usr.CitizenshipIdentifier LIKE '%'+ @search +'%')";
    }
}
