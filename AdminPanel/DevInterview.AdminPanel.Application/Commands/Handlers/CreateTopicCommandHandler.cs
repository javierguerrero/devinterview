using DevInterview.AdminPanel.Domain.Entities;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, string>
    {
        private readonly ITopicRepository _topicRepository;

        public CreateTopicCommandHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<string> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = new Topic()
            {
                Name = request.name,
                Description = request.description,
                RoleId = request.roleId
            };
            return await _topicRepository.CreateTopic(topic);
        }
    }
}