﻿using Rapport.Client.Interfaces;
using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportElement;

namespace Rapport.Client.Service
{
    public class ReportElementService : IReportElementService
    {
        public event Action OnChange;

        private readonly IHttpService _httpService;

        public ReportElementService(IHttpService httpServices)
        {
            _httpService = httpServices;
        }


        public async Task<ReportElementDto> CreateElementAsync(CreateReportElementDto requestDto)
        {

            try
            {

                var wrapper = await _httpService.Post<CreateReportElementDto, ReportElementDto>("reportfield", requestDto);
                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception("unable to get httpservice", ex);
            }

        }

        public Task<ReportElementDto> CreateReportElementAsync(CreateReportElementDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<ReportElementDto> GetReportElementDto(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReportElement(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReportElement> UpdateReportElementById(string id, ReportElementDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
