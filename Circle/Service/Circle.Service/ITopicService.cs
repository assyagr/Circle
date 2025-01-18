using System.Collections.Generic;
using System.Threading.Tasks;
using Circle.Service.Models;

namespace Circle.Services.Interfaces
{
    public interface ITopicService
    {
        Task<IEnumerable<TopicModel>> GetAllTopicsAsync();
        Task<TopicModel?> GetTopicByIdAsync(int id);
        Task<bool> CreateTopicAsync(TopicCreateModel model);
        Task<bool> UpdateTopicAsync(int id, TopicCreateModel model);
        Task<bool> DeleteTopicAsync(int id);
    }
}
