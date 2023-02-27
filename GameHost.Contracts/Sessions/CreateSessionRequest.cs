using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Sessions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Contracts.Sessions
{
    public class CreateSessionRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public DateTime Date { get; set; }
        public List<Game> Games { get; set; }
    }

    public class Game
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string InfoURL { get; set; }
    }
    //public record CreateSessionRequest(
    //string Name,
    //string Description,
    //Address Address,
    //DateTime Date,
    //List<Game> Games){};

    //public record Game(
    //    string Name,
    //    string Description,
    //    string InfoURL
    //   );
   
}
