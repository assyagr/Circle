using Circle.Data.Models;
using Circle.Data.Repositories;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service
{
    public class CircleUserService : ICircleUserService
    {
        private readonly CircleRepository _repository;

        public CircleUserService(CircleRepository repository)
        {
            this._repository = repository;
        }

        public async Task<CircleUser> CreateAsync(CircleUser UserData) => 
            await this._repository.CreateAsync(UserData); //idk what to make checks for yet?



        //Task<CircleUser> ICircleUserService.CreateAsync(CircleUser Userinfo) //idk why the Inter. is here but ig ok
        //{
        //    throw new NotImplementedException();
        //}
    }
}
