using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HttpTests
{
    [Explicit]
    public class HttpTests
    {
        HttpClient _client;
        [OneTimeSetUp]
        public void Setup()
        {
            _client = new HttpClient();
        }

        [Test]
        public async Task AsyncGetTest()
        {
            var google = await _client.GetAsync("http://google.com");

            Assert.IsNotNull(google);

            var content =await  google.Content.ReadAsStringAsync();

            Assert.Greater(content.Length, 10);
        }

        [Test, Sequential]
        public async Task User_Not_Belonging_To_Customer_Returns_NullUser_Object(
            [Random(3)]int userId,             
            [Values(1, 2, 3)]int userCustomerId, 
            [Values(2, 3, 1)]int customerId)
        {
             await AsyncGetTest();
        }
    }
}
