using Circle.Web.Models.Utilities.Binding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Web.Models.User
{
    public class EditUserModel
    {
		public string Id {get; set;}
		public string UserName { get; set; }

		public string? Bio { get; set; }

		public IFormFile? ProfilePicture { get; set; }
	}
}
