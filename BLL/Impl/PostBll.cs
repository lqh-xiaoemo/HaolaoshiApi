using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class PostBll : BaseBll<Post>, IPostBll
    {
        public PostBll(IPostDAL dal):base(dal)
        {
        }
    }
}
