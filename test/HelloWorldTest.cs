using System;
using src.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace test
{
    public class HelloWorldTest
    {
        [Fact]
        public void GetReturns_HelloWorld()
        {
            const string helloWorld = "Hello World";
            var controller = new HelloWorldController();
            var result = controller.Get() as OkObjectResult;
            Assert.Equal(helloWorld, result.Value);
        }
    }
}
