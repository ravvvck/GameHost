using GameHost.Application.Authentication.Authorization;
using GameHost.Application.Common.Interfaces.Persistence;
using GameHost.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Sessions.Commands.DeleteSession
{
    public class DeleteSessionCommandHandler : IRequestHandler<DeleteSessionCommand, Unit>
    {
        private readonly ISessionRepository sessionRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAuthorizationService authorizationService;

        public DeleteSessionCommandHandler(ISessionRepository sessionRepository, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService)
        {
            this.sessionRepository = sessionRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.authorizationService = authorizationService;
        }
        public async Task<Unit> Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
        {
            var user = httpContextAccessor.HttpContext.User;
            var session = await sessionRepository.GetById(request.SessionId);
            var authorizationResult = await authorizationService
          .AuthorizeAsync(user, session, new UserIsHostRequirement(ResourceOperation.Delete));

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            await Task.Run(() => sessionRepository.Delete(request.SessionId));
            return Unit.Value;
        }
    }
}
