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
    public class DistrictController : Controller
    {
        private readonly AppDBContext _db;
        public DistrictController(AppDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("District/GetCityDistricts/{CityId:int}")]
        public async Task<IEnumerable<District>> GetCityDistricts(int CityId)
        {
            return await _db.Districts
                .Where(di => di.CityId == CityId)
                .ToListAsync();
        }
    }
}
