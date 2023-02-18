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
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.CarRentalSystemDBContext _context;

        public IndexModel(BusinessObject.CarRentalSystemDBContext context)
        {
            _context = context;
        }

        public IList<CarRental> CarRental { get;set; }

        public async Task OnGetAsync()
        {
            CarRental = await _context.CarRentals
                .Include(c => c.Car)
                .Include(c => c.Customer).ToListAsync();
        }
    }
}
