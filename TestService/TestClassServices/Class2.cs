using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services;

namespace TestClassServices
{
    public class Class2
    {
        [WebMethod]
        public String sayBye()
        {
            return "Bye";
        }
    }
}
