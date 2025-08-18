using Common_Types_Layer.Base;
using Common_Types_Layer.Interfaces.Dapper;
using Dapper;
using Model_Layer.Entities;
using System.Data;

namespace Data_Access_Layer.Dapper
{
    public class PersonRepository : AbstractRepository, IRepository<Person>
    {
        public PersonRepository(IDbConnection connection) : base(connection)
        {
        }
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var sql = @"
        SELECT 
            EmployeeID AS Id,
            FirstName,
            LastName,
            BirthDate
        FROM Employees";
            var result = await _connection.QueryAsync<Person>(sql);
            return result;
        }
        public async Task<Person> GetByIdAsync(int id)
        {
            var sql = "Select * From Employees WHERE EmployeeID = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
        }
        public async Task AddAsync(Person entity)
        {
            var sql = @"INSERT INTO Employees (FirstName, LastName, BirthDate)
            VALUES (@FirstName, @LastName, @BirthDate)";

            await _connection.ExecuteAsync(sql, entity);
        }
        public async Task UpdateAsync(Person entity)
        {
            var sql = @"UPDATE Employees 
                        SET FirstName = @FirstName, LastName =  @LastName, BirthDate = @BirthDate 
                        WHERE EmployeeID = @Id";
            await _connection.ExecuteAsync(sql, entity);
        }
        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Employees WHERE EmployeeID = @Id";
            await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<List<Tarim>> GetPerson_Tarim()
        {
            List<Tarim> res = new List<Tarim>();
            try
            {
                var p = new DynamicParameters();
                string sql = $@"SELECT *
                    FROM TZOB.Sys_Person
                    WHERE ROWNUM <= 100
                    --ORDER BY ROWNO, UYENO, ZIRAATODAKODU, UYEROWNO
                ";

                res = this._connection.Query<Tarim>(sql, p, commandType: CommandType.Text).ToList();
            }
            catch (Exception ex)
            {
                _ = ex;
            }

            return res;
        }

    }
}
