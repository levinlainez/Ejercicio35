using Ejercicio35.ViewModels.VMEmpleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio35.Views.Empleados
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroEmpleados : ContentPage
    {
        public RegistroEmpleados()
        {
            InitializeComponent();
            BindingContext = new VMRegistroEmpleados(Navigation);
        }
    }
}