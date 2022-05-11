using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class ReportGroupService : IReportGroupService
    {
        private readonly IGenericRepository<ReportGroup>? _repository;
        private IMapper? _mapper;

        public ReportGroupService(IGenericRepository<ReportGroup> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<ReportGroup> CreateReportGroup([FromBody] CreateReportGroupDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReportGroup(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReportGroupDto> GetReportGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReportGroupDto>> GetReportGroups()
        {
            throw new NotImplementedException();
        }
    }
}
