using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace PhamTrongThanhRazorPages.Pages.Staff
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObject.CarRentalSystemDBContext _context;

        public DeleteModel(BusinessObject.CarRentalSystemDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StaffAccount StaffAccount { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StaffAccount = await _context.StaffAccounts.FirstOrDefaultAsync(m => m.StaffId == id);

            if (StaffAccount == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StaffAccount = await _context.StaffAccounts.FindAsync(id);

            if (StaffAccount != null)
            {
                _context.StaffAccounts.Remove(StaffAccount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
