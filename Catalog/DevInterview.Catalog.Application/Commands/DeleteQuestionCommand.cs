﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.Catalog.Application.Commands
{
    public record DeleteQuestionCommand(int id) : IRequest<bool>;
}
