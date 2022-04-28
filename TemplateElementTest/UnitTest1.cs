using NUnit.Framework;
using Rapport.Data;

namespace TemplateElementTest
{
    public class Tests
    {
        private readonly ReportDbContext _context;

        public Tests()
        {

        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}