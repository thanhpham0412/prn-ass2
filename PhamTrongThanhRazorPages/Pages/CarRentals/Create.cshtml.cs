using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;

namespace PhamTrongThanhRazorPages.Pages.CarRentals
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.CarRentalSystemDBContext _context;

        public CreateModel(BusinessObject.CarRentalSystemDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId");
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            return Page();
        }

        [BindProperty]
        public CarRental CarRental { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CarRentals.Add(CarRental);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
