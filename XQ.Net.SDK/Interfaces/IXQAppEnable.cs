using XQ.Net.SDK.EventArgs;

namespace XQ.Net.SDK.Interfaces
{
    /// <summary>
    /// 插件被关闭
    /// </summary>
    public interface IXQAppEnable
    {
        /// <summary>
        /// 主入口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AppEnable(object sender, XQEventArgs e);
    }
}