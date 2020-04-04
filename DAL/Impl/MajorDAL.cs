using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class MajorDAL : BaseDAL<Major>, IMajorDAL
    {
        public MajorDAL(MyDbContext db) : base(db)
        {
        }
    }
}
