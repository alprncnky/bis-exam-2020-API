using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public interface IUserManager
    {
        int? GetUserId(HttpContext httpContext);
    }

    public class UserManager : IUserManager
    {
        public int? GetUserId(HttpContext httpContext)
        {
            var value = httpContext.User.Claims.Where(c => c.Type == "UserId").FirstOrDefault().Value;
            return int.Parse(value);
        }
    }
}
