using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartWizardProject.Services.Extensions
{
    public static class DateExtension
    {
        private const string _auNormalTimeFormat = "hh:mm tt";
        private const string _auNormalDateFormat = "dd/MM/yyyy";
        private const string _auNormalDateTimeFormat = "dd/MM/yyyy hh:mm tt";

        public static string ToAuTime(this DateTime time)
        {
            return time.ToString(_auNormalTimeFormat);
        }


        public static string ToAuDate(this DateTime date)
        {
            return date.ToString(_auNormalDateFormat);
        }

        public static string ToAuDateTime(this DateTime dateTime)
        {
            return dateTime.ToString(_auNormalDateTimeFormat);
        }


    }
}