using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vagas.Models;

namespace Vagas.Service
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _connection = null!;

        public DatabaseService(string databasePath)
        {
            _connection = new SQLiteAsyncConnection(databasePath);
            _connection.CreateTableAsync<Vaga>().Wait();
        }

        public async Task CreateAsync(Vaga vaga)
            => await _connection.InsertAsync(vaga);

        public async Task DeleteAsync(Vaga vaga)
            => await _connection.DeleteAsync(vaga);

        public async Task<IReadOnlyCollection<Vaga>> GetAllAsync()
            => await _connection.Table<Vaga>().ToListAsync();

        public async Task<Vaga> GetByIdAsync(int id)
            => await _connection.FindAsync<Vaga>(id);

        public async Task<IReadOnlyCollection<Vaga>> SearchByName(string name)
            => await _connection.Table<Vaga>().Where(vaga => vaga.Nome == name).ToListAsync();

        public async Task UpdateAsync(Vaga vaga)
            => await _connection.UpdateAsync(vaga);
    }
}
