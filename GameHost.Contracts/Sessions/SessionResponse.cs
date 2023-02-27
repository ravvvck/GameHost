using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Hosts.ValueObjects;
using GameHost.Domain.Sessions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Contracts.Sessions
{
    public class SessionResponse
    {
        public SessionId SessionId { get; set; }
        public HostId HostId { get; set; }
        public Address Address { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool AlreadyHappend { get; set; }
        public DateTime Date { get; set; }
        public List<GameResponse> Games { get; set; }
    }

    public class GameResponse
    {
        public GameId GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string InfoURL { get; set; }
    }
    //public record SessionResponse(
    //SessionId SessionId,
    //HostId HostId,
    //string Name,
    //string Description,
    //List<GameResponse> Games,
    //DateTime Date);
    //public record GameResponse(
    //    GameId GameId,
    //    string Name,
    //    string Description,
    //    string InfoURL);
        
    
}
