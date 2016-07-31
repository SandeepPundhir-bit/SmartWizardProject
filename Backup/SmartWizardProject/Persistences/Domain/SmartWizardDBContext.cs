using SmartWizardProject.Persistences.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartWizardProject.Persistences.Domain
{

    //Initialization the DB
    public class SmartWizardDBContext : DbContext
    {
        //using the web.config connection string
        public SmartWizardDBContext()
            : base("WizardConnection")
        {
        }
         
        //using DBSet to initialization tables
        public DbSet<User> Users { get; set; } 
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
    }
}