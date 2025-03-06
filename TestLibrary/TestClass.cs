using System;
using System.Collections.Generic;
using System.Text;
using TestLibrary.dto;

namespace TestLibrary
{
    public class TestClass
    {
        public string Method1()
        {
            return "Hello World";
        }   

        public string Method2()
        {
            return "Hello World 2";
        }

        public void Method3()
        {
            Console.WriteLine("Hello World 3");
        }

        private void Method4()
        {
            Console.WriteLine("Hello World 4");
        }

        public OrderDTOSinLista Method5(OrderDTOSinLista dto)
        {
            return dto;
        }

        public OrderDTO Method6(OrderDTO dto)
        {
            return dto;
        }

        public String ServiceHello()
        {
            String result = string.Empty;

            TestClassServices.Class1 service = new TestClassServices.Class1();
            result = service.sayHello();

            return result;
        }
    }
}
