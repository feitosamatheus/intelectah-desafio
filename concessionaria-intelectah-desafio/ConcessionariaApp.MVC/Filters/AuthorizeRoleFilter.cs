using ConcessionariaApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ConcessionariaApp.MVC.Filters
{
    public class AuthorizeRoleFilter
    {
        private readonly string _role;
        private readonly UserManager<Usuario> _userManager;

        public AuthorizeRoleFilter(string role, UserManager<Usuario> userManager)
        {
            _role = role;
            _userManager = userManager;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = _userManager.GetUserAsync(context.HttpContext.User).Result;

            if (user == null || user.NivelAcesso.ToString() != _role)
            {
                context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
            }
        }
    }
}
