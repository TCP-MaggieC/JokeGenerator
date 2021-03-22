using NUnit.Framework;
using JokeService;

namespace JokeServiceTest
{
    public class JsonFeedTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetRandomJokes()
        {

            var feed = new JsonFeed("https://api.chucknorris.io", 1);
            var request = new JokeRequest();
            request.FirstName = "Maggie";
            request.LastName = "Chen";
            request.Category = "animal";// "aminal";
            var res = feed.GetRandomJokes(request);
            Assert.IsNotNull(res);
        }


        [Test]
        public void GetCategories()
        {

            var feed = new JsonFeed("https://api.chucknorris.io", 1);

            var res = feed.GetCategories();

            Assert.IsNotNull(res);
        }
    }
}