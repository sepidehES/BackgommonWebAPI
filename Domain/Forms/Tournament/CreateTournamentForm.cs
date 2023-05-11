using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Forms.User
{
    public class CreateTournamentForm
    {
        [Required]
        [MinLength(2)]
        public string TournamentName { get; set; }
        public string Description { get; set; }
        [Required]
        public int MaxPlayer { get; set; }
    }
}
