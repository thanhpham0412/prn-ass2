using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessObject.Validation
{
    public class UniqueIdValidation : ValidationAttribute
    {
        public UniqueIdValidation(Type dataContextType)
        {
            DataContextType = dataContextType;
            ErrorMessage = "This Id is already exist.";
        }

        public Type DataContextType { get; private set; }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            string data = (string)value;
            if (DataContextType == typeof(StaffAccount))
            {
                using (var dbContext = new CarRentalSystemDBContext())
                {
                    return dbContext.StaffAccounts.Find(data) == null;
                }
            }
            if (DataContextType == typeof(Customer))
            {
                using (var dbContext = new CarRentalSystemDBContext())
                {
                    return dbContext.Customers.Find(data) == null;
                }
            }
            return false;
        }
    }
}
