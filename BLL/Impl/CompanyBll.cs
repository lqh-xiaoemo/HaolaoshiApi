using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class CompanyBll : BaseBll<Company>, ICompanyBll
    {
        public CompanyBll(ICompanyDAL dal):base(dal)
        {
        }
    }
}
