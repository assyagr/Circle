using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circle.Data.Models;

namespace Circle.Data.Repositories
{
    public interface ICircleFriendshipReposiotry
    {
        void Add(CircleFriendship friendship);
    }
}
