
namespace GameHost.Domain.Exceptions
{
    public class UserIsAlreadyAttendingSessionException : DomainException
    {
        public UserIsAlreadyAttendingSessionException(string message) : base(message)
        { }
    }
}
