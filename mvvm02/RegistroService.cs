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
        public event Action<Registro> AltaIntegrante;
        public event Action<Registro> SalidaIntegrante;

        public RegistroService()
        {
            _registros = new List<Registro>();
        }

        public void RegistroEntrada(string persona)
        {
            var _registro = new Registro(DateTime.Now, persona);
            _registros.Add(_registro);
            AltaIntegrante?.Invoke(_registro);
        }

        public void RegistroSalida(string persona)
        {
            var registro = _registros.LastOrDefault(x => x.Nombre == persona);
            if (registro != null)
            {                
                _registros.Remove(registro);
                SalidaIntegrante?.Invoke(registro);
            }
        }

        public List<string> Integrantes => _registros?.Select(r => r.Nombre).ToList();
        
    }
}
