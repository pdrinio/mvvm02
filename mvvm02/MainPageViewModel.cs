using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm02
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private RegistroService _registroService;

        #region BindingProperties
        public Comando ComandoEntrar { get; set; }
        public Comando ComandoSalir { get; set; }
        public Comando ComandoRegistro { get; set; }

        private string _textoNombre;
        public string TextoNombre {
            get => _textoNombre;
            set
            {
                _textoNombre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextoNombre)));
            }                    
        }
        #endregion

        public MainPageViewModel()
        {
            ComandoEntrar = new Comando(async (str) =>
            {
                await Dialogos.MuestraDialogo(str);
                _registroService.RegistroEntrada(str);
            });
        
            ComandoSalir = new Comando(async (str) => await Dialogos.MuestraDialogo(str));
            ComandoRegistro = new Comando(async (str) => await Dialogos.MuestraDialogo(str));

            _registroService = new RegistroService();

            PropertyChanged += MainPageViewModel_PropertyChanged;
        }

        private void MainPageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(TextoNombre))
            {

            }
        }
    }
}
