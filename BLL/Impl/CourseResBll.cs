using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class CourseResBll : BaseBll<CourseRes>, ICourseResBll
    {
        public CourseResBll(ICourseResDAL dal):base(dal)
        {
        }
    }
}
