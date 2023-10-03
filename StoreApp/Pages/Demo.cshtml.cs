using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Infrastructure.Extension;

namespace StoreApp.Pages
{
    public class DemoModel : PageModel
    {
        public String? FullName =>HttpContext?.Session.GetString("name") ?? "noname";
        
        public void OnGet()
        {

        }
        public void OnPost([FromForm]string name)
        {
            HttpContext.Session.SetString("name",name);
            //HttpContext.Session.GetJson<T>
        }
        
    }
}