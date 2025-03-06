using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services;

namespace TestClassServices
{
    public class Class1
    {
        [WebMethod]
        public String sayHello()
        {
            return "Hello";
        }
    }
}
