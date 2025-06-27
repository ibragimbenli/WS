using Common_Types_Layer.Base;
using Common_Types_Layer.Interfaces;
using Dapper;
using Model_Layer.Entities;
using System.Data;

namespace Data_Access_Layer.Dapper
{
    public class CategoryRepository : AbstractRepository, IRepository<Category>
    {
        public CategoryRepository(IDbConnection connection) : base(connection)
        {
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var sql = @"SELECT CategoryID, CategoryName, Description FROM Categories";

            var result = await _connection.QueryAsync<Category>(sql);

            return result;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var sql = "Select * From Categories WHERE CategoryID = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Category>(sql, new { Id = id });
        }
        public async Task AddAsync(Category entity)
        {
            var sql = @"INSERT INTO Categories (CategoryName, Description)
            VALUES (@CategoryName, @Description)";

            await _connection.ExecuteAsync(sql, entity);
        }
        public async Task UpdateAsync(Category entity)
        {
            var sql = @"UPDATE Categories 
                        SET CategoryName = @CategoryName
                        WHERE CategoryID = @Id";
            await _connection.ExecuteAsync(sql, entity);
        }
        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Categories WHERE CategoryID = @Id";
            await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}