using System.Data;
using System.Data.Common;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Popsy.Interfaces;

namespace Popsy.Repositories
{
    /// <summary>
    /// Repositorio para ejecutar procedimientos almacenados en la base de datos.
    /// </summary>
    public class ProcedimientoAlmacenadoRepository : IProcedimientoAlmacenadoRepository
    {
        private readonly PopsyDbContext _context;

        /// <summary>
        /// Constructor de la clase ProcedimientoAlmacenadoRepository.
        /// </summary>
        /// <param name="context">El contexto de base de datos.</param>
        public ProcedimientoAlmacenadoRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task IProcedimientoAlmacenadoRepository.ExecuteStoredProc(string storedProcName)
        {
            string sqlScript = File.ReadAllText(Path.Combine("SQLScripts", $"{storedProcName}.sql"));

            using (DbConnection dbConn = _context.Database.GetDbConnection())
            {
                await dbConn.OpenAsync();
                using (DbCommand comm = dbConn.CreateCommand())
                {
                    try
                    {
                        comm.CommandText = sqlScript;
                        comm.CommandTimeout = 240;
                        DbDataReader reader = await comm.ExecuteReaderAsync();
                    }
                    finally
                    {
                        await dbConn.CloseAsync();
                    }
                }
            }
        }

        async Task<int> IProcedimientoAlmacenadoRepository.ProcedimientoSeguimientoPDV()
        {
            int response = 0;
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dbo].[SeguimientoPDV_BDSIPDV]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    // Ejecuta el comando y obtén el resultado, si corresponde
                    // Ejemplo: ExecuteNonQuery si no hay resultado o ExecuteScalar si hay un único resultado
                    response = await command.ExecuteNonQueryAsync();
                    // Realiza cualquier acción adicional con el resultado obtenido
                    await connection.CloseAsync();
                }
            }
            return response;
        }

        async Task<int> IProcedimientoAlmacenadoRepository.ProcedimientoEliminarPedidos(int anho, int mont, int day)
        {
            int response = 0;
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dbo].[sp_eliminar_pedidos]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Agrega los parámetros requeridos por el procedimiento almacenado
                    command.Parameters.AddWithValue("@ANHO", anho);
                    command.Parameters.AddWithValue("@MONT", mont);
                    command.Parameters.AddWithValue("@DAY", day);
                    await connection.OpenAsync();
                    // Ejecuta el comando y obtén el resultado, si corresponde
                    // Ejemplo: ExecuteNonQueryAsync si no hay resultado o ExecuteScalarAsync si hay un único resultado
                    response = await command.ExecuteNonQueryAsync();
                    // Realiza cualquier acción adicional con el resultado obtenido
                    connection.Close();
                }
            }
            return response;
        }

        async Task<int> IProcedimientoAlmacenadoRepository.ProcedimientoEliminarProductosTransaccionales()
        {
            int response = 0;
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dbo].[SP_ELIMINAR_PRODUCTOS_TRANSACCIONALES]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    // Ejecuta el comando y obtén el resultado, si corresponde
                    // Ejemplo: ExecuteNonQuery si no hay resultado o ExecuteScalar si hay un único resultado
                    response = await command.ExecuteNonQueryAsync();
                    // Realiza cualquier acción adicional con el resultado obtenido
                    await connection.CloseAsync();
                }
            }
            return response;
        }

        protected DbParameter GetDbParameter(DbCommand cmd, String name, DbType type, object? value)
        {
            DbParameter param = cmd.CreateParameter();
            param.ParameterName = name;
            param.DbType = type;
            param.Value = value;

            return param;
        }
    }
}
