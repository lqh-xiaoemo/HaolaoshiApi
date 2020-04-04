using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class CourseBll : BaseBll<Course>, ICourseBll
    {
        public CourseBll(ICourseDAL dal):base(dal)
        {
        }
    }
}
