using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace Bll.Impl
{
    public class InterviewBll : BaseBll<Interview>, IInterviewBll
    {
        public InterviewBll(IInterviewDAL dal):base(dal)
        {
        }
    }
}
