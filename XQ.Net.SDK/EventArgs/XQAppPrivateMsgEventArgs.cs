using XQ.Net.SDK.Models;

namespace XQ.Net.SDK.EventArgs
{
    public class XQAppPrivateMsgEventArgs : XQEventArgs
    {
        public XQAppPrivateMsgEventArgs(string robotQQ, int eventtype, int extratype, string fromqq, string msg, string index, string id, XQAPI api) : base(api)
        {
            RobotQQ = robotQQ;
            EventType = eventtype;
            ExtraType = extratype;
            FromQQ = new XQQQ(fromqq, api);
            Message = new XQMessage() { Text = msg, MsdId = id, MsgIndex = index };
        }

        /// <summary>
        /// 来自QQ
        /// </summary>
        public XQQQ FromQQ { get; set; }
        /// <summary>
        /// 来自群
        /// </summary>
        public XQGroup FromGroup { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public XQMessage Message { get; set; }
    }
}