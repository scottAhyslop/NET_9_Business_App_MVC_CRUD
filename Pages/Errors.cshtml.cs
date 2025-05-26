using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_9_Business_App_MVC_CRUD.Pages
{
    public class ErrorModel : PageModel
    {
        public List<string>? Errors { get; set; }
        public void OnGet(List<string> errors)
        {
            Errors = errors ?? new List<string>();
        }
    }
}
