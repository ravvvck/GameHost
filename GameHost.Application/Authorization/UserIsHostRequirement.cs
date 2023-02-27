using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Authentication.Authorization
{
   
        public enum ResourceOperation
        {
            Create,
            Read,
            Update,
            Delete
        }
        public class UserIsHostRequirement : IAuthorizationRequirement
        {
            public UserIsHostRequirement(ResourceOperation resourceOperation)
            {
                ResourceOperation = resourceOperation;
            }

            public ResourceOperation ResourceOperation { get; set; }
        }
}

