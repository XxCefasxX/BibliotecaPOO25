using BibliotecaForms.config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaForms.Repositorios
{
    internal class RepositorioPrestamos : IRepositorio<Prestamo>
    {
        private static List<Prestamo> _lista = new List<Prestamo>();

        public List<Prestamo> ObtenerDatos()
        {
            _lista.Clear();
            MySqlConnection conn = new MySqlConnection(Settings.connstr);
            MySqlCommand comm = new MySqlCommand("select p.id,fechaprestamo,fechadev, l.titulo as libro,c.nombre as cliente " +
                "from prestamos as p " +
                "inner join libros as l on p.libro=l.idlibro " +
                "inner join clientes as c on p.cliente=c.id;", conn);
            comm.CommandType = System.Data.CommandType.Text;
            try
            {
                conn.Open();
                MySqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Prestamo prestamo = new Prestamo
                        {
                            ID = Convert.ToInt32(dr["ID"].ToString()),
                            Cliente = dr["Cliente"].ToString(),
                            Libro = dr["Libro"].ToString(),
                            FechaPrestamo = Convert.ToDateTime(dr["fechaPrestamo"].ToString()),
                            FechaDev = Convert.ToDateTime(dr["fechaDev"].ToString())
                        };
                        _lista.Add(prestamo);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            return _lista;
        }

        public void RegistrarPrestamo(Prestamo prestamo)
        {
            MySqlConnection conn = new MySqlConnection(Settings.connstr);
            MySqlCommand comm = new MySqlCommand("insert into prestamos(libro,cliente,fechaprestamo,fechadev)" +
                "values(@libro,@cliente,@fechapres,@fechadev)", conn);
            comm.CommandType = System.Data.CommandType.Text;
            comm.Parameters.AddWithValue("@libro", prestamo.IDLibro);
            comm.Parameters.AddWithValue("@cliente", prestamo.IDCliente);
            comm.Parameters.AddWithValue("@fechapres", prestamo.FechaPrestamo);
            comm.Parameters.AddWithValue("@fechadev", prestamo.FechaDev);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
        }
   
        public void RealizarDevolucion(int IDPrestamo)
        {

        }
    
    }
}
