using XQ.Net.SDK.Models;

namespace XQ.Net.SDK.EventArgs
{
    public class XQAddFriendEventArgs : XQEventArgs
    {
        public XQQQ FromQQ { get; set; }

        public XQAddFriendEventArgs(XQAPI xqapi, string robotQQ, int eventType, string qq) : base(xqapi, robotQQ, eventType)
        {
            FromQQ = new XQQQ(qq, xqapi);
        }

        //public void Pass()
        //{
        //    XQAPI.HanldeFriendEvent(this.RobotQQ, FromQQ.Id, Enums.ResponseType.PASS);
        //}
        //public void Refuse()
        //{
        //    XQAPI.HanldeFriendEvent(this.RobotQQ, FromQQ.Id, Enums.ResponseType.REFUSE);

        //}
        //public void Ignore()
        //{
        //    XQAPI.HanldeFriendEvent(this.RobotQQ, FromQQ.Id, Enums.ResponseType.IGNORE);

        //}
    }
}