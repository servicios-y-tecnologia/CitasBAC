﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appcitas.DataAnnotations
{
    public class DateValidationAttribute : ValidationAttribute
    {
        public DateValidationAttribute()
        {

        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if (dt <= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}