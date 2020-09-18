namespace XQ.Net.SDK.Models
{
    public class XQGroup : BaseModel
    {
        public XQGroup(string groupid, XQAPI api) : base(api)
        {
            Id = groupid;
        }

        public string Id { get; set; }

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="msg"></param>
        /// <param name="MessageType">2群 3讨论组</param>
        public void SendMessage(string robotQQ, string msg, int MessageType = 2)
        {
            XQAPI.SendMsg(robotQQ, MessageType, this.Id, "", msg, 0);
        }

        /// <summary>
        /// 发送群匿名消息 --需要群开启匿名否则消息发送失败
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="msg"></param>
        /// <param name="MessageType">2群 3讨论组</param>
        public void SendMsgEX(string robotQQ, string msg, int MessageType = 2)
        {
            XQAPI.SendMsgEX(robotQQ, MessageType, this.Id, "", msg, 0, true);
        }

        /// <summary>
        /// 发送群消息 - 气泡
        /// </summary>
        /// <param name="robotQQ">收到消息的机器人</param>
        /// <param name="msg"></param>
        /// <param name="BubbleID">气泡ID -2强制不使用气泡 -1随机使用气泡 0跟随框架的设置</param>
        /// <param name="MessageType">2群 3讨论组</param>
        public void SendMessage(string robotQQ, string msg, int BubbleID, int MessageType = 2)
        {
            XQAPI.SendMsg(robotQQ, MessageType, this.Id, "", msg, BubbleID);
        }

        /// <summary>
        /// 发送JSON结构消息
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="SendType">1:普通发送 2:匿名发送</param>
        /// <param name="JsonMessage">JSON内容</param>
        /// <param name="MessageType">2群 3讨论组</param>
        public void SendJSON(string robotQQ, int SendType, string JsonMessage, int MessageType = 2)
        {
            XQAPI.SendJSON(robotQQ, SendType, MessageType, this.Id, "", JsonMessage);
        }

        /// <summary>
        /// 发送XML结构消息
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="SendType"></param>
        /// <param name="QQ"></param>
        /// <param name="JsonMessage"></param>
        /// <param name="MessageType">2群 3讨论组</param>
        public void SendXML(string robotQQ, int SendType, string JsonMessage, int MessageType = 2)
        {
            XQAPI.SendXML(robotQQ, SendType, MessageType, this.Id, "", JsonMessage);
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="ImageMessage"></param>
        public void UpLoadPic(string robotQQ, byte[] ImageMessage)
        {
            XQAPI.UpLoadPic(robotQQ, 2, this.Id, ImageMessage);
        }

        /// <summary>
        /// 群禁言 - 某人(比如 Heer)
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="Time"></param>
        public void ShutUP(string robotQQ, string QQ, int Time)
        {
            XQAPI.ShutUP(robotQQ, this.Id, QQ, Time);
        }

        /// <summary>
        /// 解除某人(Heer)禁言
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="QQ"></param>
        public void UnShutUP(string robotQQ, string QQ)
        {
            XQAPI.ShutUP(robotQQ, this.Id, QQ, 0);
        }

        /// <summary>
        /// 群禁言 - 都给爷闭嘴
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="Time">(单位:秒)</param>
        public void AllShutUP(string robotQQ, int Time)
        {
            XQAPI.ShutUP(robotQQ, this.Id, "", Time);
        }

        /// <summary>
        /// 解除禁言 - 出来吧!憨八龟们
        /// </summary>
        /// <param name="robotQQ"></param>
        public void UnAllShutUP(string robotQQ)
        {
            XQAPI.ShutUP(robotQQ, this.Id, "", 0);
        }

        /// <summary>
        /// 修改群员昵称
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="Card"></param>
        /// <returns></returns>
        public bool SetGroupCard(string robotQQ, string QQ, string Card)
        {
            return XQAPI.SetGroupCard(robotQQ, this.Id, QQ, Card);
        }

        /// <summary>
        /// 踢出群员
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="QQ">目标QQ</param>
        /// <param name="Allow">true : 不允许申请入群 / false: 允许申请入群</param>
        public void KickGroupMBR(string robotQQ, string QQ, bool Allow)
        {
            XQAPI.KickGroupMBR(robotQQ, this.Id, QQ, Allow);
        }

        /// <summary>
        /// 踢出群员
        /// </summary>
        /// <param name="robotQQ">响应机器人QQ</param>
        /// <param name="targetQQ">目标qq</param>
        /// <param name="blacklist">是否加入黑名单</param>
        public void KickMember(string robotQQ, string targetQQ, bool blacklist = false)
        {
            XQAPI.KickGroupMember(robotQQ, Id, targetQQ, blacklist);
        }

        /// <summary>
        /// 发布群公告c
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="Title">公告标题</param>
        /// <param name="Message">公告内容</param>
        /// <returns></returns>
        public bool PBGroupNotic(string robotQQ, string Title, string Message)
        {
            return XQAPI.PBGroupNotic(robotQQ, this.Id, Title, Message);
        }

        /// <summary>
        /// 撤回群消息
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="Number">消息序号</param>
        /// <param name="ID">消息ID</param>
        /// <returns></returns>
        public string WithdrawMsg(string robotQQ, string Number, string ID)
        {
            return XQAPI.WithdrawMsg(robotQQ, this.Id, Number, ID);
        }

        /// <summary>
        /// 要请 XX 加入本群
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="QQ"></param>
        public void InviteGroup(string robotQQ, string QQ)
        {
            XQAPI.InviteGroup(robotQQ, this.Id, QQ);
        }

        /// <summary>
        /// 退群
        /// </summary>
        /// <param name="robotQQ"></param>
        public void QuitGroup(string robotQQ)
        {
            XQAPI.QuitGroup(robotQQ, this.Id);
        }

        /// <summary>
        /// 群匿名
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="Kg">Ture:开启/False:关闭</param>
        /// <returns></returns>
        public bool SetAnon(string robotQQ, bool Kg)
        {
            return XQAPI.SetAnon(robotQQ, this.Id, Kg);
        }

        /// <summary>
        /// 获取群员列表
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public string GetGroupMemberList(string robotQQ)
        {
            return XQAPI.GetGroupMemberList(robotQQ, Id);
        }

        /// <summary>
        /// 获取群员列表 B计划
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public string GetGroupMemberList_B(string robotQQ)
        {
            return XQAPI.GetGroupMemberList_B(robotQQ, Id);
        }

        /// <summary>
        /// 获取群员列表 C计划
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns>JSON文本</returns>
        public string GetGroupMemberList_C(string robotQQ)
        {
            return XQAPI.GetGroupMemberList_C(robotQQ, Id);
        }

        /// <summary>
        /// 获取指定人群名片
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="QQ">目标QQ</param>
        /// <returns></returns>
        public string GetGroupCard(string robotQQ, string QQ)
        {
            return XQAPI.GetGroupCard(robotQQ, Id, QQ);
        }

        /// <summary>
        /// 获取群管理⚪列表
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public string GetGroupAdmin(string robotQQ)
        {
            return XQAPI.GetGroupAdmin(robotQQ, Id);
        }

        /// <summary>
        /// 获取群通知
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public string GetNotice(string robotQQ)
        {
            return XQAPI.GetNotice(robotQQ, Id);
        }

        /// <summary>
        /// 获取群成员禁言状态
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="QQ">指定群员QQ</param>
        /// <returns></returns>
        public bool IsShutUp(string robotQQ, string QQ)
        {
            return XQAPI.IsShutUp(robotQQ, Id, QQ);
        }

        /// <summary>
        /// 获取群名称
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public string GetGroupName(string robotQQ)
        {
            return XQAPI.GetGroupName(robotQQ, Id);
        }

        /// <summary>
        /// 获取 群在线人数/总人数
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public string GetGroupMemberNum(string robotQQ)
        {
            return XQAPI.GetGroupMemberNum(robotQQ, Id);
        }

        /// <summary>
        /// 获取 是否允许匿名
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public bool GetAnon(string robotQQ)
        {
            return XQAPI.GetAnon(robotQQ, Id);
        }

        public GroupInfo ToGroupInfo(string robotQQ)
        {
            return new GroupInfo(robotQQ, Id);
        }
    }
}