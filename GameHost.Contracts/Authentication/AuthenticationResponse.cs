using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Contracts.Authentication
{
    public class AuthenticationResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
    //public record AuthenticationResponse 
    //(
    //    Guid Id,
    //    string FirstName,
    //    string LastName,
    //        string Email,
    //        string Token
    //) ;
}
