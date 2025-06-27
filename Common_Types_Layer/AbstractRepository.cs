using System.Data;

namespace Common_Types_Layer.Base
{
    public abstract class AbstractRepository
    {
        protected readonly IDbConnection _connection;

        protected AbstractRepository(IDbConnection connection)
        {
            _connection = connection;
        }
    }
}