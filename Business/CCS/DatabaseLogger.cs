using System;

namespace Business.CCS
{
    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log Added to Database");
        }
    }
}
