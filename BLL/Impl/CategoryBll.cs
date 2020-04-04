using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class CategoryBll : BaseBll<Category>, ICategoryBll
    {
        public CategoryBll(ICategoryDAL dal):base(dal)
        {
        }
    }
}
