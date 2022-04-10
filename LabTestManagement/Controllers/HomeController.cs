using LabTestManagement.Data;
using LabTestManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LabTestManagement.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(string sortBy)
        {
            List<Doctor> doctors = null;
            List<Service> services = null;


            if (!string.IsNullOrEmpty(sortBy))
            {
                // Sort by is given...
                switch (sortBy)
                {
                    case "Name":
                        services = _dbContext.Services
                                    .OrderBy(e => e.Name)
                                    .ToList();
                        break;
                  
                    default:
                        services = _dbContext.Services.ToList();
                        break;
                }
            }
            else
            {
                // No sort by...
                services = _dbContext.Services.ToList();
            }
            if (!string.IsNullOrEmpty(sortBy))
            {
                // Sort by is given...
                switch (sortBy)
                {
                    case "firstname":
                        doctors = _dbContext.Doctors
                                    .OrderBy(d => d.FirstName)
                                    .ToList();
                        break;

                    default:
                        doctors = _dbContext.Doctors.ToList();
                        break;
                }
            }
            else
            {
                // No sort by...
                doctors = _dbContext.Doctors.ToList();
            }

            var vm = new IndexViewModel
            {
                Doctors = doctors,
                Services =services
            };

            return View(vm);
        }
    

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Doctor()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
