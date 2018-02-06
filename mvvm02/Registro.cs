using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm02
{
    class Registro
    {
        public DateTime Fecha {get; set;}
        public string Nombre { get; set; }

        public Registro(DateTime fecha, string nombre)
        {
            this.Fecha = fecha;
            this.Nombre = nombre;
        }
    }
}
