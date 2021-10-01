using FluentAssertions;
using System;
using System.Net.Http;
using Xunit;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Points.Server.Test.UnitTests
{
    [Trait("Category", "Integration Test")]
    public class AccessControlintegrationTest
    {
        private readonly string _serverUrl;
        public AccessControlintegrationTest()
        {
            _serverUrl = "https://localhost:5001/";
        }

        [Fact]
        public void ConnectApi_WithNonreachableUrl_ReturnsBadRequestStatus()
        {

            var requestUrl = $"{_serverUrl}AccessControl";

            var client = new HttpClient();

            Func<Task> act = async () => await client.GetAsync(requestUrl);

            act.Should().ThrowAsync<SocketException>().WithMessage("Internal error");
        }


        [Fact]
        public async Task ConnectApi_WithGetAccessControl_ReturnsHttopStatusOkay()
        {
            var requestUrl = $"{_serverUrl}AccessControl";
            var client = new HttpClient();

            var response = await client.GetAsync(requestUrl);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}