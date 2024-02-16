﻿using MediatR;

namespace DevInterview.AdminPanel.Application.Commands
{
    public record UpdateRoleCommand(string roleId, string name) : IRequest<string>;
}