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
        public event Action<string> HanPulsado;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ////var comando = parameter as string;
            //HanPulsado?.Invoke(comando);
            HanPulsado?.Invoke(parameter as string);
        }
    }
}
