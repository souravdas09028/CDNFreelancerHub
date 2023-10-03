using CDNFreelancerHub.Common;
using CDNFreelancerHub.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDNFreelancerHub.Core.Entities
{
    public class Freelancer : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        
        public string? Hobby { get; set; }

        [Required]
        public string Skills { get; set; }
    }
}
