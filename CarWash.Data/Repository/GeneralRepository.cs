using CarWash.Data.IRepository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CarWash.Data.Repository
{
    public class GeneralRepository<T> : DataRepository, IGeneralRepository<T> where T : class
    {
        /// <summary>
        /// Se abre la conección a la base  de datos
        /// </summary>
        public GeneralRepository()
        {
            conn.Open();
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado 
        /// </summary>
        /// <param name="spName">Nombre del Procedimiento Almacenado</param>
        /// <param name="parameters">Lista de parametros del Procedimiento Almacenado</param>
        /// <returns>True si el procedimiento se ejecuto correctamente</returns>
        public int Execute(string spName, DynamicParameters parameters = null, bool returnId = false)
        {
            if (returnId)
            {
                return SqlMapper.QuerySingle<int>(conn, spName, param: parameters, commandType: CommandType.StoredProcedure);
            }
            else
            {
                return SqlMapper.Execute(conn, spName, param: parameters, commandType: CommandType.StoredProcedure);
            }



        }

        /// <summary>
        /// Obtiene una lista de elementos de la clase T proporcionada
        /// </summary>
        /// <param name="spName">Nombre del Procedimiento Almacenado</param>
        /// <param name="parameters">Lista de parametros del Procedimiento Almacenado</param>
        /// <returns>Lista de elementos T, proporcionado en la implementación</returns>
        public List<T> GetList(string spName, DynamicParameters parameters = null)
        {
            List<T> result = new List<T>();
            result = SqlMapper.Query<T>(conn, spName, param: parameters, commandType: CommandType.StoredProcedure).ToList();
            conn.Close();
            return result;
        }

        /// <summary>
        /// Obtiene solo un registro de la clase T proporcionada
        /// </summary>
        /// <param name="spName">Nombre del Procedimiento Almacenado</param>
        /// <param name="parameters">Lista de parametros del Procedimiento Almacenado</param>
        /// <returns>Elemento T, proporcionado en la implementación</returns>
        public T GetSingle(string spName, DynamicParameters parameters = null)
        {
            var result = SqlMapper.Query<T>(conn, spName, param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            conn.Close();
            return result;
        }


    }
}
