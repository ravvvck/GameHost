using GameHost.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Contracts.Events
{
    //public class CreateEventRequest
    //{
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public Address Address { get; set; }
    //    public DateTime Date { get; set; }
    //}
    public record CreateEventRequest(
        string Name,
        string Description,
        Address Address,
        DateTime Date
        );


}
