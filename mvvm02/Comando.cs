using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mvvm02
{
    class Comando : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<string> HanPulsado;

        public Comando(Action<string> MiAccion)
        {
            HanPulsado = MiAccion;
        }

        public bool CanExecute(object parameter) => parameter is string str && !string.IsNullOrWhiteSpace(str) && str.Length > 3;
        
        public void Execute(object parameter) => HanPulsado?.Invoke(parameter as string);
    }
}
