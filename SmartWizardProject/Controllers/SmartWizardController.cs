using SmartWizardProject.Filters;
using SmartWizardProject.Models;
using SmartWizardProject.Persistences.Domain.Models;
using SmartWizardProject.Services.Implements;
using SmartWizardProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//remove unnecessary using from above 

using SmartWizardProject.Models;
using SmartWizardProject.Persistences.Domain.Models;
using SmartWizardProject.Services.Implements;
using SmartWizardProject.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
namespace SmartWizardProject.Controllers
{
     
    public class SmartWizardController : Controller
    {
           

        /// <summary>
        /// Ajax load the content
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
 
        [HttpPost]
        public JsonResult SaveSteps(WizardViewModel model)
        {
            var organisation = model.Organisation;
           
            //convert the ef relationship
            organisation.Questionnaire = model.Questionnaire;
            if (organisation.Questionnaire.HtmlVersion == null) 
            {
                organisation.Questionnaire.HtmlVersion = 0; 
            }
            model.PrimaryUser.Organisation = organisation;      
            model.SecondaryUser.Organisation = organisation;        
            organisation.Users = new List<User>() { model.PrimaryUser, model.SecondaryUser };


            IWizardService service = new WizardServices();
            service.SaveWizard(organisation);

            return Json(new { success = true });


        }

          


    }
}
