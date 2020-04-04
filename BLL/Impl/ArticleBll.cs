using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class ArticleBll : BaseBll<Article>, IArticleBll
    {
        public ArticleBll(IArticleDAL dal):base(dal)
        {
        }
    }
}
