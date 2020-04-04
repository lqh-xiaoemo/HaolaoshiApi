using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class CategoryDAL : BaseDAL<Category>, ICategoryDAL
    {
        public CategoryDAL(MyDbContext db) : base(db)
        {
        }
    }
}
