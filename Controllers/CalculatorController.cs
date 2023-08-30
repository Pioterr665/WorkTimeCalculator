using Azure;
using HourCalcMVC.Models;
using HourCalcMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HourCalcMVC.Controllers
{
    public class CalculatorController : Controller
    {
        public int response = 1;
        private readonly CalcDbContext _dbContext;
        private readonly IDatabaseService _databaseService;
        public CalculatorController(CalcDbContext dbContext, IDatabaseService databaseService) 
        {
            _dbContext = dbContext;
            _databaseService = databaseService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View(await _databaseService.GetAll());
        }
        public IActionResult Add()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? Id)
        { 
            ViewBag.Id = Id;
            return View(await _databaseService.GetAll());
        }
        public async Task<IActionResult> Delete(int? Id)
        {
            ViewBag.Id = Id;
            var delete = await _databaseService.GetAll();
            return View(delete.Where(d => d.Id == Id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(DailyHour dailyHour)
        {
            
            if (dailyHour.Shift == "First")
            {
                dailyHour.StartingHour = new DateTime(2001, 1, 01, 6, 00, 00);
                dailyHour.EndingHour = new DateTime(2001, 1, 01, 14, 30, 00);
                var a = TimeOnly.FromDateTime(dailyHour.EndingHour) - TimeOnly.FromDateTime(dailyHour.StartingHour);
                dailyHour.Total = a.ToString();
                response = await _databaseService.Add(dailyHour);
            }
            else if (dailyHour.Shift == "Second")
            {
                dailyHour.StartingHour = new DateTime(2001, 1, 01, 14, 30, 00);
                dailyHour.EndingHour = new DateTime(2001, 1, 01, 23, 00, 00);
                var a = TimeOnly.FromDateTime(dailyHour.EndingHour) - TimeOnly.FromDateTime(dailyHour.StartingHour);
                dailyHour.Total = a.ToString();
                response = await _databaseService.Add(dailyHour);
            }
            else if(dailyHour.Shift == "Custom")
            {
                var a = TimeOnly.FromDateTime(dailyHour.StartingHour);
                var b = TimeOnly.FromDateTime(dailyHour.EndingHour);
                var c = b - a;
                dailyHour.Total = c.ToString();
                response = await _databaseService.Add(dailyHour);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            response = await _databaseService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
