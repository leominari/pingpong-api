using System;
using System.Collections.Generic;

namespace campeonato.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TournamentPlayer> Tournaments { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}