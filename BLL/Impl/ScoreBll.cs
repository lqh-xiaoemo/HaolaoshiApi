using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class ScoreBll : BaseBll<Score>, IScoreBll
    {
        public ScoreBll(IScoreDAL dal):base(dal)
        {
        }
    }
}
