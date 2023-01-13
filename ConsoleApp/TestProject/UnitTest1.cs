using System;
using Xunit;
using ServiceLib.Services;
using Microsoft.Extensions.Logging;
using ServiceLib.HelperClass;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Credentials credential = new Credentials();
            credential.UserName = "Girma1";
            credential.Password = "Password";


            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<EmployeeService>();
            var svc = new EmployeeService(logger, credential);
            var result = svc.GetEmployeeById(0);
            Assert.Equal("Employee-0", result);

        }
    }
}
