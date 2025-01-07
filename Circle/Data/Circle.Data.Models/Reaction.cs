using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
	public class Reaction : MetadataBaseEntity
	{
		public string Label { get; set; }

		public Attachment Emote { get; set; }
	}
}
