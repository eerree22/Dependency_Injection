using System;

namespace ConfigServices
{
    public class EnvVarConfigservice : IConfigservice
    {

        public string GetValue(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }
    }
}
