using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class PostDAL : BaseDAL<Post>, IPostDAL
    {
        public PostDAL(MyDbContext db) : base(db)
        {
        }
    }
}
