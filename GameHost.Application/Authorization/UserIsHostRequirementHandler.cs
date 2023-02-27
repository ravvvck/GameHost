using GameHost.Application.Authentication.Authorization;
using GameHost.Domain.Hosts.ValueObjects;
using GameHost.Domain.Sessions;
using GameHost.Domain.Users.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Authorization
{

    public class UserIsHostRequirementHandler : AuthorizationHandler<UserIsHostRequirement, Session>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserIsHostRequirement requirement, Session session)
        {
            if (requirement.ResourceOperation == ResourceOperation.Read || requirement.ResourceOperation == ResourceOperation.Create)
            {
                context.Succeed(requirement);
            }
            var sessionHostUserId = session.Host.User.Id;
            var userId = UserId.Create(Guid.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value));
            if (sessionHostUserId.Value == userId.Value)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
