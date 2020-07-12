using WebAPI.Models.Enums;
using WebAPI.Models.RequestModels;
using WebAPI.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Models.ViewModel;
using WebAPI.Models.QueryModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PayrollController : Controller
    {
        private readonly IPayrollRepository payrollRepository;

        public PayrollController(IPayrollRepository _payrollRepository)
        {
            payrollRepository = _payrollRepository;
        }

        private int CalculateSalary(GetPayrollQueryModel model)
        {
            switch (model.Type)
            {
                case PayTypeEnum.typeOne:
                    return model.Salary;
                case PayTypeEnum.typeTwo:
                    return model.WorkDay * model.DailyInCome;
                case PayTypeEnum.typeThird:
                    return model.Salary + (model.ShiftHour * model.ShiftFee);
                default:
                    return 0;
            }
        }

        [HttpPost("getpayroll")]
        public object GetPayroll([FromBody]GetPayrollRequestModel requestModel)
        {
            requestModel.Search = requestModel.Search ?? "";
            requestModel.StartDate = requestModel.StartDate ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // default first day of month
            requestModel.EndDate = requestModel.EndDate ?? DateTime.Now;

            var result = payrollRepository.GetPayrolls(requestModel);
            var response = new List<GetPayrollViewModel>();
            result.ForEach(item => response.Add(new GetPayrollViewModel
            {
                CitizenshipIdentifier = item.CitizenshipIdentifier,
                FirstName = item.FirstName,
                LastName = item.LastName,
                WorkDay = item.WorkDay,
                Salary = CalculateSalary(item),
                Date = item.Date
            }));
            return response;
        }

    }
}