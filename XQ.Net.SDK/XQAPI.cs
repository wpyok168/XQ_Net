using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using XQ.Net.SDK.Models;

namespace XQ.Net.SDK
{
    public class XQAPI
    {
        public static byte[] AuthId;
        public static string AppDir;

        public void SetAuthID(int id, int addr)
        {
            AuthId = BitConverter.GetBytes(id).Concat(BitConverter.GetBytes(addr)).ToArray();
        }

        public static AppInfo AppInfo;

        public void SetAppInfo(AppInfo app) {
            AppInfo = app;
            AppDir = Directory.GetCurrentDirectory() + "\\Config\\" + AppInfo.name + "\\";
        }

        /// <summary>
        /// 发送普通消息
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="group">群号</param>
        /// <param name="msg">消息</param>
        public void SendGroupMessage(string robot, string group, string msg)
        {
            XQDLL.SendMsgEX(AuthId, robot, 2, group, "", msg, 0, false);
        }

        internal void KickGroupMember(string robotQQ, string id, string targetQQ, bool blacklist)
        {
            throw new NotImplementedException();
        }

        internal void SendPrivateMessage(string robotQQ, string id, string msg)
        {
            throw new NotImplementedException();
        }

        internal void ShutUpMember(string robotQQ, string id, string targetQQ, int seconds)
        {
            throw new NotImplementedException();
        }

