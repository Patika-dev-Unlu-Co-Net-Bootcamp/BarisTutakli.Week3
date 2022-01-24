using BarisTutakli.WebApi.Services.Abstract;
using System;

namespace BarisTutakli.WebApi.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine($"[ConsolleLogger]: {message}");
        }
    }
}
