using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Net.SDK.EventArgs;
using XQ.Net.SDK.Interfaces;

namespace FZMsTool
{
    public class RecPrivateMsg : IXQPrivateMessage
    {
        public void PrivateMessage(object sender, XQAppPrivateMsgEventArgs e)
        {
            e.FromQQ.SendMsg(e.RobotQQ,"欢迎使用C# 先驱SKD");
            XQ.Net.SDK.XQAPI.SendMsgEX(e.RobotQQ, 1, "", e.FromQQ.Id, "1欢迎使用C# 先驱SKD", 0, false);
        }
    }
}
