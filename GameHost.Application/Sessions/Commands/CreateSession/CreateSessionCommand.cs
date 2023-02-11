using GameHost.Domain.Common.ValueObjects;
using GameHost.Domain.Hosts;
using GameHost.Domain.Sessions;
using GameHost.Domain.Users.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Application.Sessions.Commands.CreateSession
{
    public class CreateSessionCommand : IRequest<Session>
        {
    public UserId UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Address Address { get; set; }
    public DateTime Date { get; set; }
    public List<GameCommand> Games { get; set; }
            }

public class GameCommand
    {
    public string Name { get; set; }
public string Description { get; set; }
public string InfoURL { get; set; }
}
    //public record CreateSessionCommand(
    //string HostId,
    //string Name,
    //string Description,
    //Address Address,
    //DateTime Date,
    //List<GameCommand> Games) : IRequest<Session>;

    //public record GameCommand(
    //string Name,
    //string Description,
    //string InfoURL
    //);


}
