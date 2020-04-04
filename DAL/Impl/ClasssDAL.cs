using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class ClasssDAL : BaseDAL<Classs>, IClasssDAL
    {
        public ClasssDAL(MyDbContext db) : base(db)
        {
        }
    }
}
