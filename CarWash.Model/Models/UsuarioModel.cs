﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Model.Models
{
    public class UsuarioModel
    {
       
        public long us_id { get; set; }


        public string us_nombre { get; set; }

        public string us_apellidoPaterno { get; set; }
        public string us_apellidoMaterno { get; set; }


        public string us_usuario { get; set; }


        public long ro_id { get; set; }


        public string ro_nombre { get; set; }
        public string us_athorization { get; set; }
    }
}
