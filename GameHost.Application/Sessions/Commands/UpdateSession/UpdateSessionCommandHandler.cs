//using GameHost.Application.Authentication.Authorization;
//using GameHost.Application.Common.Interfaces.Persistence;
//using GameHost.Application.Exceptions;
//using GameHost.Application.Sessions.Commands.DeleteSession;
//using GameHost.Contracts.Sessions;
//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GameHost.Application.Sessions.Commands.UpdateSession
//{
//    internal class UpdateSessionCommandHandler : IRequestHandler<UpdateSessionCommand, SessionResponse>
//    {
//        private readonly ISessionRepository sessionRepository;
//        private readonly IHttpContextAccessor httpContextAccessor;
//        private readonly IAuthorizationService authorizationService;

//        public UpdateSessionCommandHandler(ISessionRepository sessionRepository, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService)
//        {
//            this.sessionRepository = sessionRepository;
//            this.httpContextAccessor = httpContextAccessor;
//            this.authorizationService = authorizationService;
//        }
//        public async Task<SessionResponse> Handle(UpdateSessionCommand request, CancellationToken cancellationToken)
//        {
//            var user = httpContextAccessor.HttpContext.User;
//            var oldSession = await sessionRepository.GetById(request.SessionId);
//            var authorizationResult = await authorizationService
//            .AuthorizeAsync(user, oldSession, new UserIsHostRequirement(ResourceOperation.Delete));

//            if (!authorizationResult.Succeeded)
//            {
//                throw new ForbidException();
//            }


//            var updatedSession = await sessionRepository.Update()
//            return Unit.Value;
//        }
    
//    }
//}
