using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigServices
{
    public class LayeredConfigReader : IConfigReader
    {
        private IEnumerable<IConfigservice> _configservices;

        public LayeredConfigReader(IEnumerable<IConfigservice> configservices)
        {
            _configservices = configservices;
        }

        public string GetValue(string name)
        {
            string ReturnValue = null;

            foreach (var service in _configservices)
            {
                string newValue = service.GetValue(name);
                if (newValue!=null)
                {
                    ReturnValue = newValue;//會得到最後一個不為NULL的值
                }
            }

            return ReturnValue;
        }
    }
}
