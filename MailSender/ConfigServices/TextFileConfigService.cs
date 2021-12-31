using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConfigServices
{
    public class TextFileConfigService : IConfigservice
    {
        public string FilePath { get; set; }

        public string GetValue(string name)
        {
            var value = File.ReadAllLines(FilePath).Select(x =>new { Name = x.Split('=')[0], Value = x.Split('=')[1]})
                .Where(y=>y.Name == name).SingleOrDefault();

            if (value!=null)
            {
                return value.Value;
            }

            return null;
        }
    }
}
