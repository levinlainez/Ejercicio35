using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace Ejercicio35.Conexion
{
    public class CConexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://ejercicio35-87e5d-default-rtdb.firebaseio.com/");
    }
}
