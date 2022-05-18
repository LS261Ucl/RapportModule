using AutoMapper;
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

namespace UnitTest
{
    public class TemplateControllerTest
    {
        private readonly TemplateService _sut;
        private readonly Mock<IGenericRepository<Template>> _repositoryMock = new Mock<IGenericRepository<Template>>();

        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        private int Id;
        public TemplateControllerTest()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            var mapper = mockMapper.CreateMapper();
            _sut = new TemplateService( _repositoryMock.Object, mapper);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnTemplate_WhenTemplatExist()
        {
            //Arrange
            var templateId = Id;
            var templateTitel = "Test";
            
            var template = new Template
            {
                Id = templateId,
                Title = templateTitel
            };

            _repositoryMock.SetupIgnoreArgs(x => x.GetAsync(x => x.Id == templateId, null))
                .ReturnsAsync(template);

            //Act
            var templateTest = await _sut.GetTemplateById(templateId);


            //Assert
            Assert.Equal(templateTest!.Id, templateId);
            Assert.Equal(templateTest!.Title, templateTitel);

        }

        //[Fact]
        //public async Task GetById_WhenTemplateDoesNotExist_ShouldReturnNothing()
        //{
        //    //Arrange
        //    var templateId = Id;

        //    _repositoryMock.SetupIgnoreArgs(x => x.GetAsync(x => x.Id == templateId, null))
        //      .ReturnsAsync(()=> null);

        //    //Act
        //    var templateTest = await _sut.GetTemplateById(templateId);
        //    var result = templateTest.Return as NotFoundResult;

        //    //Assert

        //    Assert.Equal(result.StatusCode, StatusCodeResult.)
        //}

        //[Fact]
        //public async Task Create_WhenTemplateIsCreated_ShouldReturnCategory()
        //{
        //    var templateName = "Test";

        //    var requestDto = new CreateTemplateDto
        //    {
        //        Title = templateName,
             
        //    };


        //    _repositoryMock.Setup(x => x.CreateAsync(It.IsAny<Template>()))
        //       .ReturnsAsync(() => true);


        //    var response = await _sut.CreateTemplate(requestDto);

        //    var result = response.Result as CreatedAtActionResult;
        //    var category = result?.Value as ProductCategoryDto;

        //    Assert.Equal(categoryName, category?.Name);
        //    Assert.Equal(StatusCodes.Status201Created, result?.StatusCode);
        //}
    }
}