using NUnit.Framework;
using Rapport.Data;
using Xunit.Sdk;

namespace Rapport.Api.UnitTest
{
    public class Tests
    {
        private ReportDbContext? dbContext;
        [SetUp]
        public void Setup(ReportDbContext context)
        {
           dbContext = context;
        }

        [Test]
        public void CreateTemplate_InDatabase_WithTestValues()
        {
            Assert.Pass();
        }
    }
}