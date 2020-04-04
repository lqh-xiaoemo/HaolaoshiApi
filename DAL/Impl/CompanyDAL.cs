using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class CompanyDAL : BaseDAL<Company>, ICompanyDAL
    {
        public CompanyDAL(MyDbContext db) : base(db)
        {
        }
    }
}
