using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigServices
{
    public interface IConfigReader
    {
        string GetValue(string name);
    }
}
