using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessObject.Validation 
{
    public class UniqueEmailValidation : ValidationAttribute
    {
        public UniqueEmailValidation()
        {
            ErrorMessage = "This Email is already exist.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            string email = (string)value;
            using (var dbContext = new CarRentalSystemDBContext())
            {
                return !dbContext.StaffAccounts.Where(s => s.Email == email).Any() &&
                    !dbContext.Customers.Where(s => s.CustomerEmail == email).Any();
            }
            
        }
    }
}
