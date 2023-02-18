using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repo;
using Microsoft.AspNetCore.Http;

namespace PhamTrongThanhRazorPages.Pages.Staff
{
    public class IndexModel : PageModel
    {

        public IndexModel()
        {
        }

        public IList<StaffAccount> StaffAccount { get;set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToPage("../Auth/Login");

            }

            StaffAccount = new StaffAccountRepository().getData();
            return Page();
        }


    }
}
