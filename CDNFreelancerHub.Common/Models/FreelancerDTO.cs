﻿using CDNFreelancerHub.Common.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace CDNFreelancerHub.Common.Models
{
    public class FreelancerDTO : BaseDTO
    {
        [Required(ErrorMessage = "Please enter first name.")]
        [MaxLength(100, ErrorMessage = "Please enter first name with a maximum of 100 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        [MaxLength(100, ErrorMessage = "Please enter last name with a maximum of 100 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please input email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select status")]
        public StatusEnum Status { get; set; }

        [Required(ErrorMessage = "Please input skils")]
        public string Skills { get; set; }
        public string? Hobby { get; set; }
    }
}
