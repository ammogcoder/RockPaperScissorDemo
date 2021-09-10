using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface IGenericRepo
    {
        /// <summary>
        /// This method is used to implement all Modifications like INSERT,UPDATE and DELETE
        /// </summary>
        /// <typeparam name="R">The Contain the object return from the database</typeparam>
        /// <param name="conn">This is the Stored Procedure name</param>
        /// <param name="dynamicParameters">This contain parameters required by the stored procedure</param>
        /// <returns>This Returns the Type Specified from Controller</returns>
        Task<R> ModifyDapperGenericAsync<R>(string conn, DynamicParameters dynamicParameters);
        /// <summary>
        /// This method is used to retrieve data from the procedure
        /// </summary>
        /// <typeparam name="R">The Contain the object return from the database</typeparam>
        /// <param name="conn">This is the Stored Procedure name</param>
        /// <param name="dynamicParameters">This contain parameters required by the stored procedure</param>
        /// <returns>This Returns the Type Specified from Controller</returns>
        Task<R> RetrieveDapperGenericAsync<R>(string conn, DynamicParameters dynamicParameters);

        /// <summary>
        /// This method is used to retrieve data from the procedure
        /// </summary>
        /// <typeparam name="R">The Contain the object return from the database</typeparam>
        /// <param name="conn">This is the Stored Procedure name</param>
        /// <param name="dynamicParameters">This contain parameters required by the stored procedure</param>
        /// <returns>This Returns the Type Specified from Controller</returns>
        Task<R> RetrieveSingleDapperGenericAsync<R>(string conn, DynamicParameters dynamicParameters);
        /// <summary>
        /// This method is used to retrieve data from the procedure
        /// </summary>
        /// <typeparam name="R">The Contain the object return from the database</typeparam>
        /// <param name="conn">This is the Stored Procedure name</param>
        /// <param name="dynamicParameters">This contain parameters required by the stored procedure</param>
        /// <returns>This Returns Multiple Result Type Specified from Controller</returns>
        Task<R> RetrieveMultipleResultDapperGenericAsync<R, T1>(string conn, DynamicParameters dynamicParameters);
        /// <summary>
        /// This method is used to retrieve data from the procedure
        /// </summary>
        /// <typeparam name="R">The Contain the object return from the database</typeparam>
        /// <param name="conn">This is the Stored Procedure name</param>
        /// <param name="dynamicParameters">This contain parameters required by the stored procedure</param>
        /// <returns>This Returns Multiple Result Type Specified from Controller</returns>
        Task<R> RetrieveMultipleResultDapperGenericAsync<R, T1, T2>(string conn, DynamicParameters dynamicParameters);
        /// <summary>
        /// This method is used to retrieve data from the procedure
        /// </summary>
        /// <typeparam name="R">The Contain the object return from the database</typeparam>
        /// <param name="conn">This is the Stored Procedure name</param>
        /// <param name="dynamicParameters">This contain parameters required by the stored procedure</param>
        /// <returns>This Returns Multiple Result Type Specified from Controller</returns>
        Task<R> RetrieveMultipleResultDapperGenericAsync<R, T1, T2, T3>(string conn, DynamicParameters dynamicParameters);
        /// <summary>
        /// This method is used to retrieve data from the procedure
        /// </summary>
        /// <typeparam name="R">The Contain the object return from the database</typeparam>
        /// <param name="conn">This is the Stored Procedure name</param>
        /// <param name="dynamicParameters">This contain parameters required by the stored procedure</param>
        /// <returns>This Returns Multiple Result Type Specified from Controller</returns>
        Task<R> RetrieveMultipleResultDapperGenericAsync<R, T1, T2, T3, T4>(string conn, DynamicParameters dynamicParameters);
        /// <summary>
        /// This method is used to retrieve data from the procedure
        /// </summary>
        /// <typeparam name="R">The Contain the object return from the database</typeparam>
        /// <param name="conn">This is the Stored Procedure name</param>
        /// <param name="dynamicParameters">This contain parameters required by the stored procedure</param>
        /// <returns>This Returns Multiple Result Type Specified from Controller</returns>
        Task<R> RetrieveMultipleResultDapperGenericAsync<R, T1, T2, T3, T4, T5>(string conn, DynamicParameters dynamicParameters);
    }
}
