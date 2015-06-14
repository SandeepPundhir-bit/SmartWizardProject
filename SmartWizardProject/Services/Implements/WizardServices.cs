using SmartWizardProject.Persistences.Domain;
using SmartWizardProject.Persistences.Domain.Models;
using SmartWizardProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SmartWizardProject.Services.Implements
{
    public class WizardServices : IWizardService
    {

        /// <summary>
        /// save the Organisation details, if somethings wrongs happens should log it
        /// </summary>
        /// <param name="Organisation"></param>
        public void SaveWizard(Organisation Organisation)
        {
            using (var entity = new SmartWizardDBContext())
            {
                //get the organisation
                var org = entity.Organisations.SingleOrDefault(d => d.Id == Organisation.Id);
                try
                {
                    //add the record if not exist, otherwise update it
                    if (org == null)
                    {
                        entity.Entry(Organisation).State = System.Data.Entity.EntityState.Added;
                        entity.Organisations.Add(Organisation);
                    }
                    else
                    {
                        this.UpdateRecord(entity, org, Organisation);
                    }


                    entity.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    var errs = from ers in ex.EntityValidationErrors
                               from err in ers.ValidationErrors
                               select err.ErrorMessage;
                    //Log it
                    throw;
                }
                catch (Exception ex)
                {
                    //Log it
                    throw;
                }
            }
        }


        private void UpdateRecord(DbContext context, Organisation dataInDb, Organisation newData)
        {
            var expectOrgProperties = new string[] { "Id", "CreateOn","Users","Questionnaire"};
            context.Entry(dataInDb).State = System.Data.Entity.EntityState.Modified;
            update(expectOrgProperties, dataInDb, newData);

            expectOrgProperties = new string[] { "Id", "CreateOn", "Organisation" };
            var users = newData.Users;
            foreach (var user in users)
            {
                var existUser = dataInDb.Users.SingleOrDefault(d => d.Id == user.Id);
                context.Entry(existUser).State = System.Data.Entity.EntityState.Modified;
                update(expectOrgProperties, existUser, user);
            }

            var questionaire = newData.Questionnaire;
            context.Entry(dataInDb.Questionnaire).State = System.Data.Entity.EntityState.Modified;
            update(expectOrgProperties, dataInDb.Questionnaire, newData.Questionnaire);

        }


        private void update<T>(string[] Ids, T dataInDb, T newData)
        {
            foreach (var p in newData.GetType().GetProperties().Where(p => !Ids.Contains(p.Name)))
            {
                if (p.CanWrite)
                {
                    p.SetValue(dataInDb, p.GetValue(newData), null);
                }
            }
        }




        /// <summary>
        /// get all the organisations
        /// </summary>
        /// <returns></returns>
        public List<Organisation> GetOrganisations()
        {
            var organisations = new List<Organisation>();
            using (var entity = new SmartWizardDBContext())
            {
                //includes the foreign tables
                organisations = entity.Organisations.Include("Users").Include("Questionnaire").ToList();
            }

            return organisations;


        }



        /// <summary>
        /// get all the users
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            var users = new List<User>();
            using (var entity = new SmartWizardDBContext())
            {
                //get all users and includes organsaions
                var getUsers = entity.Users.Include("Organisation").ToList();

                //omit firstname null and order by organisation name
                users = getUsers.Where(d => d.FirstName != null).OrderBy(d => d.Organisation.OrganisationName).ToList();

            }



            return users;
        }





    }
}