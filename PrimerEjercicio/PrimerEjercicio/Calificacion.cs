using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Semana_Dos
{
    class Cliente
    {
        public Cliente(string argCodigo, string argNombre,
                        string argApellidos, string argDescripcion,
                       DateTime argFechaHoraRegistro)
        {
            Codigo = argCodigo;
            Nombre = argNombre;
            Apellidos = argApellidos;
            Descripcion = argDescripcion;
            FechaHoraRegistro = argFechaHoraRegistro;

        }


        private string _Codigo;
        //Las validaciones se hacen en la propiedad (en el set)
        //REglas
        //1) Es obligatorio
        //2) Debe tener 8 dígitos
        public string Codigo
        {
            get { return _Codigo; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El Codigo no puede quedar vacío.");
                }
                else if (value.Length != 4)
                {
                    throw new Exception("El Codigo debe tener exact. 4 digitos");
                }
                else
                {
                    _Codigo = value;
                }
            }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Apellidos;
        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private DateTime _FechaHoraRegistro;
        public DateTime FechaHoraRegistro
        {
            get { return _FechaHoraRegistro; }
            set { _FechaHoraRegistro = value; }
        }




        public void Insertar()
        {
            //Paso 01: Crear la conexión
            SqlConnection miConexion;
            // Servidor, Base de datos y modo de autenticación
            miConexion = new SqlConnection("SERVER=DAVID_VARGAS;DATABASE=EjercicioSEmAnAdos;USER=sa;PWD=david98vc");
            //miConexion = new SqlConnection("SERVER=WA27-2;DATABASE=EjercicioSemanaCero;Integrated security=true");

            //Paso 02: Definir el comando (Qué harás en la BD?)
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Calificacion_Insertar", miConexion);
            //Con esta línea le indico al Visual Studio que se trata de un P.A.
            elComando.CommandType = System.Data.CommandType.StoredProcedure;
            elComando.Parameters.AddWithValue("@parCodigo", Codigo);
            elComando.Parameters.AddWithValue("@parNombreBreve", Nombre);
            elComando.Parameters.AddWithValue("@parNombreCompleto", Apellidos);
            elComando.Parameters.AddWithValue("@parDescripcion", Descripcion);

            //Paso 03: Ejecutar el comando
            miConexion.Open(); //Abrir la conexión
            elComando.ExecuteNonQuery(); //Ejecutar el comando
            miConexion.Close(); //Cerrar la conexión

        }

        public static List<Cliente> Listar()
        {
            List<Cliente> Milistado = new List<Cliente>();

            SqlConnection miConexion;
            miConexion = new SqlConnection("SERVER=DAVID_VARGAS;DATABASE=EjercicioSEmAnAdos;USER=sa;PWD=david98vc");
            SqlCommand elComando;
            elComando = new SqlCommand("usp_Calificacion_Listar_Todo", miConexion);
            elComando.CommandType = System.Data.CommandType.StoredProcedure;


            miConexion.Open();
            SqlDataReader LOSDATOS;
            LOSDATOS = elComando.ExecuteReader();
            //LOSDATOS.Read()==true quiere decir "Mientras haya datos"
            while (LOSDATOS.Read() == true)
            {
                Cliente filaDeBaseDeDatos;
                filaDeBaseDeDatos = new Cliente(
                           Convert.ToString(LOSDATOS["Codigo"]),
                           Convert.ToString(LOSDATOS["NombreBreve"]),
                           Convert.ToString(LOSDATOS["NombreCompleto"]),
                           Convert.ToString(LOSDATOS["Descripcion"]),
                           Convert.ToDateTime(LOSDATOS["FechaHoraRegistro"])
                                                );
                //Con esta línea estamos agregando cada fila de la
                //base de datos capturado en un objeto de la clase
                //Cliente a Milistado
                Milistado.Add(filaDeBaseDeDatos);
            }
            miConexion.Close();

            return Milistado;
        }
    }
}
        //public static List<int> Metodo002()
        //{
        //    List<int> Milistado = new List<int>();

        //    return Milistado;
        //}

        //public static int Metodo003()
        //{
        //    int x = 100;

        //    return x;
        //}
