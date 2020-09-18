namespace XQ.Net.SDK.Models
{
    /// <summary>
    /// 相应QQ(机器人)的实体类
    /// </summary>
    public class XQRobot : BaseModel
    {
        public XQRobot(string qq, XQAPI api) : base(api)
        {
            this.RobotQQ = qq;
        }

        /// <summary>
        /// 相应QQ号
        /// </summary>
        public string RobotQQ { get; set; }

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="groupid"></param>
        /// <param name="msg"></param>
        public void SendGroupMessage(string groupid, string msg)
        {
            new XQGroup(groupid, XQAPI).SendMessage(RobotQQ, msg);
        }

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="groupid"></param>
        /// <param name="msg"></param>
        public void SendGroupMessage(XQGroup group, string msg)
        {
            group.SendMessage(RobotQQ, msg);
        }

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="msg"></param>
        public void SendPrivateMessage(string qq, string msg)
        {
            new XQQQ(qq, XQAPI).SendMsg(RobotQQ, msg);
        }

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="msg"></param>
        public void SendPrivateMessage(XQQQ qq, string msg)
        {
            qq.SendMsg(RobotQQ, msg);
        }

        /// <summary>
        /// 发送抖动窗口
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public void ShakeWindow(XQQQ qqs)
        {
            qqs.ShakeWindow(RobotQQ);
        }

        /// <summary>
        /// 发送抖动窗口
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public bool ShakeWindow(string QQ)
        {
            return new XQQQ(QQ, XQAPI).ShakeWindow(RobotQQ);
        }

        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="ImageMessage"></param>
        /// <returns></returns>
        public bool SetHeadPic(byte[] ImageMessage)
        {
            return XQAPI.SetHeadPic(RobotQQ, ImageMessage);
        }

        /// <summary>
        /// 创建群 组包模式
        /// </summary>
        /// <returns></returns>
        public string CreateDisGroup()
        {
            return XQAPI.CreateDisGroup(RobotQQ);
        }

        /// <summary>
        /// 创建群 群官网Http模式
        /// </summary>
        /// <returns></returns>
        public string CreateGroup()
        {
            return XQAPI.CreateGroup(RobotQQ);
        }

        /// <summary>
        /// 获取QQ昵称
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public string GetNick(string QQ)
        {
            return new XQQQ(QQ, XQAPI).GetNick(RobotQQ);
        }

        /// <summary>
        /// 取好友备注姓名
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public string GetFriendsRemark(string QQ)
        {
            return new XQQQ(QQ, XQAPI).GetFriendsRemark(RobotQQ);
        }

        /// <summary>
        /// 封包模式获取群号列表(最多可以取得999)
        /// </summary>
        /// <returns></returns>
        public string GetGroupList_B()
        {
            return XQAPI.GetGroupList_B(RobotQQ);
        }

        /// <summary>
        /// 获取群列表
        /// </summary>
        /// <returns></returns>
        public string GetGroupList()
        {
            return XQAPI.GetGroupList(RobotQQ);
        }

        /// <summary>
        /// 封包模式取好友列表(与封包模式取群列表同源)
        /// </summary>
        /// <returns></returns>
        public string GetFriendList_B()
        {
            return XQAPI.GetFriendList_B(RobotQQ);
        }

        /// <summary>
        /// 获取好友列表-http模式
        /// </summary>
        /// <returns></returns>
        public string GetFriendList()
        {
            return XQAPI.GetFriendList(RobotQQ);
        }

        //public IEnumerable<XQGroup> GetGroupList()
        //{
        //    return XQDLL.Api_GetGroupList_B(RobotQQ).Split('\n').ToList().Select(s=>new XQGroup(s,XQAPI));
        //}

        public string GetGroupMemberList(string group)
        {
            //var json = XQDLL.Api_GetGroupMemberList_B(RobotQQ,group);
            return "";
        }
    }
}