using System;
using System.Collections.Generic;
using System.Text;

namespace CoreConsole
{
    public class TestService_2 : ITestService
    {
        public string Name { get ; set ; }

        public void SayHi()
        {
            Console.WriteLine($"Hi! My name is {Name}");
        }
    }
}
