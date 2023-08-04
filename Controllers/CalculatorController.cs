using Azure;
using HourCalcMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HourCalcMVC.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalcDbContext _dbContext;
        public CalculatorController(CalcDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View(await _dbContext.dailyHours.ToListAsync());
        }
        public IActionResult Add()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? Id)
        { 
            ViewBag.Id = Id;
            return View(await _dbContext.dailyHours.ToListAsync());
        }
        public async Task<IActionResult> Delete(int? Id)
        {
            ViewBag.Id = Id;
            return View(await _dbContext.dailyHours.FirstOrDefaultAsync(d => d.Id == Id));
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
                _dbContext.dailyHours.Add(dailyHour);
                await _dbContext.SaveChangesAsync();
            }
            else if (dailyHour.Shift == "Second")
            {
                dailyHour.StartingHour = new DateTime(2001, 1, 01, 14, 30, 00);
                dailyHour.EndingHour = new DateTime(2001, 1, 01, 23, 00, 00);
                var a = TimeOnly.FromDateTime(dailyHour.EndingHour) - TimeOnly.FromDateTime(dailyHour.StartingHour);
                dailyHour.Total = a.ToString();
                _dbContext.dailyHours.Add(dailyHour);
                await _dbContext.SaveChangesAsync();
            }
            else if(dailyHour.Shift == "Custom")
            {
                var a = TimeOnly.FromDateTime(dailyHour.StartingHour);
                var b = TimeOnly.FromDateTime(dailyHour.EndingHour);
                var c = b - a;
                dailyHour.Total = c.ToString();
                _dbContext.dailyHours.Add(dailyHour);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            _dbContext.dailyHours.Remove(await _dbContext.dailyHours.FindAsync(id));
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
