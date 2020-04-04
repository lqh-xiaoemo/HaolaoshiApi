using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class UsualScoreHistoryDAL : BaseDAL<UsualScoreHistory>, IUsualScoreHistoryDAL
    {
        public UsualScoreHistoryDAL(MyDbContext db) : base(db)
        {
        }
    }
}
