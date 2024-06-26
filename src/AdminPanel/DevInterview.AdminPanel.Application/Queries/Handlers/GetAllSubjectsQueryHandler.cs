﻿using AutoMapper;
using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetAllSubjectsQueryHandler : IRequestHandler<GetAllSubjectsQuery, IEnumerable<SubjectResponse>>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public GetAllSubjectsQueryHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<IEnumerable<SubjectResponse>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
        {
            var subjects = new List<SubjectResponse>();

            var response = await _webApiGatewayCommunication.GetAllSubjects();

            foreach (var item in response)
            {
                subjects.Add(new SubjectResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Image = item.Image
                });
            }
            return subjects;
        }
    }
}