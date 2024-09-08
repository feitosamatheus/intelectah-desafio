using ConcessionariaApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ConcessionariaApp.MVC.Filters
{
    public class AuthorizeRoleAttribute : TypeFilterAttribute
    {
        public AuthorizeRoleAttribute(string role) : base(typeof(AuthorizeRoleFilter))
        {
            Arguments = new object[] { role };
        }
    }
}
