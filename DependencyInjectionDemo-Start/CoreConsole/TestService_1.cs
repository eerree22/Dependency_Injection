using System;
using System.Collections.Generic;
using System.Text;

namespace CoreConsole
{
    public class TestService_1 : ITestService
    {
        public string Name { get; set; }

        public void SayHi()
        {
            Console.WriteLine($"你好我叫{Name}");
        }


    }
}
