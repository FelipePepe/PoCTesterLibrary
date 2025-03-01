using System;
using System.Collections.Generic;
using System.Text;
using TestLibrary.dto;

namespace TestLibrary
{
    public class Class1
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

        public OrderDTO Method5(OrderDTO dto)
        {
            return dto;
        }
    }
}
