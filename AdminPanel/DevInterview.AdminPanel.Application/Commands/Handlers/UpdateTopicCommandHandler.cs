using AutoMapper;
using DevInterview.AdminPanel.Domain.Entities;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class UpdateTopicCommandHandler : IRequestHandler<UpdateTopicCommand, string>
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;

        public UpdateTopicCommandHandler(ITopicRepository topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
        {

            var topic = new Topic
            {
                TopicId = request.topicId,
                Name = request.name,
                Description = request.description,
                RoleId = request.roleId,
            };
            return await _topicRepository.UpdateTopic(topic);
        }
    }
}
