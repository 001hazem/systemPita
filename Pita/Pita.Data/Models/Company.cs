using Pita.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pita.Data.Models
{
    public class Company: BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string LogoImage { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public int ZoneId { get; set; }
        public Zone Zone { get; set; }

        public ContentStatus Status { get; set; }

        public List<CategoryCompany> CategoryCompanies { get; set; }



        public Company()
        {
            Status = ContentStatus.Pending;
        }


    }
}
