using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class OnlineResumeBll : BaseBll<OnlineResume>, IOnlineResumeBll
    {
        public OnlineResumeBll(IOnlineResumeDAL dal):base(dal)
        {
        }
    }
}
