using CarWash.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Business.IBusiness
{
    public interface IServicioBusiness
    {
        Response<object> CrearServicio(string se_nombre, decimal se_precio, string se_descripcion, int us_id);
        Response<object> CrearCita(int auto, int servicio, string fecha);
        Response<object> CitasCliente(int cliente);
        Response<object> AllCitas();
        Response<object> Servicios();
        Response<object> AprobarCita(int cita);
        Response<object> MarcarPago(int cita);
        Response<object> ActualizarServicio(int servicio, string nombre, decimal precio, string descripcion);
        Response<object> CrearAuto(int cliente, string tipoAuto);
    }
}
