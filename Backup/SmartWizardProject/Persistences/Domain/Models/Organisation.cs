using SmartWizardProject.Persistences.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartWizardProject.Persistences.Domain.Models 
{
    public class Organisation : BaseEntity
    {
        [Required]
        public string OrganisationName { get; set; }

        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public CountryType Country { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public virtual IList<User> Users { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }
    }
}