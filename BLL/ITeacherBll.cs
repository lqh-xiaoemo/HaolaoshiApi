using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace Bll
{
   
    public interface ITeacherBll:IBaseBll<Teacher>
    {
        public Teacher Login(string sn, string pswd);
    }
}
