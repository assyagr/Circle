using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circle.Data.Models;

namespace Circle.Service
{
    public interface ICircleUserService
    {

        Task<CircleUser> CreateAsync(CircleUser Userinfo);

      //  Task<CircleUser> UpdateAsync(CircleUser Userinfo);

    }
}