        internal static IEnumerator<MemberInfo> GetGroupMemberInfo(string robotQQ, string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取好友列表-http模式
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static string GetFriendList(string QQ)
        {
            return IntPtrToString(XQDLL.GetFriendList(AuthId, QQ));
        }

        /// <summary>
        /// 获取群列表
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static string GetGroupList(string QQ)
        {
            return IntPtrToString(XQDLL.GetGroupList(AuthId, QQ));
        }

        /// <summary>
        /// 获取机器人在线账号列表
        /// </summary>
        /// <returns></returns>
        public static string GetOnLineList()
        {
            return IntPtrToString(XQDLL.GetOnLineList(AuthId));
        }

        /// <summary>
        /// 获取机器人账号是否在线
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static bool Getbotisonline(string QQ)
        {
            return XQDLL.Getbotisonline(AuthId, QQ);
        }

        /// <summary>
        /// 获取群员列表
        /// </summary>
        /// <param name="QQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <returns></returns>
        public static string GetGroupMemberList(string QQ, string GrouoQQ)
        {
            return IntPtrToString(XQDLL.GetGroupMemberList(AuthId, QQ, GrouoQQ));
        }

        /// <summary>
        /// 获取群成员名片
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static string GetGroupCard(string RobotQQ, string GrouoQQ, string QQ)
        {
            return IntPtrToString(XQDLL.GetGroupCard(AuthId, RobotQQ, GrouoQQ, QQ));
        }

        /// <summary>
        /// 获取群管理⚪列表
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <returns></returns>
        public static string GetGroupAdmin(string RobotQQ, string GrouoQQ)
        {
            return IntPtrToString(XQDLL.GetGroupAdmin(AuthId, RobotQQ, GrouoQQ));
        }

        /// <summary>
        /// 获取群通知
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <returns></returns>
        public static string GetNotice(string RobotQQ, string GrouoQQ)
        {
            return IntPtrToString(XQDLL.GetNotice(AuthId, RobotQQ, GrouoQQ));
        }

        /// <summary>
        /// 获取群成员禁言状态
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static bool IsShutUp(string RobotQQ, string GrouoQQ, string QQ)
        {
            return XQDLL.IsShutUp(AuthId, RobotQQ, GrouoQQ, QQ);
        }

        /// <summary>
        /// 是否是好友
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static bool IfFriend(string RobotQQ, string QQ)
        {
            return XQDLL.IfFriend(AuthId, RobotQQ, QQ);
        }

        /// <summary>
        /// 取得QQ群页面操作用参数P_skey
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string GetGroupPsKey(string RobotQQ)
        {
            return IntPtrToString(XQDLL.GetGroupPsKey(AuthId, RobotQQ));
        }

        /// <summary>
        /// 取得QQ空间页面操作用参数P_skey
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string GetZonePsKey(string RobotQQ)
        {
            return IntPtrToString(XQDLL.GetZonePsKey(AuthId, RobotQQ));
        }

        /// <summary>
        /// 取得机器人网页操作用的Cookies
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string GetCookies(string RobotQQ)
        {
            return IntPtrToString(XQDLL.GetCookies(AuthId, RobotQQ));
        }

        /// <summary>
        /// 获取赞数量
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static int GetObjVote(string RobotQQ, string QQ)
        {
            return XQDLL.GetObjVote(AuthId, RobotQQ, QQ);
        }

        /// <summary>
        /// 取插件是否启用
        /// </summary>
        /// <returns></returns>
        public static bool IsEnable()
        {
            return XQDLL.IsEnable(AuthId);
        }

        /// <summary>
        /// 取所有QQ列表
        /// </summary>
        /// <returns></returns>
        public static string GetQQList()
        {
            return IntPtrToString(XQDLL.GetQQList(AuthId));
        }

        /// <summary>
        /// 取QQ昵称
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static string GetNick(string RobotQQ, string QQ)
        {
            return IntPtrToString(XQDLL.GetNick(AuthId, RobotQQ, QQ));
        }

        /// <summary>
        /// 取好友备注姓名
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static string GetFriendsRemark(string RobotQQ, string QQ)
        {
            return IntPtrToString(XQDLL.GetFriendsRemark(AuthId, RobotQQ, QQ));
        }

        /// <summary>
        /// 取短Clientkey
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string GetClientkey(string RobotQQ)
        {
            return IntPtrToString(XQDLL.GetClientkey(AuthId, RobotQQ));
        }

        /// <summary>
        /// 取得机器人网页操作用的长Clientkey
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string GetLongClientkey(string RobotQQ)
        {
            return IntPtrToString(XQDLL.GetLongClientkey(AuthId, RobotQQ));
        }

        /// <summary>
        /// 取得腾讯课堂页面操作用参数P_skey
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string GetClassRoomPsKey(string RobotQQ)
        {
            return IntPtrToString(XQDLL.GetClassRoomPsKey(AuthId, RobotQQ));
        }

        /// <summary>
        /// 取得QQ举报页面操作用参数P_skey
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string GetRepPsKey(string RobotQQ)
        {
            return IntPtrToString(XQDLL.GetRepPsKey(AuthId, RobotQQ));
        }

        /// <summary>
        /// 取得财付通页面操作用参数P_skey
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string GetTenPayPsKey(string RobotQQ)
        {
            return IntPtrToString(XQDLL.GetTenPayPsKey(AuthId, RobotQQ));
        }

        /// <summary>
        /// 取bkn
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string GetBkn(string RobotQQ)
        {
            return IntPtrToString(XQDLL.GetBkn(AuthId, RobotQQ));
        }

        /// <summary>
        /// 封包模式获取群号列表(最多可以取得999)
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string GetGroupList_B(string RobotQQ)
        {
            return IntPtrToString(XQDLL.GetGroupList_B(AuthId, RobotQQ));
        }

        /// <summary>
        /// 封包模式取好友列表(与封包模式取群列表同源)
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string GetFriendList_B(string RobotQQ)
        {
            return IntPtrToString(XQDLL.GetFriendList_B(AuthId, RobotQQ));
        }

        /// <summary>
        /// 取登录二维码base64
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetQrcode(string key)
        {
            return IntPtrToString(XQDLL.GetQrcode(AuthId, key));
        }

        /// <summary>
        /// 检查登录二维码状态
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int CheckQrcode(string key)
        {
            return XQDLL.CheckQrcode(AuthId, key);
        }

        /// <summary>
        /// 取指定的群名称
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <returns></returns>
        public static string GetGroupName(string RobotQQ, string GrouoQQ)
        {
            return IntPtrToString(XQDLL.GetGroupName(AuthId, RobotQQ, GrouoQQ));
        }

        /// <summary>
        /// 取群人数上线与当前人数 换行符分隔
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <returns></returns>
        public static string GetGroupMemberNum(string RobotQQ, string GrouoQQ)
        {
            return IntPtrToString(XQDLL.GetGroupMemberNum(AuthId, RobotQQ, GrouoQQ));
        }

        /// <summary>
        /// 取群等级
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <returns></returns>
        public static int GetGroupLv(string RobotQQ, string GrouoQQ)
        {
            return XQDLL.GetGroupLv(AuthId, RobotQQ, GrouoQQ);
        }

        /// <summary>
        /// 取群成员列表
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <returns></returns>
        public static string GetGroupMemberList_B(string RobotQQ, string GrouoQQ)
        {
            return IntPtrToString(XQDLL.GetGroupMemberList_B(AuthId, RobotQQ, GrouoQQ));
        }

        /// <summary>
        /// 封包模式取群成员列表返回重组后的json文本
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <returns></returns>
        public static string GetGroupMemberList_C(string RobotQQ, string GrouoQQ)
        {
            return IntPtrToString(XQDLL.GetGroupMemberList_C(AuthId, RobotQQ, GrouoQQ));
        }

        /// <summary>
        /// 检查指定QQ是否在线
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static bool IsOnline(string RobotQQ, string QQ)
        {
            return XQDLL.IsOnline(AuthId, RobotQQ, QQ);
        }

        /// <summary>
        /// 取机器人账号在线信息
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string GetRInf(string RobotQQ)
        {
            return IntPtrToString(XQDLL.GetRInf(AuthId, RobotQQ));
        }

        /// <summary>
        /// 查询指定群是否允许匿名消息
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <returns></returns>
        public static bool GetAnon(string RobotQQ, string GroupQQ)
        {
            return XQDLL.GetAnon(AuthId, RobotQQ, GroupQQ);
        }

        /// <summary>
        /// 通过图片GUID获取图片下载链接
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="ImageType"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="ImageGUID"></param>
        /// <returns></returns>
        public static string GetPicLink(string RobotQQ, int ImageType, string GroupQQ, string ImageGUID)
        {
            return IntPtrToString(XQDLL.GetPicLink(AuthId, RobotQQ, ImageType, GroupQQ, ImageGUID));
        }

        /// <summary>
        /// 获取指定QQ个人资料的年龄
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static int GetAge(string RobotQQ, string QQ)
        {
            return XQDLL.GetAge(AuthId, RobotQQ, QQ);
        }

        /// <summary>
        /// 获取QQ个人资料的性别
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static int GetGender(string RobotQQ, string QQ)
        {
            return XQDLL.GetGender(AuthId, RobotQQ, QQ);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="MessageType">信息类型</param>
        /// <param name="GrouoQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="Message"></param>
        /// <param name="BubbleID">气泡ID</param>
        public static void SendMsg(string RobotQQ, int MessageType, string GrouoQQ, string QQ, string Message, int BubbleID)
        {
            XQDLL.SendMsgEX(AuthId, RobotQQ, MessageType, GrouoQQ, QQ, Message, BubbleID,false);
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="MessageType"></param>
        /// <param name="GrouoQQOrQQ"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static string UpLoadPic(string RobotQQ, int MessageType, string GrouoQQOrQQ, byte[] Message)
        {
            return IntPtrToString(XQDLL.UpLoadPic(AuthId, RobotQQ, MessageType, GrouoQQOrQQ, Message));
        }

        /// <summary>
        /// 群禁言
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="Time"></param>
        public static void ShutUP(string RobotQQ, string GrouoQQ, string QQ, int Time)
        {
            XQDLL.ShutUP(AuthId, RobotQQ, GrouoQQ, QQ, Time);
        }

        /// <summary>
        ///  修改群成员昵称
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="Card"></param>
        /// <returns></returns>
        public static bool SetGroupCard(string RobotQQ, string GrouoQQ, string QQ, string Card)
        {
            return XQDLL.SetGroupCard(AuthId, RobotQQ, GrouoQQ, QQ, Card);
        }

        /// <summary>
        /// 群删除成员
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="Allow"></param>
        public static void KickGroupMBR(string RobotQQ, string GrouoQQ, string QQ, bool Allow)
        {
            XQDLL.KickGroupMBR(AuthId, RobotQQ, GrouoQQ, QQ, Allow);
        }

        /// <summary>
        /// 修改QQ在线状态
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="OnLineType"></param>
        /// <param name="Message"></param>
        public static void SetRInf(string RobotQQ, string OnLineType, string Message)
        {
            XQDLL.SetRInf(AuthId, RobotQQ, OnLineType, Message);
        }

        /// <summary>
        /// 发布群公告
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="MessageTitle"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static bool PBGroupNotic(string RobotQQ, string GrouoQQ, string MessageTitle, string Message)
        {
            return XQDLL.PBGroupNotic(AuthId, RobotQQ, GrouoQQ, MessageTitle, Message);
        }

        /// <summary>
        /// 撤回群消息
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="MessageNumber"></param>
        /// <param name="MessageID"></param>
        /// <returns></returns>
        public static string WithdrawMsg(string RobotQQ, string GrouoQQ, string MessageNumber, string MessageID)
        {
            return IntPtrToString(XQDLL.WithdrawMsg(AuthId, RobotQQ, GrouoQQ, MessageNumber, MessageID));
        }

        /// <summary>
        /// 输出日志 (在框架中显示)
        /// </summary>
        /// <param name="Message"></param>
        public static void OutPutLog(string Message)
        {
            XQDLL.OutPutLog(AuthId, Message);
        }

        /// <summary>
        /// 提取图片文字
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="ImageMessage"></param>
        /// <returns></returns>
        public static string OcrPic(string RobotQQ, byte[] ImageMessage)
        {
            return IntPtrToString(XQDLL.OcrPic(AuthId, RobotQQ, ImageMessage));
        }

        /// <summary>
        /// 主动加群
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="Message"></param>
        public static void JoinGroup(string RobotQQ, string GrouoQQ, string Message)
        {
            XQDLL.JoinGroup(AuthId, RobotQQ, GrouoQQ, Message);
        }

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static string UpVote(string RobotQQ, string QQ)
        {
            return IntPtrToString(XQDLL.UpVote(AuthId, RobotQQ, QQ));
        }

        /// <summary>
        /// 通过列表或群临时通道点赞
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static string UpVote_temp(string RobotQQ, string QQ)
        {
            return IntPtrToString(XQDLL.UpVote_temp(AuthId, RobotQQ, QQ));
        }

        /// <summary>
        /// 置好友添加请求
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="MessageType"></param>
        /// <param name="Message"></param>
        public static void HandleFriendEvent(string RobotQQ, string QQ, int MessageType, string Message)
        {
            XQDLL.HandleFriendEvent(AuthId, RobotQQ, QQ, MessageType, Message);
        }

        /// <summary>
        /// 置群请求
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="RequestType"></param>
        /// <param name="QQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="Seq"></param>
        /// <param name="MessageType"></param>
        /// <param name="Message"></param>
        public static void HandleGroupEvent(string RobotQQ, int RequestType, string QQ, string GrouoQQ, string Seq, int MessageType, string Message)
        {
            XQDLL.HandleGroupEvent(AuthId, RobotQQ, RequestType, QQ, GrouoQQ, Seq, MessageType, Message);
        }

        /// <summary>
        /// 向框架添加一个QQ
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Password"></param>
        /// <param name="Automatic"></param>
        /// <returns></returns>
        public static string AddQQ(string Account, string Password, bool Automatic)
        {
            return IntPtrToString(XQDLL.AddQQ(AuthId, Account, Password, Automatic));
        }

        /// <summary>
        /// 登录指定QQ
        /// </summary>
        /// <param name="QQ"></param>
        public static void LoginQQ(string QQ)
        {
            XQDLL.LoginQQ(AuthId, QQ);
        }

        /// <summary>
        /// 离线指定QQ
        /// </summary>
        /// <param name="QQ"></param>
        public static void OffLineQQ(string QQ)
        {
            XQDLL.OffLineQQ(AuthId, QQ);
        }

        /// <summary>
        /// 删除指定QQ
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static string DelQQ(string QQ)
        {
            return IntPtrToString(XQDLL.DelQQ(AuthId, QQ));
        }

        /// <summary>
        /// 删除指定好友
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static bool DelFriend(string RobotQQ, string QQ)
        {
            return XQDLL.DelFriend(AuthId, RobotQQ, QQ);
        }

        /// <summary>
        /// 修改好友备注名称
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="Message"></param>
        public static void SetFriendsRemark(string RobotQQ, string QQ, string Message)
        {
            XQDLL.SetFriendsRemark(AuthId, RobotQQ, QQ, Message);
        }

        /// <summary>
        /// 邀请好友加入群
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="QQ"></param>
        public static void InviteGroup(string RobotQQ, string GrouoQQ, string QQ)
        {
            XQDLL.InviteGroup(AuthId, RobotQQ, GrouoQQ, QQ);
        }

        /// <summary>
        /// 邀请群成员加入群
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="GrouoQQY"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static bool InviteGroupMember(string RobotQQ, string GrouoQQ, string GrouoQQY, string QQ)
        {
            return XQDLL.InviteGroupMember(AuthId, RobotQQ, GrouoQQ, GrouoQQY, QQ);
        }

        /// <summary>
        /// 创建群 组包模式
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string CreateDisGroup(string RobotQQ)
        {
            return IntPtrToString(XQDLL.CreateDisGroup(AuthId, RobotQQ));
        }

        /// <summary>
        ///  创建群 群官网Http模式
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <returns></returns>
        public static string CreateGroup(string RobotQQ)
        {
            return IntPtrToString(XQDLL.CreateGroup(AuthId, RobotQQ));
        }

        /// <summary>
        /// 退出群
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        public static void QuitGroup(string RobotQQ, string GrouoQQ)
        {
            XQDLL.QuitGroup(AuthId, RobotQQ, GrouoQQ);
        }

        /// <summary>
        /// 屏蔽或接收某群消息
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="MessageType"></param>
        public static void SetShieldedGroup(string RobotQQ, string GrouoQQ, bool MessageType)
        {
            XQDLL.SetShieldedGroup(AuthId, RobotQQ, GrouoQQ, MessageType);
        }

        /// <summary>
        /// 多功能删除好友 可删除陌生人或者删除为单项好友
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="MessageType"></param>
        public static void DelFriend_A(string RobotQQ, string QQ, int MessageType)
        {
            XQDLL.DelFriend_A(AuthId, RobotQQ, QQ, MessageType);
        }

        /// <summary>
        /// 设置机器人被添加好友时的验证方式
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="MessageType"></param>
        public static void Setcation(string RobotQQ, int MessageType)
        {
            XQDLL.Setcation(AuthId, RobotQQ, MessageType);
        }

        /// <summary>
        /// 设置机器人被添加好友时的问题与答案
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="Problem"></param>
        /// <param name="Answer"></param>
        public static void Setcation_problem_A(string RobotQQ, string Problem, string Answer)
        {
            XQDLL.Setcation_problem_A(AuthId, RobotQQ, Problem, Answer);
        }

        /// <summary>
        /// 设置机器人被添加好友时的三个可选问题
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="Problem1"></param>
        /// <param name="Problem2"></param>
        /// <param name="Problem3"></param>
        public static void Setcation_problem_B(string RobotQQ, string Problem1, string Problem2, string Problem3)
        {
            XQDLL.Setcation_problem_B(AuthId, RobotQQ, Problem1, Problem2, Problem3);
        }

        /// <summary>
        /// 主动添加好友
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="Message"></param>
        /// <param name="xxlay"></param>
        /// <returns></returns>
        public static bool AddFriend(string RobotQQ, string QQ, string Message, int xxlay)
        {
            return XQDLL.AddFriend(AuthId, RobotQQ, QQ, Message, xxlay);
        }

        /// <summary>
        /// 发送json结构消息
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="SendType"></param>
        /// <param name="MessageType"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="JsonMessage"></param>
        public static void SendJSON(string RobotQQ, int SendType, int MessageType, string GrouoQQ, string QQ, string JsonMessage)
        {
            XQDLL.SendJSON(AuthId, RobotQQ, SendType, MessageType, GrouoQQ, QQ, JsonMessage);
        }

        /// <summary>
        /// 发送xml结构消息
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="SendType"></param>
        /// <param name="MessageType"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="XMLMessage"></param>
        public static void SendXML(string RobotQQ, int SendType, int MessageType, string GrouoQQ, string QQ, string XMLMessage)
        {
            XQDLL.SendXML(AuthId, RobotQQ, SendType, MessageType, GrouoQQ, QQ, XMLMessage);
        }

        /// <summary>
        /// 上传silk语音文件
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="SendType"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static string UpLoadVoice(string RobotQQ, int SendType, string GrouoQQ, byte[] Message)
        {
            return IntPtrToString(XQDLL.UpLoadVoice(AuthId, RobotQQ, SendType, GrouoQQ, Message));
        }

        /// <summary>
        /// 发送普通消息支持群匿名方式
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="MessageType"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="Message"></param>
        /// <param name="BubbleID"></param>
        /// <param name="Anonymous"></param>
        /// <returns></returns>
        public static string SendMsgEX(string RobotQQ, int MessageType, string GrouoQQ, string QQ, string Message, int BubbleID, bool Anonymous)
        {
            return IntPtrToString(XQDLL.SendMsgEX(AuthId, RobotQQ, MessageType, GrouoQQ, QQ, Message, BubbleID, Anonymous));
        }

        /// <summary>
        /// 通过语音GUID获取语音文件下载连接
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static string GetVoiLink(string RobotQQ, string Message)
        {
            return IntPtrToString(XQDLL.GetVoiLink(AuthId, RobotQQ, Message));
        }

        /// <summary>
        /// 开关群匿名功能
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="kg"></param>
        /// <returns></returns>
        public static bool SetAnon(string RobotQQ, string GroupQQ, bool kg)
        {
            return XQDLL.SetAnon(AuthId, RobotQQ, GroupQQ, kg);
        }

        /// <summary>
        /// 修改机器人自身头像
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static bool SetHeadPic(string RobotQQ, byte[] Message)
        {
            return XQDLL.SetHeadPic(AuthId, RobotQQ, Message);
        }

        /// <summary>
        /// 语音GUID转换为文本内容
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="ckdx"></param>
        /// <param name="cklx"></param>
        /// <param name="yyGUID"></param>
        /// <returns></returns>
        public static string VoiToText(string RobotQQ, string ckdx, int cklx, string yyGUID)
        {
            return IntPtrToString(XQDLL.VoiToText(AuthId, RobotQQ, ckdx, cklx, yyGUID));
        }

        /// <summary>
        /// 群签到
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="GroupQQ"></param>
        /// <param name="Address"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static bool SignIn(string RobotQQ, string GroupQQ, string Address, string Message)
        {
            return XQDLL.SignIn(AuthId, RobotQQ, GroupQQ, Address, Message);
        }

        /// <summary>
        /// 向好友发送窗口抖动消息
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public static bool ShakeWindow(string RobotQQ, string QQ)
        {
            return XQDLL.ShakeWindow(AuthId, RobotQQ, QQ);
        }

        /// <summary>
        /// 同步发送消息 有返回值可以用来撤回机器人自己发送的消息
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="MessageType"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="Message"></param>
        /// <param name="BubbleID"></param>
        /// <param name="Anonymous"></param>
        /// <param name="JSONMessage"></param>
        /// <returns></returns>
        public static string SendMsgEX_V2(string RobotQQ, int MessageType, string GrouoQQ, string QQ, string Message, int BubbleID, bool Anonymous, string JSONMessage)
        {
            return IntPtrToString(XQDLL.SendMsgEX_V2(AuthId, RobotQQ, MessageType, GrouoQQ, QQ, Message, BubbleID, Anonymous, JSONMessage));
        }

        /// <summary>
        /// 撤回群消息或者私聊消息
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="WithdrawType"></param>
        /// <param name="GrouoQQ"></param>
        /// <param name="QQ"></param>
        /// <param name="MessageNumber"></param>
        /// <param name="MessageID"></param>
        /// <param name="MessageTime"></param>
        /// <returns></returns>
        public static string WithdrawMsgEX(string RobotQQ, int WithdrawType, string GrouoQQ, string QQ, string MessageNumber, string MessageID, string MessageTime)
        {
            return IntPtrToString(XQDLL.WithdrawMsgEX(AuthId, RobotQQ, WithdrawType, GrouoQQ, QQ, MessageNumber, MessageID, MessageTime));
        }

        /// <summary>
        /// 标记函数执行流程 debug时使用 每个函数内只需要调用一次
        /// </summary>
        /// <param name="Message"></param>
        public static void DbgName(string Message)
        {
            XQDLL.DbgName(AuthId, Message);
        }

        /// <summary>
        /// 函数内标记附加信息 函数内可多次调用
        /// </summary>
        /// <param name="Message"></param>
        public static void Mark(string Message)
        {
            XQDLL.Mark(AuthId, Message);
        }

        private static string IntPtrToString(IntPtr intPtr)
        {
            try
            {
                if (Marshal.ReadInt32(intPtr) < 0)
                    return "";
                byte[] bin = new byte[Marshal.ReadInt32(intPtr)];
                XQDLL.RtlMoveMemory(bin, intPtr + 4, Marshal.ReadInt32(intPtr));
                XQDLL.HeapFree1(XQDLL.GetProcessHeap(), 0, intPtr);
                return System.Text.Encoding.Default.GetString(bin);
            }
            catch (Exception ex)
            {
                return "错误:" + ex.Message;
            }
        }

        /// <summary>
        /// 获取图片ImageGuid
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static List<string> ImageGuid(string Message)
        {
            try
            {
                if (Message.Contains("[pic="))
                {
                    var str = Regex.Matches(Message, @"([pic])(.)+?(?=\])");
                    if (str != null)
                    {
                        List<string> list = new List<string>();
                        foreach (Match item in str)
                        {
                            list.Add($"[{item.Value}]");
                        }
                        return list;
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 图片转byte[]
        /// </summary>
        /// <param name="url">网路地址</param>
        /// <returns></returns>
        public static byte[] HttpImageByte(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                byte[] retult = null;
                using (WebResponse webResponse = request.GetResponse())
                {
                    StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
                    int length = (int)webResponse.ContentLength;
                    byte[] bs = new byte[length];
                    retult = new byte[length];
                    HttpWebResponse response = webResponse as HttpWebResponse;
                    Stream stream = response.GetResponseStream();

                    //读取到内存
                    MemoryStream stmMemory = new MemoryStream();
                    byte[] buffer1 = new byte[length];
                    int i;
                    while ((i = stream.Read(buffer1, 0, buffer1.Length)) > 0)
                    {
                        stmMemory.Write(buffer1, 0, i);
                    }
                    byte[] arraryByte = stmMemory.ToArray();
                    retult = arraryByte;
                    stmMemory.Close();
                }
                return retult;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 图片转byte[]
        /// </summary>
        /// <param name="url">本地路径</param>
        /// <returns></returns>
        public static byte[] FileImageByte(string url)
        {
            try
            {
                using (FileStream fs = new FileStream(url, FileMode.Open, FileAccess.Read))
                {
                    byte[] arraryByte = new byte[fs.Length];
                    using (BinaryReader binaryWriter = new BinaryReader(fs))
                    {
                        arraryByte = binaryWriter.ReadBytes((int)fs.Length);
                        binaryWriter.Close();
                    }
                    fs.Close();
                    return arraryByte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetVer()
        {
            return IntPtrToString(XQDLL.GetVer());
        }
    }
}