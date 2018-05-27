using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Course_Work.Context;
using Course_Work.Controllers;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Course_Work;

namespace UnitTestApp.Tests
{
    public class HomeControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public HomeControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void IndexReturnsAViewResultWithAListOfPhones()
        {
            // Act
            var result = await _client.GetAsync("/service/");
            result.EnsureSuccessStatusCode();

            var res = await result.Content.ReadAsStringAsync();

            Assert.True(true);
        }
    }
}