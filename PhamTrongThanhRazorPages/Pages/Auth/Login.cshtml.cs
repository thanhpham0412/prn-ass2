using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repo;
using BusinessObject;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;

namespace PhamTrongThanhRazorPages.Pages.Auth
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
           
        public IActionResult OnPost()
        {
            if (isAdmin(Email, Password))
            {
                HttpContext.Session.SetString("Role", "Admin");
                return RedirectToPage("../Staff/Index");
            } else
            {
                var staff = new StaffAccountRepository().getByEmailAndPsw(Email, Password);
                if (staff != null)
                {
                    HttpContext.Session.SetString("Role", "Staff");
                    HttpContext.Session.SetString("StaffId", staff.StaffId);
                    return RedirectToPage("../CarRentals/RentingReport");
                } 
                var customer = new CustomerRepository().getByEmailAndPsw(Email, Password);
                if (customer != null)
                {
                    HttpContext.Session.SetString("Role", "Customer");
                    HttpContext.Session.SetString("CustId", customer.CustomerId);
                    return RedirectToPage("../Staff/Index");


                }
            }
            ErrorMessage = "Invalid username or password";
            return Page();
        }

        private Boolean isAdmin(string email, string password)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            string adminEmail = config["AdminAccount:Email"];
            string adminPsw = config["AdminAccount:Password"];
            if (adminEmail == email && adminPsw == password)
            {
                return true;
            }
            return false;
        }
    }

}
