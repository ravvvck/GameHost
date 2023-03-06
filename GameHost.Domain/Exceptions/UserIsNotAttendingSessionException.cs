using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Exceptions
{
    public class UserIsNotAttendingSessionException : DomainException
    {
        public UserIsNotAttendingSessionException(string message) : base(message)
        { }
    }
}
