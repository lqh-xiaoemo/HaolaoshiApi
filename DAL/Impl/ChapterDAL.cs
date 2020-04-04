using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class ChapterDAL : BaseDAL<Chapter>, IChapterDAL
    {
        public ChapterDAL(MyDbContext db) : base(db)
        {
        }
    }
}
