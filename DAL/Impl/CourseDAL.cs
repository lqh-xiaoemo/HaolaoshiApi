using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class CourseDAL : BaseDAL<Course>, ICourseDAL
    {
        public CourseDAL(MyDbContext db) : base(db)
        {
        }
    }
}
