
using Ejercicio35.Views.Empleados;
using Xamarin.Forms;

namespace Ejercicio35
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ListaEmpleados());
            //MainPage = new NavigationPage(new RegistroEmpleados());
            //MainPage = new NavigationPage(new DetalleEmpleado());
        }



        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
