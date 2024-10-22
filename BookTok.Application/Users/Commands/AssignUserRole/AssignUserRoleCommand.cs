﻿using MediatR;

namespace BookTok.Application.Users.Commands.AssignUserRole;

public class AssignUserRoleCommand: IRequest
{
    public string UserEmail { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
