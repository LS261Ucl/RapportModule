using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Rapport.Api.Controllers;
using Rapport.BusinessLogig.Interfaces;
using Rapport.BusinessLogig.Mapping;
using Rapport.BusinessLogig.Services;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Template;
using System.Threading.Tasks;
using UnitTest.Extensions;
using Xunit;

namespace UnitTest.MoqTest
{
    public class TemplateControllerTest
    {

        private readonly TemplateController _controller;
        private readonly Mock<ILogger<TemplateController>> _logger = new Mock<ILogger<TemplateController>>();
        private readonly Mock<ITemplateService> _templateService = new Mock<ITemplateService>();

        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        private readonly CreateTemplateDto createTemplateDto;
        private int Id;
        public TemplateControllerTest()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            var mapper = mockMapper.CreateMapper();
            _controller = new TemplateController(_templateService.Object, _logger.Object, mapper);

        }



        [Fact]
        public async Task GetById_WhenTemplateDoesNotExist_ShouldReturnNothing()
        {
            //Arrange
            var templateId = Id;

            _templateService.SetupIgnoreArgs(x => x.GetTemplateById(templateId))
              .ReturnsAsync(() => null);

            //Act
            var templateTest = await _controller.GetTemplateByIdAsync(templateId);
            var result = templateTest.Result as NotFoundResult;

            //Assert

            Assert.Equal(result.StatusCode, StatusCodes.Status404NotFound);
        }

      
    }
}