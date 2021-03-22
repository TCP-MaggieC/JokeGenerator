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

            var feed = new  JsonFeed("https://api.chucknorris.io", 1);
            var res = feed.GetRandomJokes("maggie", "chen", "animal");
            Assert.IsNotNull(res);
        }
    }
}