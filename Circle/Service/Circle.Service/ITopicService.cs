namespace Circle.Services
{
    public interface ITopicService
    {
        Task<IEnumerable<string>> GetAllTopicsAsync();
        Task<string> GetTopicByIdAsync(int id);
        Task<bool> CreateTopicAsync(string title, string content);
    }
}
