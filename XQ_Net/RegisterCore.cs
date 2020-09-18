using FZMsTool;
using Unity;
using XQ.Net.SDK.Interfaces;

namespace XQ_Net
{
    public class RegisterCore
    {
        public static void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IXQPrivateMessage, RecPrivateMsg>();
            unityContainer.RegisterType<IXQGroupMessage, RecGroupMsg>();
        }
    }
}
