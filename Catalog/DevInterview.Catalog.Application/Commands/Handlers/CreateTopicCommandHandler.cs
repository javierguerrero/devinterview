using DevInterview.Catalog.Domain.Entities;
using DevInterview.Catalog.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.Catalog.Application.Commands.Handlers
{
    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, int>
    {
        private readonly ITopicRepository _topicRepository;

        public CreateTopicCommandHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<int> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = new Topic()
            {
                Name = request.name,
                Description = request.description,
                SubjectId = request.subjectId
            };
            return await _topicRepository.CreateTopic(topic);
        }
    }
}