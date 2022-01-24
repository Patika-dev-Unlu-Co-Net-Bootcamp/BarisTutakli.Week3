using BarisTutakli.WebApi.Services.Abstract;
using System;

namespace BarisTutakli.WebApi.Services
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine($"[DBLogger]: {message}");
        }
    }
}
