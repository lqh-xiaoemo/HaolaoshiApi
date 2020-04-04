using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class UsualScoreItemDAL : BaseDAL<UsualScoreItem>, IUsualScoreItemDAL
    {
        public UsualScoreItemDAL(MyDbContext db) : base(db)
        {
        }
    }
}
