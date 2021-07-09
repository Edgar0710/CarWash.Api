using CarWash.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Business.Business
{
    public interface IUsuarioBusiness
    {
        CarWash.Model.Response<CarWash.Model.Models.UsuarioModel> Login(string email, string password);
        Response<object> prueba();
    }
}
