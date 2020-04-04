using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class ChapterBll : BaseBll<Chapter>, IChapterBll
    {
        public ChapterBll(IChapterDAL dal):base(dal)
        {
        }
    }
}
