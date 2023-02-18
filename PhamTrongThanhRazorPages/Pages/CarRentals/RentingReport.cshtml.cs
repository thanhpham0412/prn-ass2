using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Repo;
using System.Collections.Generic;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace PhamTrongThanhRazorPages.Pages.CarRentals
{
    public class RentingReportModel : PageModel
    {
        public class ReportStatistic
        {
            public string CarName { get; set; }
            public int RentingDate { get; set; }
            public decimal TotalPrice { get; set; }
        }

        public IList<ReportStatistic> ReportStatistics { get; set; }
        [BindProperty, Required]
        public DateTime? PickupDate { get; set; }
        [BindProperty, Required]
        public DateTime? ReturnDate { get; set; }
        public string Message { get; set; }


        public void OnGet(DateTime pickupDate, DateTime returnDate)
        {
            PickupDate = pickupDate;
            ReturnDate = returnDate;
            if (PickupDate != null && ReturnDate != null)
            {
                if (DateTime.Compare((DateTime)PickupDate, (DateTime)ReturnDate) < 0) 
                {
                    Message = null;
                    var carRepo = new CarRepository();
                    var cars = carRepo.getData();
                    ReportStatistics = new List<ReportStatistic>();
                    foreach (var car in cars)
                    {
                        int days = carRepo.calculateRentingDateInPeriod(car.CarId, (DateTime)PickupDate, (DateTime)ReturnDate);
                        ReportStatistics.Add(new ReportStatistic()
                        {
                            CarName = car.CarName,
                            RentingDate = days,
                            TotalPrice = (decimal)car.RentPrice * days
                        });
                    }
                    ReportStatistics = ReportStatistics.OrderByDescending(x => x.TotalPrice).ToList();

                } else
                {
                    Message = "Pickup date must be before return date";
                }
            }
                
        }
    }
}
