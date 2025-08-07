using Common_Types_Layer.Base;
using Model_Layer.Entities;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Common_Types_Layer.Interfaces.Dapper;

namespace Data_Access_Layer.Dapper
{
    public class ProductRepository : AbstractRepository, IRepository<Product>
    {
        public ProductRepository(IDbConnection connection) : base(connection)
        {
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var sql = @"SELECT * FROM Products";
            var result = await _connection.QueryAsync<Product>(sql);
            return result;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var sql = @"Select * From Products where ProductID = @Id";
            var result = await _connection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
            return result;
        }

        public async Task AddAsync(Product entity)
        {
            var sql = @"INSERT INTO Products (ProductName, CategoryID, UnitsInStock,UnitPrice)
                                    VALUES (@ProductName, @CategoryID, @UnitsInStock, @UnitPrice)";

            await _connection.ExecuteAsync(sql, entity);
        }
        public async Task UpdateAsync(Product entity)
        {
            var sql = @"UPDATE Products 
                        SET ProductName = @ProductName, CategoryID =  @CategoryID, UnitsInStock = @UnitsInStock , UnitPrice = @UnitPrice 
                        WHERE ProductID = @Id";
            await _connection.ExecuteAsync(sql, entity);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE ProductID = @Id";
            await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
