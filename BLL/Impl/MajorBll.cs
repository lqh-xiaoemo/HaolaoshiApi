using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class MajorBll : BaseBll<Major>, IMajorBll
    {
        public MajorBll(IMajorDAL dal):base(dal)
        {
        }
    }
}
