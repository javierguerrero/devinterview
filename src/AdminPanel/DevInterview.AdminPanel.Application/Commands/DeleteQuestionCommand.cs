using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Application.Commands
{
    public record DeleteQuestionCommand(string id) : IRequest<bool>;
}
