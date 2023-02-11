using GameHost.Domain.Common.Models;
using GameHost.Domain.Sessions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHost.Domain.Sessions.Entities
{
    public sealed class Game : Entity<GameId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string InfoURL { get; private set; }
        

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

        private Game()
        {

        }
        


    }
}
