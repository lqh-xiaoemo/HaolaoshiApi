using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class UsualScoreBll : BaseBll<UsualScore>, IUsualScoreBll
    {
        public UsualScoreBll(IUsualScoreDAL dal):base(dal)
        {
        }
    }
}
