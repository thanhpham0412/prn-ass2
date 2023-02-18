using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace PhamTrongThanhRazorPages.Pages.CarRentals
{
    public class DetailsModel : PageModel
    {

        public DetailsModel()
        {
        }

        public CarRental CarRental { get; set; }

        public IActionResult OnGet(CarRental obj)
        {
            CarRental = obj;

            if (CarRental == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
