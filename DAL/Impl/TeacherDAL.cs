using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class TeacherDAL : BaseDAL<Teacher>, ITeacherDAL
    {
        public TeacherDAL(MyDbContext db) : base(db)
        {
        }
    }
}
