using System;
using System.Runtime.InteropServices;
using Unity;
using XQ.Net.SDK;
using XQ.Net.SDK.EventArgs;
using XQ.Net.SDK.Interfaces;

namespace XQ_Net.Core
{
    public class _Event
    {
        #region 事件

        public static event EventHandler<XQAppGroupMsgEventArgs> Event_GroupMsgHandler;

        public static event EventHandler<XQAppPrivateMsgEventArgs> Event_PrivateMsgHandler;

        public static event EventHandler<XQAddGroupEventArgs> Event_AddGroupHandler;

        public static event EventHandler<XQAddFriendEventArgs> Event_AddFriendHandler;

        public static event EventHandler<XQBanSpeakEventArgs> Event_BanSpeak;

        public static event EventHandler<XQUnBanSpeakEventArgs> Event_UnBanSpeak;

        public static event EventHandler<XQEventArgs> Event_AppDisableHandler;

        public static event EventHandler<XQEventArgs> Event_AppEnableHandler;

        public static event EventHandler<XQEventArgs> Event_CallMenu;

        #endregion 事件

        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int XQ_Event(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, string unix, int p) => Event(robotQQ, eventType, extraType, from, fromQQ, targetQQ, content, index, msgid, udpmsg, unix, p);

        public static int Event(string robotQQ, int eventType, int extraType, string from, string fromQQ, string targetQQ, string content, string index, string msgid, string udpmsg, string unix, int p)
        {
            try
            {
                if (eventType == (int)XQEventType.Group)
                {
                    if (Event_GroupMsgHandler != null)//群聊消息
                    {
                        XQAppGroupMsgEventArgs args = new XQAppGroupMsgEventArgs(robotQQ, (int)eventType, (int)extraType, from, fromQQ, content, index, msgid, Common.xQAPI);
                        Event_GroupMsgHandler(typeof(_Event), args);
                        return (args.Handler ? 2 : 1);
                        //阻塞返回2，继续返回1
                    }
                }
                if (eventType == (int)XQEventType.Friend)//好友消息
                {
                    if (Event_PrivateMsgHandler != null)
                    {
                        XQAppPrivateMsgEventArgs args = new XQAppPrivateMsgEventArgs(robotQQ, (int)eventType, (int)extraType, from, content, index, msgid, Common.xQAPI);
                        Event_PrivateMsgHandler(typeof(_Event), args);
                        return (args.Handler ? 2 : 1);
                        //阻塞返回2，继续返回1
                    }
                }

                if (eventType == (int)XQEventType.PluginEnable)//插件启动
                {
                    if (Event_AppEnableHandler != null)
                    {
                        var args = new XQEventArgs(Common.xQAPI);
                        Event_AppEnableHandler(typeof(_Event), args);
                    }
                }

                if (eventType == (int)XQEventType.AddGroup || eventType == (int)XQEventType.InvitedToGroup
                    || eventType == (int)XQEventType.SomeoneInvitedToGroup || eventType == (int)XQEventType.AllowedToGroup)//群申请/邀请事件AddGroup
                {
                    if (Event_AddGroupHandler != null)
                    {
                        var args = new XQAddGroupEventArgs(Common.xQAPI, robotQQ, eventType, fromQQ, from, udpmsg);
                        Event_AddGroupHandler(typeof(_Event), args);
                    }
                }
                if (eventType == (int)XQEventType.AddFriend)//加好友事件
                {
                    if (Event_AddFriendHandler != null)
                    {
                        var args = new XQAddFriendEventArgs(Common.xQAPI, robotQQ, eventType, fromQQ);
                        Event_AddFriendHandler(typeof(_Event), args);
                    }
                }

                if (eventType == (int)XQEventType.BanSpeak)//被禁言
                {
                    if (Event_BanSpeak != null)
                    {
                        var args = new XQBanSpeakEventArgs(Common.xQAPI, robotQQ, eventType, fromQQ, targetQQ, from);
                        Event_BanSpeak(typeof(_Event), args);
                    }
                }

                if (eventType == (int)XQEventType.AddFriend)//被解除禁言
                {
                    if (Event_UnBanSpeak != null)
                    {
                        var args = new XQUnBanSpeakEventArgs(Common.xQAPI, robotQQ, eventType, fromQQ, targetQQ, from);
                        Event_UnBanSpeak(typeof(_Event), args);
                    }
                }

                return 1;
            }
            catch (Exception ex)
            {
                Common.Log(ex.ToString());
                return 1;
            }
        }

        /// <summary>
        /// 插件右键点击设置后触发的函数(一般放置插件设置窗口)
        /// </summary>
        /// <returns></returns>
        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static int XQ_SetUp() => Menu();

        public static int Menu()
        {
            if (EventContainer.Container.IsRegistered<IXQCallMenu>())
            {
                var args = new XQEventArgs(Common.xQAPI);
                _Event.Event_CallMenu(typeof(_Event), args);
                //_Event.Event_CallMenu += EventContainer.Container.Resolve<IXQCallMenu>().CallMenu;
            }
            return 0;
        }
    }
}