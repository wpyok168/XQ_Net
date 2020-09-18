using Unity;
using XQ.Net.SDK.Interfaces;

namespace XQ_Net.Core
{
    public class EventContainer
    {
        /// <summary>
        /// 容器
        /// </summary>
        public static IUnityContainer Container { get; set; } = new UnityContainer();
        public static void Init()
        {
            RegisterCore.Register(Container);

            if (Container.IsRegistered<IXQAddFriend>())
            {
                _Event.Event_AddFriendHandler += Container.Resolve<IXQAddFriend>().AddFriend;
            }
            if (Container.IsRegistered<IXQAddGroup>())
            {
                _Event.Event_AddGroupHandler += Container.Resolve<IXQAddGroup>().AddGroup;
            }
            if (Container.IsRegistered<IXQAppDisable>())
            {
                _Event.Event_AppDisableHandler += Container.Resolve<IXQAppDisable>().AppDisable;
            }
            if (Container.IsRegistered<IXQAppEnable>())
            {
                _Event.Event_AppEnableHandler += Container.Resolve<IXQAppEnable>().AppEnable;
            }
            if (Container.IsRegistered<IXQBanSpeak>())
            {
                _Event.Event_BanSpeak += Container.Resolve<IXQBanSpeak>().BanSpeak;
            }
            if (Container.IsRegistered<IXQCallMenu>())
            {
                _Event.Event_CallMenu += Container.Resolve<IXQCallMenu>().CallMenu;
            }
            if (Container.IsRegistered<IXQGroupMessage>())
            {
                _Event.Event_GroupMsgHandler += Container.Resolve<IXQGroupMessage>().GroupMessage;
            }
            if (Container.IsRegistered<IXQPrivateMessage>())
            {
                _Event.Event_PrivateMsgHandler += Container.Resolve<IXQPrivateMessage>().PrivateMessage;
            }
            if (Container.IsRegistered<IXQUnBanSpeak>())
            {
                _Event.Event_UnBanSpeak += Container.Resolve<IXQUnBanSpeak>().BanSpeak;
            }
        }
    }
}
