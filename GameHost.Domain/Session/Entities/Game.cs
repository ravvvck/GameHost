using GameHost.Domain.Common.Models;
using GameHost.Domain.Session.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Session.Entities
{
    public sealed class Game : Entity<GameId>
    {
        public string Name { get; }
        public string Description { get; }
        public string InfoURL { get; set; }

        private Game(GameId gameId, string name, string description, string infoURL) : base(gameId)
        {
            Name = name;
            Description = description;
            InfoURL = infoURL;

        }

        public static Game Create(string name, string description, string infoURL)
        {
            return new(GameId.CreateUnique(), name, description, infoURL);
        }
        


    }
}
