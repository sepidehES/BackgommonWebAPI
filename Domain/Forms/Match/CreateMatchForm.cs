using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Forms.Match
{
    public class CreateMatchForm
    {
        [Required]
        [MinLength(2)]
        public int DateStart { get; set; }

        public int DateEnd { get; set; }

    }
}
