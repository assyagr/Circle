using Circle.Service.Models;
using Circle.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Circle.Service.Reaction
{
	public interface IReactionService : IGenericService<Data.Models.Reaction, ReactionServiceModel>
	{
	}
}
