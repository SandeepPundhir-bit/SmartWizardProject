using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartWizardProject.Persistences.Domain.Models
{
    public class Questionnaire : BaseEntity
    {
        
        public bool IsJave { get; set; }

        public bool IsCSharp { get; set; }

        public bool IsChinese { get; set; }

        public string FrontendTech { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Only numbers are allowed")]
        public int HtmlVersion { get; set; }

        public string Comment { get; set; }

        public string HearFrom { get; set; }

    }
}