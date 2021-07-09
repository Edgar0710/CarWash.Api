using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Data.IRepository
{
    public interface IGeneralRepository<T> where T : class
    {
        /// <summary>
        /// Obtiene solo un registro de la clase T proporcionada
        /// </summary>
        /// <param name="spName">Nombre del Procedimiento Almacenado</param>
        /// <param name="parameters">Lista de parametros del Procedimiento Almacenado</param>
        /// <returns>Elemento T, proporcionado en la implementación</returns>
        T GetSingle(string spName, DynamicParameters parameters = null);

        /// <summary>
        /// Obtiene una lista de elementos de la clase T proporcionada
        /// </summary>
        /// <param name="spName">Nombre del Procedimiento Almacenado</param>
        /// <param name="parameters">Lista de parametros del Procedimiento Almacenado</param>
        /// <returns>Lista de elementos T, proporcionado en la implementación</returns>
        List<T> GetList(string spName, DynamicParameters parameters = null);

        /// <summary>
        /// Ejecuta un procedimiento almacenado 
        /// </summary>
        /// <param name="spName">Nombre del Procedimiento Almacenado</param>
        /// <param name="parameters">Lista de parametros del Procedimiento Almacenado</param>
        /// <returns>True si el procedimiento se ejecuto correctamente</returns>
        int Execute(string spName, DynamicParameters parameters = null, bool returnId = false);
    }
}
