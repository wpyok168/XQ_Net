using XQ.Net.SDK.EventArgs;

namespace XQ.Net.SDK.Interfaces
{
    public interface IXQGroupMessage
    {
        /// <summary>
        /// 主入口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GroupMessage(object sender, XQAppGroupMsgEventArgs e);
    }
}