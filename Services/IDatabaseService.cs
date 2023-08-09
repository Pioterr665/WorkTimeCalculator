using HourCalcMVC.Models;

namespace HourCalcMVC.Services
{
    public interface IDatabaseService
    {
        Task<List<DailyHour>> GetAll();
        Task<int> Add(DailyHour dailyHour);
        Task<int> Delete(int? id);
    }
}
