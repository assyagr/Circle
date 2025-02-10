using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Web.Models.Post
{
	public class CreatePostModel
	{
		public List<IFormFile> Content { get; set; }

		public string Caption { get; set; }

		public List<string> TaggedUsers { get; set; }

		public List<string>? Flags { get; set; }
 	}
}
