using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommand, bool>
    {
        private readonly ITopicRepository _topicRepository;

        public DeleteTopicCommandHandler(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<bool> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
        {
            return await _topicRepository.DeleteTopic(request.id);
        }
    }
}