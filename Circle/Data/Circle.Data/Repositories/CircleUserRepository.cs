using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circle.Data.Models;

namespace Circle.Data.Repositories
{



    public class CircleUserRepository : ICircleUserReposiotry //I should just inherit the base repo but
        // i get error that i dont have Circle.Data.Model.Cricle conversion to Cricle.Data.Model.BaseE
    {
        protected readonly CircleDbContext _dbContext;

        protected CircleUserRepository(CircleDbContext _dbContext) //inject db 
        {
            this._dbContext = _dbContext;
        }

        public async Task<CircleUser> CreateAsync(CircleUser Userinfo)
        {
            await this._dbContext.AddAsync(Userinfo);
            await this._dbContext.SaveChangesAsync(); 
            return Userinfo;
        }


    }
}
