namespace Circle.Service.Friends
{
    public class FriendRequestServiceModelBaseBase1
    {
        private int id;

        private string receiverId;
        private string? senderId;

        public int Id { get; set; }

        public required string ReceiverId { get; set; }

        public required string SenderId { get; set; }

        public int GetId() => id;


        public string GetReceiverId() => receiverId;

        public string GetSenderId() => GetSenderId(senderId);

        public string GetSenderId(string? senderId) => senderId;
        public void SetId(int value) => id = value;
        public void SetReceiverId(string value) => receiverId = value;

        public void SetSenderId(string value) => senderId = value;

        public Data.Repositories.FriendRequest ToEntity() => throw new NotImplementedException();
    }
}