namespace XQ.Net.SDK.Models
{
    /// <summary>
    /// 对QQ的实体类
    /// </summary>
    public class XQQQ : BaseModel
    {
        public XQQQ(string qq, XQAPI api) : base(api)
        {
            this.Id = qq;
        }

        /// <summary>
        /// QQ号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 发送抖动窗口
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public bool ShakeWindow(string robotQQ)
        {
            return XQAPI.ShakeWindow(robotQQ, this.Id);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="Message"></param>
        /// <param name="MessageType">1:好友 0:在线临时会话</param>
        public void SendMsg(string robotQQ, string Message, int MessageType = 1)
        {
            XQAPI.SendMsg(robotQQ, MessageType, "", this.Id, Message, 0);
        }

        /// <summary>
        /// 发送消息 - 带气泡
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="Message"></param>
        /// <param name="BubbleID">气泡ID</param>
        /// <param name="MessageType"></param>
        public void SendMsg(string robotQQ, string Message, int BubbleID, int MessageType = 1)
        {
            XQAPI.SendMsgEX(robotQQ, MessageType, "", this.Id, Message, BubbleID,false);
        }

        /// <summary>
        /// 发送JSON结构消息
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="JsonMessage"></param>
        /// <param name="MessageType"></param>
        public void SendJSON(string robotQQ, string JsonMessage, int MessageType = 1)
        {
            XQAPI.SendJSON(robotQQ, 1, MessageType, "", this.Id, JsonMessage);
        }

        /// <summary>
        /// 发送XML结构消息
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="JsonMessage"></param>
        /// <param name="MessageType"></param>
        public void SendXML(string robotQQ, string JsonMessage, int MessageType = 1)
        {
            XQAPI.SendXML(robotQQ, 1, MessageType, "", this.Id, JsonMessage);
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="ImageMessage"></param>
        public void UpLoadPic(string robotQQ, byte[] ImageMessage)
        {
            XQAPI.UpLoadPic(robotQQ, 1, this.Id, ImageMessage);
        }

        /// <summary>
        /// 邀请入群
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="GroupQQ"></param>
        public void InviteGroup(string robotQQ, string GroupQQ)
        {
            XQAPI.InviteGroup(robotQQ, GroupQQ, this.Id);
        }

        /// <summary>
        /// 删除当前好友
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="MessageType">1为在对方的列表删除我 2为在我的列表删除对方</param>
        public void DelFriend_A(string robotQQ, int MessageType)
        {
            XQAPI.DelFriend_A(robotQQ, this.Id, MessageType);
        }

        /// <summary>
        /// 修改好友备注
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="Message"></param>
        public void SetFriendsRemark(string robotQQ, string Message)
        {
            XQAPI.SetFriendsRemark(robotQQ, this.Id, Message);
        }

        /// <summary>
        /// 获取 昵称
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public string GetNick(string robotQQ)
        {
            return XQAPI.GetNick(robotQQ, this.Id.ToString());
        }

        /// <summary>
        /// 获取备注姓名
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public string GetFriendsRemark(string robotQQ)
        {
            return XQAPI.GetFriendsRemark(robotQQ, this.Id.ToString());
        }

        /// <summary>
        /// 获取AT代码
        /// </summary>
        /// <returns></returns>
        public string Code_At()
        {
            return $"[@{Id}]";
        }
    }
}