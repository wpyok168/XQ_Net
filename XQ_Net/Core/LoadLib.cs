using Newtonsoft.Json;
using System.Runtime.InteropServices;
using XQ.Net.SDK;
using XQ.Net.SDK.Models;

namespace XQ_Net.Core
{
    class LoadLib
    {
        /// <summary>
        /// 插件启动入口<para>尽量不要在本函数下执行耗时操作 如果有需求可启动线程或者异步执行</para>
        /// </summary>
        /// <param name="vol"></param>
        /// <returns>返回json文本字符串</returns>
        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static string XQ_Create(string vol)
        {
            AppInfo appInfo = new AppInfo();
            appInfo.name = "先驱C# SDK";//插件名称,请注意与程序集名称保持一致
            appInfo.pver = "1.0.0";//插件版本
            appInfo.author = "福建-兮";//插件作者
            appInfo.desc = "先驱C#SDK";//插件说明
            appInfo.sver = 3;//SDK版本，如无必要，请勿更改
            string json = JsonConvert.SerializeObject(appInfo);
            EventContainer.Init();
            Common.xQAPI.SetAppInfo(appInfo);
            return json;
        }

        /// <summary>
        /// 需要在此子程序下结束线程和关闭组件释放内存资源，否则可能引起程序异常(如果未加载任何对象内存资源可以删掉此函数)
        /// </summary>
        /// <returns></returns>
        [DllExport]
        public static int XQ_DestroyPlugin()
        {
            return 1;
        }

        /// <summary>
        /// 收到AUTOID事件 ，如无必要请不要删除和改动本函数
        /// </summary>
        /// <param name="id">插件在框架中的序号</param>
        /// <param name="IMAddr">插件在框架中load的的地址</param>
        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static void XQ_AuthId(short id, int IMAddr) => AuthCode(id, IMAddr);

        [DllExport(CallingConvention = CallingConvention.StdCall)]
        public static void XQ_AutoId(short id, int IMAddr) => AuthCode(id, IMAddr);

        public static void AuthCode(short id, int IMAddr)
        {
            Common.xQAPI.SetAuthID(id, IMAddr);
        }
    }
}
