using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Dto.Response
{
    //esta clase se crea con el fin de homogeneizar las respuestas al usuario y brindarle la menor informacion posible
    public class BaseResponse
    {
        public bool Success { get; set; }

        public string? ErrorMessage { get; set; }

        //public   { get; set; }//public Object? Data
    }
}
