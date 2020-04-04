using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class OnlineResumeDAL : BaseDAL<OnlineResume>, IOnlineResumeDAL
    {
        public OnlineResumeDAL(MyDbContext db) : base(db)
        {
        }
    }
}
