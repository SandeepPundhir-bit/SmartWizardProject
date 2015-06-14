using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web; 

namespace SmartWizardProject.Persistences.Domain.Models 
{
    public class User : BaseEntity
    {
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public string Type { get; set; }

        public virtual Organisation Organisation { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }


    }
}