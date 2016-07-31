using SmartWizardProject.Persistences.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWizardProject.Services.Interfaces
{
    public interface IWizardService
    {
        
        //save the record
        void SaveWizard(Organisation Organisation);


        //get organisation records
        List<Organisation> GetOrganisations();

        //get user records
        List<User> GetUsers();


    }
}
