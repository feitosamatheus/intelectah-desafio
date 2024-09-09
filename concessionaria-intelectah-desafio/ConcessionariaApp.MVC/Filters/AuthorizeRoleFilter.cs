using ConcessionariaApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ConcessionariaApp.MVC.Filters
{
    public class AuthorizeRoleFilter
    {
        private readonly string _role;

        public AuthorizeRoleFilter(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

                context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
        }
    }
}
