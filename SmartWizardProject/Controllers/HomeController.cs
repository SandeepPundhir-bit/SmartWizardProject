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

namespace SmartWizardProject.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
           //pass the model into the controller
            var model = new WizardViewModel()
            {
                Organisation = new Organisation(),
                PrimaryUser = new User(),
                SecondaryUser = new User()
            };

            return View(model);
        }



        /// <summary>
        /// ajax get to load the content
        /// </summary>
        /// <returns></returns>
        public ActionResult Step5Summary()
        {           
            //using service to get the userss
            IWizardService service = new WizardServices();
            var getUsers = service.GetUsers();

            var model = new WizardViewModel()
            {
                Users = getUsers
            };


            return PartialView(model);

        }

         
    }
}
