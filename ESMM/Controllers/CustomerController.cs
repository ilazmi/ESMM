using ESMM.Data;
using ESMM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESMM.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDBContext _db;
        public CustomerController(AppDBContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _db.Customers
                    .Include(cu => cu.City)
                    .Include(cu => cu.District)
                    .Where(c => c.State == 0)
                    .ToListAsync();

                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddEdit(int? id)
        {
            try
            {
                Customer customer = await _db.Customers
                    .Include(cu => cu.City)
                    .Include(cu => cu.District)
                    .Where(cu => cu.State == 0)
                    .SingleOrDefaultAsync(cu => cu.Id == id.Value);

                customer.Cities = await _db.Cities
                    .Where(ci => ci.State == 0)
                    .ToListAsync();

                customer.Districts = await _db.Districts
                    .Where(di => di.State == 0)
                    .Where(di => di.CityId == customer.CityId)
                    .ToListAsync();

                return PartialView("~/Views/Customer/_AddEdit.cshtml", customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }
    }
}
