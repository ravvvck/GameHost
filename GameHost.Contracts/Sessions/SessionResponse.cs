using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Contracts.Sessions
{
    public record SessionResponse(
    Guid Id,
    string HostId,
    string Name,
    string Description,
    float? AverageRating,
    List<GameResponse> Games,
    DateTime Date,
    List<string> SessionReviewIds);

    public record GameResponse(
        string Id,
        string Name,
        string Description,
        string InfoURL);
        
    
}
