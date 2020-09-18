using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Net.SDK.EventArgs;
using XQ.Net.SDK.Interfaces;

namespace FZMsTool
{
    public class RecGroupMsg : IXQGroupMessage
    {
        public void GroupMessage(object sender, XQAppGroupMsgEventArgs e)
        {
            //throw new NotImplementedException();
            e.FromGroup.SendMessage(e.RobotQQ, "欢迎使用C# 先驱SKD");
           // e.FromGroup.SendMessage(e.RobotQQ, "[@All]");
        }
    }
}
