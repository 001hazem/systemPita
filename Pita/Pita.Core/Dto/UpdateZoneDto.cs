using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pita.Core.Dto
{
   public class UpdateZoneDto
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "اسم المنطقة")]
        public string Name { get; set; }
    }
}
