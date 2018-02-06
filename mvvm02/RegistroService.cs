using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm02
{
    class RegistroService
    {
        private List<Registro> _registros;


        public RegistroService()
        {
            _registros = new List<Registro>();
        }

        public void RegistroEntrada(string persona)
        {            
            _registros.Add(new Registro(DateTime.Now, persona));            
        }

        public void RegistroSalida(string persona)
        {
            var registro = _registros.LastOrDefault(x => x.Nombre == persona);
           if (registro != null) _registros.Remove(registro);
            
        }


    }
}
