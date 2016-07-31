using SmartWizardProject.Persistences.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartWizardProject.Models
{


    /// <summary>
    /// View Model passed for wizard view
    /// </summary>
    public class WizardViewModel
    {
        public Organisation Organisation { get; set; }

        public User PrimaryUser { get; set; }

        public User SecondaryUser { get; set; }

        public Questionnaire Questionnaire { get; set; }

        public List<User> Users { get; set; }

    }



   

}