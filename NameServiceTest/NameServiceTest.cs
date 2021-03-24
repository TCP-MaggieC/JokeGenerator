using NUnit.Framework;
using NameService;
using NameService.Contracts;

namespace NameServiceTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}

        [Test]
        public void GetName()//(INameCheckService service)
        {
            var service = new NameCheckService("https://www.names.privserv.com/api/");
            var res = service.GetName();
            Assert.IsNotNull(res);

           
        }
    }
}