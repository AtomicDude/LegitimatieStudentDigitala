using LegitimatieStudentDigitala.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace LegitimatieStudentDigitala.Utility
{
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<role> _roles;
        public AuthorizationAttribute(params role[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizationStatusCodeObject = new JsonResult(new { Message = "Unauthorized" })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };

            if (_roles == null)
            {
                context.Result = unauthorizationStatusCodeObject;
            }

            var user = (User)context.HttpContext.Items["user"];
            if (user != null || !_roles.Contains(user.Rol))
            {
                context.Result = unauthorizationStatusCodeObject;
            }

        }
    }
}
