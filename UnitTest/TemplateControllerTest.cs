using Microsoft.Extensions.Logging;
using Rapport.Api.Controllers;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Xunit;

namespace UnitTest
{
    public class TemplateControllerTest
    {
        private readonly ITemplateService _service;
        private readonly IGenericRepository<Template> _repository;
        private readonly ILogger<TemplateController> _logger;


        [Fact]
        public void Test1()
        {

        }
    }
}