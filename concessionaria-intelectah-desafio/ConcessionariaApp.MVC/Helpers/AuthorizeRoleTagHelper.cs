using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ConcessionariaApp.MVC.Helpers
{
    [HtmlTargetElement("authorize-role")]
    public class AuthorizeRoleTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizeRoleTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Roles { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = _httpContextAccessor.HttpContext.User;

            if (!user.Identity.IsAuthenticated || string.IsNullOrWhiteSpace(Roles))
            {
                output.SuppressOutput();
                return;
            }

            var rolesArray = Roles.Split(",");
            bool userHasRole = false;

            foreach (var role in rolesArray)
            {
                if (user.IsInRole(role.Trim()))
                {
                    userHasRole = true;
                    break;
                }
            }

            if (!userHasRole)
            {
                output.SuppressOutput();
            }
        }
    }
}
