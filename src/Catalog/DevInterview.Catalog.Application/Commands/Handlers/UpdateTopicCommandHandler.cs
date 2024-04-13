using AutoMapper;
using DevInterview.Catalog.Domain.Entities;
using DevInterview.Catalog.Domain.Interfaces;
using MediatR;

namespace DevInterview.Catalog.Application.Commands.Handlers
{
    public class UpdateTopicCommandHandler : IRequestHandler<UpdateTopicCommand, int>
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;

        public UpdateTopicCommandHandler(ITopicRepository topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
        {

            var topic = new Topic
            {
                Id = request.topicId,
                Name = request.name,
                Description = request.description,
                SubjectId = request.subjectId,
            };
            return await _topicRepository.UpdateTopic(topic);
        }
    }
}
