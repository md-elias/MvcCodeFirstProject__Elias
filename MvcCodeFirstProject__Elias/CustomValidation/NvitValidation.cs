﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCodeFirstProject__Elias.CustomValidation
{
    public class NvitValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string message = value.ToString();
                if (message.Contains("Mr"))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Must be field Mr or Mrs");
        }
    }
}