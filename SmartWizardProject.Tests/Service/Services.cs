using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartWizardProject.Persistences.Domain.Enums;
using SmartWizardProject.Persistences.Domain.Models;
using SmartWizardProject.Services.Implements;
using SmartWizardProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWizardProject.Tests.Service
{

    [TestClass]
    public class Services
    {

        [TestMethod]
        public void WizardServicesTest()
        {
            IWizardService service = new WizardServices();

            var org = new Organisation()
            {
                OrganisationName = "testOrg",
                UserName = "testOrg@gmail.com",
                Password = "123",
                Address = "111 test st, sydney, nsw, 2000",
                Country = CountryType.Australia,
                Contact = "1111111111"
            };

            org.Users = new List<User>
            {
                new User {FirstName="PFName",LastName="PLName",Email="aaa@test.com",Contact="111"},
                new User {FirstName="SFName",LastName="SLName",Email="aaa@test.com",Contact="222"},
            };

            org.Questionnaire = new Questionnaire()
            {
                FrontendTech = "CSS",
                HearFrom = "facebook",
                IsJave = false,
                IsChinese = false,
                IsCSharp = true,
                HtmlVersion = 5,
                Comment = "TEST"
            };


            try
            {
                service.SaveWizard(org);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

        }

    }
}
