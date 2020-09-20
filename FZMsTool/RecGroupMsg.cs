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
            string json = @"{""app"":""com.tencent.autoreply"",""desc"":"""",""view"":""autoreply"",""ver"":""0.0.0.1"",""prompt"":""[动画表情]"",""meta"":{""metadata"":{""title"":""点击蓝色字体有惊喜"",""buttons"":[{""slot"":1,""action_data"":""我是傻逼"",""name"":""点我"",""action"":""notify""},{""slot"":1,""action_data"":""我是傻逼"",""name"":""点我1"",""action"":""notify""}],""type"":""guest"",""token"":""LAcV49xqyE57S17B8ZT6FU7odBveNMYJzux288tBD3c=""}},""config"":{""forward"":1,""showSender"":1}}";
            e.FromGroup.SendJSON(e.RobotQQ, 1, json);
            
        }
    }
}
