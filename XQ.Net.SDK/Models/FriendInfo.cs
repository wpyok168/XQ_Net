namespace XQ.Net.SDK.Models
{
    public class FriendInfo
    {
        public FriendInfo(string name, long id)
        {
            Name = name;
            Id = id;
        }

        /// <summary>
        /// QQ名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// QQ号
        /// </summary>
        public long Id { get; set; }
    }
}