using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class CourseResDAL : BaseDAL<CourseRes>, ICourseResDAL
    {
        public CourseResDAL(MyDbContext db) : base(db)
        {
        }
    }
}
