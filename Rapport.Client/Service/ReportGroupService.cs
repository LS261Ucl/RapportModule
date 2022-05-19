﻿using Rapport.Entites;
using Rapport.Shared.Dto_er.ReportGroup;

namespace Rapport.Client.Service
{
    public class ReportGroupService : IReportGroupService
    {
        private readonly IHttpService _httpService;

        public ReportGroupService(IHttpService httpServices)
        {
            _httpService = httpServices;
        }

        public event Action OnChange;

        public async Task<ReportGroupDto> CreateReport(int id, CreateReportGroupDto requestDto)
        {
            try
            {

                var wrapper = await _httpService.Post<CreateReportGroupDto, ReportGroupDto>($"reportgroup", requestDto);
                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Httpservice", ex);
            }
        }

        public Task DeleteReportGroup(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ReportGroupDto> GetReportGroupById(int id)
        {
            try
            {
                var wrapper = await _httpService.Get<ReportGroupDto>($"reportgroup/{id}");
                return wrapper.Response ?? throw new HttpRequestException(wrapper.HttpResponseMessage.ReasonPhrase);
            }
            catch (Exception ex)
            {
                throw new Exception("unable to get HttpService", ex);
            }

        }

        public Task<ReportGroup> UpdateReportGroupById(string id, ReportGroupDto requestDto)
        {
            throw new NotImplementedException();
        }

    }
}
