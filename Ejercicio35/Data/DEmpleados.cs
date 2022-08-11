using System;
using System.Collections.Generic;
using System.Text;
using Ejercicio35.Models;
using Ejercicio35.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Firebase.Database;

namespace Ejercicio35.Data
{
    public class DEmpleados
    {
        public async Task InsertarEmpleados(MEpleados parametros)
        {
            await CConexion.firebase
                .Child("Empleado")
                .PostAsync(new MEpleados()
                {
                    Id = Guid.NewGuid(),
                    Apellidos = parametros.Apellidos,
                    ColorFondo = parametros.ColorFondo,
                    Edad = parametros.Edad,
                    Foto = parametros.Foto,
                    Nombre = parametros.Nombre,
                    Puesto = parametros.Puesto,
                    Direccion = parametros.Direccion,

                }); 
        }

         public async Task ModificarEmpleados(MEpleados parametros)
        {
            //var data = (await CConexion.firebase
            //     .Child("Empleado")
            //     .OnceAsync<MEpleados>())
            //     .Where(x => x.Key==parametros.Id)
            //     .FirstOrDefault();
            //    data.Object.Direccion = parametros.Direccion;
            //    data.Object.Edad = parametros.Edad;
            //    data.Object.Puesto = parametros.Puesto;

            //await CConexion.firebase
            //    .Child("Empleado")
            //    .Child(data.Key)
            //    .PutAsync(data.Object);

            var actualizar = (await CConexion.firebase
                .Child("Empleado")
                .OnceAsync<MEpleados>()).Where(a => a.Object.Id == parametros.Id).FirstOrDefault();

            actualizar.Object.Direccion = parametros.Direccion;
            actualizar.Object.Edad = parametros.Edad;
            actualizar.Object.Puesto = parametros.Puesto;
            await CConexion.firebase
                .Child("Empleado")
                .Child(actualizar.Key)
                .PutAsync(new MEpleados()
                {
                    Id= parametros.Id, Edad=parametros.Edad, Direccion=parametros.Direccion, Puesto=parametros.Puesto
                });
        
        }

        public async Task EliminarEmpleados(Guid parametros)
        {
            var data = (await CConexion.firebase
                 .Child("Empleado")
                 .OnceAsync<MEpleados>())
                 .Where(x => x.Object.Id == parametros).FirstOrDefault();
                
      

            await CConexion.firebase
                .Child("Empleado")
                .Child(data.Key)
                .DeleteAsync();
        }

    


        public async Task<ObservableCollection<MEpleados>> MostrarEmpleados()
        {
            //return (await CConexion.firebase
            //       .Child("Empleado")
            //       .OnceAsync<MEpleados>())
            //       .Select(item => new MEpleados
            //       {
            //           Id=item.Key,
            //           Nombre=item.Object.Nombre,
            //           Apellidos=item.Object.Apellidos,
            //           Edad=item.Object.Edad,
            //           Direccion=item.Object.Direccion,
            //           Puesto=item.Object.Puesto,
            //           Foto=item.Object.Foto
            //       }).ToList();

            var data = await Task.Run (()=>CConexion.firebase
                .Child("Empleado")
                .AsObservable<MEpleados>()
                .AsObservableCollection());
            return data;

                   
        }


    }
}
