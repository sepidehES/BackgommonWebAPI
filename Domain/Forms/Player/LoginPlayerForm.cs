using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Forms.Player
{
    public class LoginPlayerForm
    {
        [Required]
        public string Pseudo { get; set; }    
        
        [Required]
        public string Password_Hash { get; set; }   

    }
}
