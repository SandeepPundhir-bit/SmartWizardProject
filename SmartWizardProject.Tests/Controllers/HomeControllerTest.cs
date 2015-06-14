using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartWizardProject;
using SmartWizardProject.Controllers;
using SmartWizardProject.Persistences.Domain.Models;
using SmartWizardProject.Models;
using SmartWizardProject.Services.Implements;
using SmartWizardProject.Services.Interfaces;

namespace SmartWizardProject.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            //view data
            var model =(WizardViewModel)result.ViewData.Model; //need to cast some values here

           
            // Assert check the org id is exist
            Assert.AreEqual(true,model.Organisation.Id != null);



        }


        [TestMethod]
        public void Step5Summary()
        {

            HomeController controller = new HomeController();

            ViewResult result = controller.Step5Summary() as ViewResult;

            var model = result.ViewData.Model; //need to cast some values here

            IWizardService service = new WizardServices();
            var getUsers = service.GetUsers();


            var modelView = new WizardViewModel()
            {
                Users = getUsers
            };

            //check if the user is empty
            Assert.AreEqual(true, getUsers.Count == 0);

        }

         
    }
}
