using CarWash.Business.IBusiness;
using CarWash.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        IServicioBusiness servicioBusiness;

        public ServicesController(IServicioBusiness _servicio)
        {
            servicioBusiness = _servicio;
        }

        #region Get
        [HttpGet, Route("CitasCliente")]
        public Response<object> CitasCliente(int cliente)
        {
            return servicioBusiness.CitasCliente(cliente);
        }  
        [HttpGet, Route("AllCitas")]
        public Response<object> AllCitas()
        {
            return servicioBusiness.AllCitas();
        }    
        [HttpGet, Route("Servicios")]
        public Response<object> Servicios()
        {
            return servicioBusiness.Servicios();
        }

        #endregion
        #region Post
        [HttpPost,Route("CrearServicio")]
        public Response<object> CrearServicio(string se_nombre, decimal se_precio, string se_descripcion, int us_id) { 
        return servicioBusiness.CrearServicio(se_nombre, se_precio, se_descripcion, us_id);
        }
        [HttpPost, Route("CrearCita")]
        public Response<object> CrearCita(int auto,int servicio,string fecha) { 
        return servicioBusiness.CrearCita(auto, servicio, fecha);
        }
        [HttpPost, Route("CrearAuto")]
        public Response<object> CrearAuto(int cliente, string tipoAuto)
        {
            return servicioBusiness.CrearAuto(cliente, tipoAuto);
        }

        [HttpPost, Route("AprobarCita")]
        public Response<object> AprobarCita(int cita) { 
        return servicioBusiness.AprobarCita(cita);
        } 

        [HttpPost, Route("MarcarPago")]
        public Response<object> MarcarPago(int cita) { 
        return servicioBusiness.MarcarPago(cita);
        }

        [HttpPost, Route("ActualizarServicio")]
        public Response<object> ActualizarServicio(int servicio, string nombre, decimal precio,string descripcion)
        {
            return servicioBusiness.ActualizarServicio( servicio, nombre,precio,descripcion);
        }
        #endregion

    }
}

