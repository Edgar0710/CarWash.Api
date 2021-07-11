using CarWash.Model;
using CarWash.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Business.Business
{
    public interface IUsuarioBusiness
    {
        Response<UsuarioModel> Login(string email, string password);
        Response<object> InsertaUsuario(string us_nombre, string us_apellidoPaterno, string us_apellidoMaterno, string us_usuario, string password, int ro_id);
        Response<object> RegistroCliente(string usuario, string password);
        Response<ClienteModel> LoginCliente(string email, string password);
    }
}
