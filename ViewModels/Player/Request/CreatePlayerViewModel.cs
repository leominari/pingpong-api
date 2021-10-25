using System.ComponentModel.DataAnnotations;

namespace campeonato.ViewModels
{
    public class CreatePlayerViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}