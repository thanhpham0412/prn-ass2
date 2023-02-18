using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repo;

namespace PhamTrongThanhRazorPages.Pages.Staff
{
    public class DetailsModel : PageModel
    {
        public DetailsModel()
        {
        }

        public StaffAccount StaffAccount { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StaffAccount = new StaffAccountRepository().getById(id);

            if (StaffAccount == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
