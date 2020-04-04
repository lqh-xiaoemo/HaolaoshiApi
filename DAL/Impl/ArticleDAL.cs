using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class ArticleDAL : BaseDAL<Article>, IArticleDAL
    {
        public ArticleDAL(MyDbContext db) : base(db)
        {
        }
    }
}
