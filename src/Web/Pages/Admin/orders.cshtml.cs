using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.ApplicationCore.Constants;

namespace Microsoft.eShopWeb.Web.Pages.Admin
{
    [Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS)]
    public class OrdersModel : PageModel
    {
    }
}
