using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Ejercicio35.Models;
using Ejercicio35.Data;

namespace Ejercicio35.ViewModels.VMEmpleados
{
    public class VMRegistroEmpleados: BaseViewModel
    {
        #region VARIABLES
        string _Nombre;
        string _Apellidos;
        string _Edad;
        string _Direccion;
        string _Puesto;
        string _Foto;
      
        #endregion
        #region CONSTRUCTOR
        public VMRegistroEmpleados(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Nombre
        {
            get { return _Nombre; }
            set { SetValue(ref _Nombre, value); }
        }
        public string Apellidos
        {
            get { return _Apellidos; }
            set { SetValue(ref _Apellidos, value); }
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
        public string Foto
        {
            get { return _Foto; }
            set { SetValue(ref _Foto, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public async Task Insertar()
        {
            var funcion = new DEmpleados();
            var paramentros =new MEpleados();
            paramentros.Nombre=Nombre;
            paramentros.Apellidos = Apellidos;
            paramentros.Edad=Edad;
            paramentros.Direccion=Direccion;
            paramentros.Puesto = Puesto;
            paramentros.Foto=Foto;

            await funcion.InsertarEmpleados(paramentros);
            await Volver();

        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand Insertarcomand => new Command(async () => await Insertar());
        public ICommand Volvercomand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
