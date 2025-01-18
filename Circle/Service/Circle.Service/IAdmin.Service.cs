using System.Collections.Generic;
using System.Threading.Tasks;
using Circle.Service.Models;

namespace Circle.Services.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<TopicModel>> GetAllTopicsAsync();
        Task<IEnumerable<CommentModel>> GetAllCommentsAsync();
        Task<bool> ApproveTopicAsync(int topicId);
        Task<bool> ApproveCommentAsync(int commentId);
        Task<bool> DeleteTopicAsync(int topicId);
        Task<bool> DeleteCommentAsync(int commentId);
        Task<bool> BanUserAsync(string userId);
    }
}
