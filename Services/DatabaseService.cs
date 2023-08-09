using HourCalcMVC.Models;
using SQLite;

namespace HourCalcMVC.Services
{
    public class DatabaseService : IDatabaseService
    {
        private SQLiteAsyncConnection _connection;
        public DatabaseService() 
        {
            SetUpDb();
        }
        public async void SetUpDb() 
        {
            if (_connection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DatabaseTest1.db");
                _connection = new SQLiteAsyncConnection(dbPath);
                await _connection.CreateTableAsync<DailyHour>();
            }
        }
        public async Task<int> Add(DailyHour dailyHour)
        {
            return await _connection
                .InsertAsync(dailyHour);
        }
        public async Task<List<DailyHour>> GetAll()
        {
            return await _connection
                .Table<DailyHour>()
                .ToListAsync();
        }
        public async Task<int> Delete(int? id)
        {
            var delete = await _connection
                .FindAsync<DailyHour>(id);
            return await _connection
                .DeleteAsync(delete);
        }
    }
}
