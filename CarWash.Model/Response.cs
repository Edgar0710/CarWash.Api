using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Model
{
    public class Response<T>
    {
        public ResponseEnum Code { get; set; }
        public string Menssage { get; set; }
        public T Result { get; set; }
    }

    public enum ResponseEnum
    {
        Ok = 200,
        Fail = 400,
        No_Found = 404
    }
}
