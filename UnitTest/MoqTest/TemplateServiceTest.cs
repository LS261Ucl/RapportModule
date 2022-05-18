using AutoMapper;
using Moq;
using Rapport.BusinessLogig.Interfaces;
using Rapport.BusinessLogig.Mapping;
using Rapport.BusinessLogig.Services;
using Rapport.Entites;
using Rapport.Shared.Dto_er.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Extensions;
using Xunit;

namespace UnitTest.MoqTest
{
    public class TemplateServiceTest
    {
        private readonly TemplateService _sut;
        private readonly Mock<IGenericRepository<Template>> _repositoryMock = new Mock<IGenericRepository<Template>>();

        private int Id;
        public TemplateServiceTest()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            var mapper = mockMapper.CreateMapper();
            _sut = new TemplateService(_repositoryMock.Object, mapper);
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

        [Fact]
        public async Task GetAllAsync_ShouldReturnTemplates_WhenTemplatsExist()
        {
            //Arrange
            var templateId = Id;
            var templateTitel = "Test";

            var template1 = new Template
            {
                Id = 1,
                Title = "Test1"
            };

            var template2 = new Template
            {
                Id = 2,
                Title = "Test2"
            };


            //Act
            var templateTest = await _sut.GetTemplateById(templateId);


            //Assert
            Assert.Equal(templateTest!.Id, templateId);
            Assert.Equal(templateTest!.Title, templateTitel);

        }
    }
}
