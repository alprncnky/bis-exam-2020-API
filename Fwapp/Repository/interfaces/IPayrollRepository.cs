using WebAPI.Models.QueryModels;
using WebAPI.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repository.interfaces
{
    public interface IPayrollRepository
    {
        List<GetPayrollQueryModel> GetPayrolls(GetPayrollRequestModel model);
    }
}
