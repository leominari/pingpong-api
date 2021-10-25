using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace campeonato.ViewModels
{
    public class CreateTournamentViewModel
    {
        [Required] public string Name { get; set; }

        [Required]
        public DateTime? Start { get; set; } = null;
        
    }
}