using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace Bll
{
   
    public interface IStudentBll:IBaseBll<Student>
    {
        public Student Login(string sn, string pswd);
    }
}
