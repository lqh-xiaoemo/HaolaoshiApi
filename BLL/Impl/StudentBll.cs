using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
using Common.Util;

namespace Bll.Impl
{
    public class StudentBll : BaseBll<Student>, IStudentBll
    {
        public StudentBll(IStudentDAL dal):base(dal)
        {
        }
        public new bool Add(Student o)
        {
            o.Pswd = Security.Md5(o.Pswd);
            return dal.Add(o);
        }
        public Student Login(string sn, string pswd)
        {
            pswd = Security.Md5(pswd);
            return dal.SelectOne(o => o.Sn == sn && o.Pswd == pswd);
        }
    }
}
