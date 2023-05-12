using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Forms.TournamentUser
{
    public class CreateTournamentUserForm
    {
        [Required]
        public int TournamentId { get; set; }
        [Required]
        public int PlayerId { get; set; }

    }
}
