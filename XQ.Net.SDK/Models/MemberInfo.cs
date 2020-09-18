namespace XQ.Net.SDK.Models
{
    public class MemberInfo
    {
        public MemberInfo(string group, string robot)
        {
            FromGroup = group;
            FromRobot = robot;
        }

        private string FromGroup;
        private string FromRobot;

        public string Id { get; set; }

        public int Level { get; set; }
    }
}