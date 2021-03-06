using System;

namespace campeonato.Models
{
    public class TournamentPlayer
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public int Status { get; set; }
    }
}