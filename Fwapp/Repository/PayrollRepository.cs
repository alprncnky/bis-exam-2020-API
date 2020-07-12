using WebAPI.Repository.interfaces;
using WebAPI.Repository.Queries;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models.QueryModels;
using Dapper;
using WebAPI.Models.RequestModels;

namespace WebAPI.Repository
{
    public class PayrollRepository : Repository, IPayrollRepository
    {
        private readonly ICommandText _commandText;
        private readonly string _connStr;

        public PayrollRepository(IConfiguration configuration, ICommandText commandText)
        {
            _commandText = commandText;
            _connStr = configuration.GetConnectionString("DbConnection");
        }

        public List<GetPayrollQueryModel> GetPayrolls(GetPayrollRequestModel model)
        {
            var result = ExecuteCommand(_connStr, conn => conn.Query<GetPayrollQueryModel>(_commandText.GET_PAYROLL, new
            {
                @search = model.Search,
                @startDate = model.StartDate,
                @endDate = model.EndDate,
                @take = model.Take,
                @skip = model.Skip
            })).ToList();
            return result;
        }
    }
}