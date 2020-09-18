namespace XQ.Net.SDK.Models
{
    public class BaseModel
    {
        /// <summary>
        /// 自带的XQAPI对象
        /// </summary>
        public XQAPI XQAPI { get; private set; }

        public BaseModel(XQAPI api)
        {
            XQAPI = api;
        }
    }
}