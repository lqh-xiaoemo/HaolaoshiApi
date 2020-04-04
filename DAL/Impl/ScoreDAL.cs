using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class ScoreDAL : BaseDAL<Score>, IScoreDAL
    {
        public ScoreDAL(MyDbContext db) : base(db)
        {
        }
    }
}
