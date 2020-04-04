using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class InterviewDAL : BaseDAL<Interview>, IInterviewDAL
    {
        public InterviewDAL(MyDbContext db) : base(db)
        {
        }
    }
}
