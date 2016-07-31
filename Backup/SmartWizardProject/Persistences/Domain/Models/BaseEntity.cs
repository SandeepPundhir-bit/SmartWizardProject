using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SmartWizardProject.Persistences.Domain.Models 
{
    public abstract class BaseEntity
    {       
        public virtual Guid Id { get; set; }
        public virtual DateTime CreateOn { get; set; }

        public BaseEntity()
        {
            CreateOn = DateTime.Now;
            Id = Guid.NewGuid();
        }

        
    }
}
