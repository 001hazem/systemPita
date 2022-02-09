using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pita.Core.Dto
{
   public  class CreateZoneDto
    {

        [Required]
        [Display(Name = "اسم المنطقة")]
        public string Name { get; set; }
    }


}
