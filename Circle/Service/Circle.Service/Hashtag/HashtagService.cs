using Circle.Data.Repositories;
using Circle.Service.Mappings;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Hashtag
{
	public class HashtagService : IHashtagService
	{
		private readonly HashtagRepository hashtagRepository;

		public HashtagService(HashtagRepository hashtagRepository)
		{
			this.hashtagRepository = hashtagRepository;
		}
		public async Task<HashtagServiceModel> CreateAsync(HashtagServiceModel model)
		{
			Data.Models.Hashtag entity = model.ToEntity();

			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			await hashtagRepository.CreateAsync(entity);
			return entity.ToModel();
		}

		public async Task<HashtagServiceModel> DeleteAsync(string id)
		{
			Data.Models.Hashtag entity = hashtagRepository.GetAll().SingleOrDefault(h => h.Id == id);
			hashtagRepository.DeleteAsync(entity);

			return entity.ToModel();

		}

		public async Task<HashtagServiceModel> EditAsync(HashtagServiceModel model)
		{
			throw new NotImplementedException();
		}

		public IQueryable<HashtagServiceModel> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
