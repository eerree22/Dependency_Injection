using System;
using System.Collections.Generic;
using System.Text;

namespace CoreConsole
{
    public class MyController
    {
        private ILog _log;
        private ICloud _cloud;

        public MyController(ILog log, ICloud cloud)
        {
            _log = log;
            _cloud = cloud;
        }

        public void Test()
        {
            _log.WriteLog("開始上傳");

            _cloud.Save("fdsafhlsdjhfsadjkfds", "xyz.txt");

            _log.WriteLog("上傳完成");
        }
    }

    public interface ILog
    {
        void WriteLog(string s);
    }

    public class Log : ILog
    {
        public void WriteLog(string s)
        {
            Console.WriteLine($"Log: {s}");
        }
    }

    public interface IConfig
    {
        string GetValue(string name);
    }

    public class Config : IConfig
    {
        public string GetValue(string name)
        {
            return "GGYY";
        }
    }

    public interface ICloud
    {
        void Save(string content, string name);
    }

    public class Cloud : ICloud
    {
        private IConfig _config;

        public Cloud(IConfig config)
        {
            _config = config;
        }

        public void Save(string content, string name)
        {
            var s =_config.GetValue("SQL Server");
            Console.WriteLine($"向資料庫{s}中的{name}上傳{content}");
        }
    }
}
