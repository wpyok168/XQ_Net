﻿using XQ.Net.SDK.Models;

namespace XQ.Net.SDK.EventArgs
{
    public class XQAddGroupEventArgs : XQEventArgs
    {
        public string Seq { get; set; }
        public XQQQ FromQQ { get; set; }
        public XQGroup FromGroup { get; set; }

        public XQAddGroupEventArgs(XQAPI api, string robotqq, int eventtype, string qq, string group, string seq) : base(api, robotqq, eventtype)
        {
            FromQQ = new XQQQ(qq, api);
            FromGroup = new XQGroup(group, api);
            Seq = seq;
        }

        //public void Pass()
        //{
        //    XQAPI.HanldeGroupEvent(this.RobotQQ, this.EventType, FromQQ.Id, FromGroup.Id, Seq, Enums.ResponseType.PASS);
        //}
        //public void Refuse()
        //{
        //    XQAPI.HanldeGroupEvent(this.RobotQQ, this.EventType, FromQQ.Id, FromGroup.Id, Seq, Enums.ResponseType.REFUSE);
        //}
        //public void Ignore()
        //{
        //    XQAPI.HanldeGroupEvent(this.RobotQQ, this.EventType, FromQQ.Id, FromGroup.Id, Seq, Enums.ResponseType.IGNORE);
        //}
    }
}