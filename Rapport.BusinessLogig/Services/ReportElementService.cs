using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rapport.BusinessLogig.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapport.BusinessLogig.Services
{
    public class ReportElementService : IReportElementService
    {

        public IGenericRepository<ReportElement> _reportElementRepository { get; }
        public IMapper _mapper { get; }
        public ReportElementService(IGenericRepository<ReportElement> reportElementRepository, IMapper mapper)
        {
            _reportElementRepository = reportElementRepository;
            _mapper = mapper;
        }


        public Task<ActionResult<ReportElement>> CreateReportElement([FromBody] CreateReportElementDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> DeleteReportElement(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ReportElementDto>> GetReportElementById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<ReportElementDto>>> GetReportElements()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ReportElement>> UpdateReportElement(int id, UpdateReportElementDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
