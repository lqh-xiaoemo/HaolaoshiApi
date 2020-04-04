using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class ClasssBll : BaseBll<Classs>, IClasssBll
    {
        public ClasssBll(IClasssDAL dal):base(dal)
        {
        }
    }
}
