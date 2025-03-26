namespace Circle.Service.Models
{
    public class CircleFriendshipServiceModel
    {
        public string Id { get; set; }
        public string CreatedById { get; set; }
        public string SentToId { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; }
    }
}
