using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace mvvm02
{
    class AccionesBotones
    {
        async public static void MostrarResultado(string comando) {
            switch(comando.ToLower())
            {
                case "entrada":
                    await Dialogos.MuestraDialogo("Entrada");
                    break;
                case "salida":
                    await Dialogos.MuestraDialogo("Salida");
                    break;
                case "registro":
                    await Dialogos.MuestraDialogo("Registro");
                    break;
            }                
        }
    }
}
