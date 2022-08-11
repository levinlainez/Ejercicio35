using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Ejercicio35.Views.Empleados;
using Ejercicio35.Models;
using Ejercicio35.Data;
using System.Collections.ObjectModel;

namespace Ejercicio35.ViewModels.VMEmpleados
{
    public class VMListaEmpleados:BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        ObservableCollection<MEpleados> _ListaEmpleados;
        #endregion
        #region CONSTRUCTOR
        public VMListaEmpleados(INavigation navigation)
        {
            Navigation = navigation;
            MostrarEmpelado();
        }
        #endregion
        #region OBJETOS
        public ObservableCollection<MEpleados> ListaEmpleados
        {
            get { return _ListaEmpleados; }
            set { SetValue(ref _ListaEmpleados, value);
                OnPropertyChanged();
            }
                
        }
        #endregion
        #region PROCESOS
        public async Task Iraregistro()
        {
            await Navigation.PushAsync(new RegistroEmpleados());
        }
        public async Task MostrarEmpelado()
        {
            var funcion = new DEmpleados();
            ListaEmpleados = await funcion.MostrarEmpleados();
        }

        public async Task Iradetalles(MEpleados parametros)
        {
            await Navigation.PushAsync(new DetalleEmpleado(parametros));

        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand Iraregistrocomand => new Command(async () => await Iraregistro());
        public ICommand Iradetallecomand => new Command<MEpleados>(async (p) => await Iradetalles(p));
        #endregion
    }
}
