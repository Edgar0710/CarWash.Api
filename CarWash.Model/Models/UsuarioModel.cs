using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Model.Models
{
    public class UsuarioModel
    {

        public long us_id { get; set; }


        public string us_nombre { get; set; }

        public string us_apellidos { get; set; }


        public string us_email { get; set; }


        public long ro_id { get; set; }


        public string ro_nombre { get; set; }
        public string us_athorization { get; set; }
    }
}
