using Ejercicio35.Data;
using Ejercicio35.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ejercicio35.ViewModels.VMEmpleados
{
    public class VMDetallesEmpeladoscs:BaseViewModel
    {
        #region VARIABLES
       
        string _Edad;
        string _Direccion;
        string _Puesto;

        private Guid Id;
        public MEpleados parametrosRecibe { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMDetallesEmpeladoscs(INavigation navigation, MEpleados parametrosTrae)
        {
            Navigation = navigation;
            parametrosRecibe = parametrosTrae;
        }

        public VMDetallesEmpeladoscs(INavigation navigation)
        {
            Navigation = navigation;
        }

        #endregion
        #region OBJETOS
        public Guid Ids
        {
            get { return this.Id; }
            set { SetValue(ref this.Id, value); }
        }
        
        public string Edad
        {
            get { return _Edad; }
            set { SetValue(ref _Edad, value); }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { SetValue(ref _Direccion, value); }
        }
        public string Puesto
        {
            get { return _Puesto; }
            set { SetValue(ref _Puesto, value); }
        }
      
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }

        public async Task Modificar()
        {
            var funcion = new DEmpleados();
            //var paramentros = new MEpleados();

            //paramentros.Id = Id;
            //paramentros.Direccion = Direccion;
            //paramentros.Edad = Edad;
            //paramentros.Puesto = Puesto;

            //await funcion.ModificarEmpleados(paramentros);

            var empleado = new MEpleados
            {
                Id = Ids,
                Direccion = Direccion,
                Edad = Edad,
                Puesto = Puesto

            };

            await funcion.ModificarEmpleados(empleado);
            await Volver();

        }

        public async Task EliminarEmpleado()
        {
            var funcion = new DEmpleados();

           

            await funcion.EliminarEmpleados(Ids);
            await Volver();

        }

        #endregion
        #region COMANDOS
        public ICommand Modificarcomand => new Command(async () => await Modificar());
        public ICommand EliminarEmpleadoComand => new Command(async () => await EliminarEmpleado());
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand Volvercomand => new Command(async () => await Volver());
        #endregion
    }
}
