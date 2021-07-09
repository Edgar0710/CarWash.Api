using CarWash.Data.IRepository;
using CarWash.Model;
using CarWash.Model.Models;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Business.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        IGeneralRepository<object> repository;
        public UsuarioBusiness(IGeneralRepository<object> _repository)
        {
            repository = _repository;
        }
        public Response<UsuarioModel> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Response<object> prueba()
        {
            Response<object> response = new Response<object>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                // parameters.Add("@form", form, DbType.Int32);
                var resp = repository.GetSingle("prueba", parameters);
                response.Result = resp;

                response.Code = ResponseEnum.Ok;
                


            }
            catch (Exception ex)
            {
                response.Code = ResponseEnum.Fail;
                response.Menssage = "Error al procesar la solicitud";
               /// logger.LogEror("Ocurrio un error en FormBussines/DetalleForm=>" + ex.Message);
            }
            return response;
        }
    }
}
