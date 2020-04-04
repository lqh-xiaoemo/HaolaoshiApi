using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class GradeBll : BaseBll<Grade>, IGradeBll
    {
        public GradeBll(IGradeDAL dal):base(dal)
        {
        }
    }
}
