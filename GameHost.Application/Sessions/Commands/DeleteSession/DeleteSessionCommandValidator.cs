using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Sessions.Commands.DeleteSession
{
    public class DeleteSessionCommandValidator : AbstractValidator<DeleteSessionCommand>
    {
        public DeleteSessionCommandValidator()
        {
            RuleFor(command => command.SessionId).NotNull().NotEmpty().WithMessage("Session id must be provided");
        }
    }
}
