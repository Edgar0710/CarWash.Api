using CarWash.Business.IBusiness;
using CarWash.Data.IRepository;
using CarWash.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CarWash.Business.Business
{
    public class ServicioBusiness : IServicioBusiness
    {
        IGeneralRepository<object> repository;

        public ServicioBusiness(IGeneralRepository<object> _repository) {
            repository = _repository;
        }

        public Response<object> ActualizarServicio(int servicio, string nombre, decimal precio, string descripcion)
        {
            Response<object> response = new Response<object>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_se_id", servicio, DbType.Int32);
                parameters.Add("se_nombre", nombre, DbType.String);
                parameters.Add("se_precio", precio, DbType.Decimal);
                parameters.Add("se_descripcion", descripcion, DbType.String);

                response.Result = repository.Execute("spu_servicio", parameters);

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

        public Response<object> AllCitas()
        {
            Response<object> response = new Response<object>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
             
                response.Result = repository.GetList("sps_citas", parameters);
                response.Code = ResponseEnum.Ok;

            }
            catch (Exception e)
            {
                //logger.LogEror("Ocurrio un error en LogginBussines/Login=>" + e.Message);
                response.Code = ResponseEnum.Fail;
                response.Menssage = "Error en el AllCitas";

            }
            return response;
        }

        public Response<object> AprobarCita(int cita)
        {
            Response<object> response = new Response<object>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_as_id", cita, DbType.Int32);
                response.Result = repository.Execute("spu_aprobarCita", parameters);
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

        public Response<object> AutosCliente(int cliente)
        {
            Response<object> response = new Response<object>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_cl_id", cliente, DbType.Int32);


                response.Result = repository.GetList("sps_autosCliente", parameters);

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

        public Response<object> CitasCliente(int cliente)
        {
            Response<object> response = new Response<object>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("cl_id", cliente, DbType.Int32);
               

                response.Result = repository.GetList("sps_citasCliente", parameters);

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

        public Response<object> CrearAuto(int cliente, string tipoAuto)
        {
            Response<object> response = new Response<object>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_cl_id", cliente, DbType.Int32);
                parameters.Add("_au_tipo", tipoAuto, DbType.String);
               

                response.Result = repository.Execute("spi_auto", parameters);

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

        public Response<object> CrearCita(int auto, int servicio, string fecha,string hora)
        {
            Response<object> response = new Response<object>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_au_id", auto, DbType.Int32);
                parameters.Add("_se_id", servicio, DbType.Int32);
                parameters.Add("_as_fecha", fecha, DbType.Date);
                parameters.Add("_as_hora", hora, DbType.String);
               
                response.Result = repository.Execute("spi_createCita", parameters);

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

        public Response<object> CrearServicio(string se_nombre, decimal se_precio, string se_descripcion, int us_id)
        {
            Response<object> response = new Response<object>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_se_nombre", se_nombre, DbType.String);
                parameters.Add("_se_precio", se_precio, DbType.Decimal);
                parameters.Add("_se_descripcion", se_descripcion, DbType.String);
                parameters.Add("_us_id", us_id, DbType.Int32);
             
                response.Result = repository.Execute("spi_servicio", parameters);
            
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


        public Response<object> MarcarPago(int cita)
        {
            Response<object> response = new Response<object>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_as_id", cita, DbType.Int32);
                response.Result = repository.Execute("spu_MarcarCitaComoPagado", parameters);
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

        public Response<object> Servicios()
        {
            Response<object> response = new Response<object>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();

                response.Result = repository.GetList("sps_servicios", parameters);
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
    }
}
