using CarWash.Data.IRepository;
using CarWash.Model;
using CarWash.Model.Helpers;
using CarWash.Model.Models;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CarWash.Business.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        IGeneralRepository<UsuarioModel> repository;
        IGeneralRepository<object> repositoryob;
        IGeneralRepository<ClienteModel> repositorycl;
        public UsuarioBusiness(IGeneralRepository<UsuarioModel> _repository,IGeneralRepository<object> _repositoryob, IGeneralRepository<ClienteModel> _repositorycl)
        {
            repository = _repository;
            repositoryob = _repositoryob;
            repositorycl = _repositorycl;
        }

        public Response<object> InsertaUsuario(string us_nombre, string us_apellidoPaterno, string us_apellidoMaterno, string us_usuario, string password, int ro_id)
        {
            Response<object> response = new Response<object>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("us_nombre", us_nombre, DbType.String);
                parameters.Add("us_apellidoPaterno", us_apellidoPaterno, DbType.String);
                parameters.Add("us_apellidoMaterno", us_apellidoMaterno, DbType.String);
                parameters.Add("us_usuario", us_usuario, DbType.String);
                parameters.Add("ro_id", ro_id, DbType.Int32);
                parameters.Add("us_password", Utils.Base64_Decode(password), DbType.String);
                response.Result = repositoryob.Execute("spi_usuario", parameters);
               
                    response.Code = ResponseEnum.Ok;
               
               
            }
            catch (Exception e)
            {
                //logger.LogEror("Ocurrio un error en LogginBussines/Login=>" + e.Message);
                response.Code = ResponseEnum.Fail;
                response.Menssage = "Error en el login";

            }
            return response;

        }

        public Response<UsuarioModel> Login(string usuario, string password)
        {
            Response<UsuarioModel> response = new Response<UsuarioModel>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("usuario", usuario, DbType.String);
                parameters.Add("pwd", Utils.Base64_Decode(password), DbType.String);
                response.Result = repository.GetSingle("sps_login", parameters);
                if (response.Result != null)
                {
                    response.Code = ResponseEnum.Ok;
                }
                else
                {
                    response.Code = ResponseEnum.No_Found;
                    response.Menssage = "El usuario o la contraseña son incorrectos";
                }
            }
            catch (Exception e)
            {
                //logger.LogEror("Ocurrio un error en LogginBussines/Login=>" + e.Message);
                response.Code = ResponseEnum.Fail;
                response.Menssage = "Error en el login";

            }
            return response;

        }

        public Response<ClienteModel> LoginCliente(string email, string password)
        {
            Response<ClienteModel> response = new Response<ClienteModel>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("usuario", email, DbType.String);
                parameters.Add("pwd", Utils.Base64_Decode(password), DbType.String);
                response.Result = repositorycl.GetSingle("sps_cliente", parameters);
                if (response.Result != null)
                {
                    response.Code = ResponseEnum.Ok;
                }
                else
                {
                    response.Code = ResponseEnum.No_Found;
                    response.Menssage = "El usuario o la contraseña son incorrectos";
                }
            }
            catch (Exception e)
            {
                //logger.LogEror("Ocurrio un error en LogginBussines/Login=>" + e.Message);
                response.Code = ResponseEnum.Fail;
                response.Menssage = "Error en el login";

            }
            return response;
        }

        public Response<object> RegistroCliente(string usuario, string password)
        {
            Response<object> response = new Response<object>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("cl_email", usuario, DbType.String);
                parameters.Add("cl_pwd", Utils.Base64_Decode(password), DbType.String);
                response.Result = repositoryob.Execute("spi_cliente", parameters, true);

                response.Code = ResponseEnum.Ok;


            }
            catch (Exception e)
            {
                //logger.LogEror("Ocurrio un error en LogginBussines/Login=>" + e.Message);
                response.Code = ResponseEnum.Fail;
                response.Menssage = "Error en el RegistroCliente";

            }
            return response;
        }
    }
}
