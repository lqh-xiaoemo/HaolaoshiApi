using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class UsualScoreHistoryBll : BaseBll<UsualScoreHistory>, IUsualScoreHistoryBll
    {
        public UsualScoreHistoryBll(IUsualScoreHistoryDAL dal):base(dal)
        {
        }
    }
}
