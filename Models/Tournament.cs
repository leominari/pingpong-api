using System;
using System.Collections.Generic;

namespace campeonato.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Player Winner { get; set; }
        public virtual ICollection<TournamentPlayer> Players { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finished { get; set; }
        
    }
}