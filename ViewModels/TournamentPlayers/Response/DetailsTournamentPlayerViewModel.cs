using System;
using System.Collections.Generic;
using campeonato.ViewModels.Player.Response;

namespace campeonato.ViewModels.TournamentPlayers.Response
{
    public class DetailsTournamentPlayerViewModel
    {
        public List<ListPlayerViewModel> Players { get; set; }
        public string TournamentName { get; set; }
        public DateTime Start { get; set; }
    }
}