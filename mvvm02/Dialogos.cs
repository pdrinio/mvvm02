using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace mvvm02
{
    class Dialogos
    {
        public async static Task MuestraDialogo(string mensaje) {
            MessageDialog md = new MessageDialog(mensaje);
            await md.ShowAsync();
        }
    }
}
