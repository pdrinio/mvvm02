using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<string> ListaIntegrantes { get; set; }

        private string _integranteSeleccionado;
        public string IntegranteSeleccionado {
            get => _integranteSeleccionado;
            set {
                _integranteSeleccionado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IntegranteSeleccionado)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextoNombre).ToString()));
            }
        }

        #endregion

        public MainPageViewModel()
        {
            ListaIntegrantes = new ObservableCollection<string>();
            _registroService = new RegistroService();

            _registroService.AltaIntegrante += (x) => ListaIntegrantes.Add(x.Nombre);
            _registroService.SalidaIntegrante += (x) => ListaIntegrantes.Remove(x.Nombre);

            ComandoEntrar = new Comando((str) =>
            {
                //await Dialogos.MuestraDialogo(str);
                _registroService.RegistroEntrada(str);
            });

            ComandoSalir = new Comando((str) =>
            {
                //await Dialogos.MuestraDialogo(str));
                _registroService.RegistroSalida(str);
            });
            
            ComandoRegistro = new Comando(async (str) => await Dialogos.MuestraDialogo(str));            

            //PropertyChanged += MainPageViewModel_PropertyChanged;
        }

        //private void MainPageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if(e.PropertyName == nameof(TextoNombre))
        //    {

        //    }
        //}
    }
}
