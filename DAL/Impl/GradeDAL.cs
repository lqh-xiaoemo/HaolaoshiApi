using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class GradeDAL : BaseDAL<Grade>, IGradeDAL
    {
        public GradeDAL(MyDbContext db) : base(db)
        {
        }
    }
}
