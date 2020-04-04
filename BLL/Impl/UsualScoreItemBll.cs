using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class UsualScoreItemBll : BaseBll<UsualScoreItem>, IUsualScoreItemBll
    {
        public UsualScoreItemBll(IUsualScoreItemDAL dal):base(dal)
        {
        }
    }
}
