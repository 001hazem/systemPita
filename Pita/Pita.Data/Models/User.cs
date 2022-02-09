using Microsoft.AspNetCore.Identity;
using Pita.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pita.Data.Models
{
   public class User : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public UserType UserType { get; set; }
        public int ZoneId { get; set; }
        public Zone Zone { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ContentStatus Status { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public List<Email> Emails { get; set; }
        public List<Notification> Notifications { get; set; }
        public User()
        {
            Status = ContentStatus.Pending;
        }
    }
}
