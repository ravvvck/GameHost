using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Sessions.Commands.CreateSession
{
    public class CreateSessionCommandValidator : AbstractValidator<CreateSessionCommand>
    {
        public CreateSessionCommandValidator() 
        {
            RuleFor(session => session.Name).NotEmpty();
            RuleFor(session => session.Address).NotEmpty();
            RuleFor(session => session.Games).NotEmpty();
            RuleFor(session => session.Date).NotEmpty().GreaterThan(DateTime.Now);
        }
    }
}
