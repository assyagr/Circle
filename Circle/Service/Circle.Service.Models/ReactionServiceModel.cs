using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Models
{
	public class ReactionServiceModel : MetadataBaseServiceModel
	{
		public string Label { get; set; }

		public AttachmentServiceModel Emote { get; set; }
	}
}
