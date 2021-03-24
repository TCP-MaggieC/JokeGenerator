using NUnit.Framework;
using JokeService;
using JokeService.Contracts;

using Moq;

namespace JokeServiceTest
{
    public class JsonFeedTest
    {
        Mock<IJsonFeed> mockFeed;
        JsonFeed systemUnderTest;

        [SetUp]
        public void Setup()
        {
          //  Mock<IJsonFeed> mockFeed;
        }

        [Test]
        public void GetRandomJokes()// (string[] expectedResult)
        {
            
            var request = new JokeRequest();
            request.FirstName = "Maggie";
            request.LastName = "Chen";
            request.Category = "animal";// "aminal";
            request.Uri = "https://api.chucknorris.io";
            var feed = new JsonFeed();// ("https://api.chucknorris.io");//, 1);
            var res = feed.GetRandomJokes(request);
            Assert.IsNotNull(res);

            //mockFeed = new Mock<IJsonFeed>(MockBehavior.Strict);
            //mockFeed.Setup(p => p.GetRandomJokes(request)).Returns(expectedResult);

            //systemUnderTest = new JsonFeed();
            //var result = systemUnderTest.GetRandomJokes(request);
            //Assert.IsNotNull(result);
        }


        [Test]
        public void GetCategories()
        {
            var request = new CategoryRequest();
            var feed = new JsonFeed();// ("https://api.chucknorris.io");//, 1);
            request.Uri = "https://api.chucknorris.io";
            var res = feed.GetCategories(request);

            Assert.IsNotNull(res);
        }

        [Test]
        public void GetNames()
        {
            var request = new NameRequest();
            var feed = new JsonFeed();// ("https://api.chucknorris.io");//, 1);
            request.Uri = "https://www.names.privserv.com/api/";
            var res = feed.GetNames(request);

            Assert.IsNotNull(res);
        }
    }
}