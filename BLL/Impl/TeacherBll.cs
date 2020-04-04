using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
using Common.Util;

namespace Bll.Impl
{
    public class TeacherBll : BaseBll<Teacher>, ITeacherBll
    {
        public TeacherBll(ITeacherDAL dal):base(dal)
        {
        }
        public new bool Add(Teacher o)
        {
            o.Pswd = Security.Md5(o.Pswd);
            return dal.Add(o);
        }
        public Teacher Login(string sn, string pswd)
        {
            pswd = Security.Md5(pswd);
            return dal.SelectOne(o => o.Sn == sn && o.Pswd == pswd);
        }
    }
}
