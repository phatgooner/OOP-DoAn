using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_TrangChuModel : PageModel
    {
        public void OnGet()
        {
			string username = "";
			HttpContext.Session.SetString("username", username);
		}
    }
}
