using Circle.Data.Models;
using Circle.Service.Models;

namespace Circle.Service.Mappings
{
	public static class AttachmentMappings
	{
		public static Attachment ToEntity(this AttachmentServiceModel model)
		{
			return new Attachment
			{
				CloudUrl = model.CloudUrl
			};
		}

		public static AttachmentServiceModel ToModel(this Attachment entity)
		{
			return new AttachmentServiceModel
			{
				Id = entity.Id,
				CloudUrl = entity.CloudUrl
			};
		}
	}
}
