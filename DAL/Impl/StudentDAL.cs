using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL.Impl
{

    public class StudentDAL : BaseDAL<Student>, IStudentDAL
    {
        public StudentDAL(MyDbContext db) : base(db)
        {
        }
    }
}
