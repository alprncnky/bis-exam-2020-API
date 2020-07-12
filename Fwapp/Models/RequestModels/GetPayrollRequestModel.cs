using System;

namespace WebAPI.Models.RequestModels
{
    public class GetPayrollRequestModel
    {
        public string Search { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Take { get; set; }
        public int? Skip { get; set; }
    }
}
