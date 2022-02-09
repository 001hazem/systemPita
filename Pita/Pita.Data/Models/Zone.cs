﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pita.Data.Models
{
    public class Zone: BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Company> Companies { get; set; }
        public List<User> Users { get; set; }



    }
}
