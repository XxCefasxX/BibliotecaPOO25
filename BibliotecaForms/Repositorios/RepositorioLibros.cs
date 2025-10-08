using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaForms.config;
using MySql.Data.MySqlClient;


internal class RepositorioLibros : IRepositorio<Libro>
{
    private static List<Libro> _lista = new List<Libro>();
    public List<Libro> ObtenerDatos()
    {
        MySqlConnection conn = new MySqlConnection(Settings.connstr);
        MySqlCommand comm = new MySqlCommand("SELECT * FROM libros", conn);
        comm.CommandType = System.Data.CommandType.Text;
        try
        {           
            conn.Open();
            MySqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Libro libro = new Libro
                    {
                        ID=Convert.ToInt32(dr["IDLibro"].ToString()),
                        Titulo = dr["Titulo"].ToString(),
                        Fecha= Convert.ToDateTime(dr["Fecha"].ToString()),
                        Paginas = Convert.ToInt32(dr["Paginas"].ToString())
                    };
                    _lista.Add(libro);
                }        
            }
            dr.Close();
        }
        catch(Exception ex)
        {
        }
        finally
        {
            conn.Close();
        }
        return _lista;
    }


    public void RegistrarLibro(string titulo,string fecha,int paginas,int autor,int categoria, int editorial)
    {
       
        MySqlConnection conn = new MySqlConnection(Settings.connstr);
        MySqlCommand comm = new MySqlCommand("insert into libros(titulo,fecha,paginas,categoria,autor,editorial) " +
           $"Values ('{titulo}','{fecha}',{paginas},{autor},{categoria},{editorial});", conn);
        comm.CommandType = System.Data.CommandType.Text;
        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }
        catch (Exception ex) { }
        finally
        {
            conn.Close();
        }
    }

    /// <summary>
    /// Realiza una busqueda de los libros
    /// </summary>
    /// <param name="titulo">TItulo del libro</param>
    /// <param name="IDCategoria">Categoria a la que qpertenece el libro</param>
    /// <returns>Datatable con la lista de libros</returns>
    public DataTable BuscarTitulo(string titulo,int IDCategoria)
    {

        DataTable dtLibros = new DataTable();
        MySqlConnection conn = new MySqlConnection(Settings.connstr);
        MySqlCommand comm = new MySqlCommand(
            $"select * from libros where titulo like  concat('%', '{titulo}','%')  " +
            $"and categoria=if({IDCategoria}>0,{IDCategoria}, categoria);", conn);
        comm.CommandType = System.Data.CommandType.Text;
        try
        {
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            da.Fill(dtLibros);
        }
        catch (Exception ex) 
        { }
        finally
        {
            conn.Close();
        }
        return dtLibros;
    }

    public List<Libro> ObtenerLibros()
    {
        ObtenerDatos();
        return _lista;
    }

    private static void llenarLibros()
    {

        Libro lib = new Libro
        {
            ID = 1,
            Titulo = "Señor de los anillos",
            Autor = new Autor
            {
                ID = 1,
                Nombre = "Juan"
            },
            Categoria = new Categoria
            {
                ID = 1,
                Nombre = "Accion"
            },
            Paginas = 450

        };
        _lista.Add(lib);
        lib = new Libro
        {
            ID = 3,
            Titulo = "Señor de los anillos 2",
            Autor = new Autor
            {
                ID = 1,
                Nombre = "Juan"
            },
            Categoria = new Categoria
            {
                ID = 1,
                Nombre = "Accion"
            },
            Paginas = 450
        };
        _lista.Add(lib);

    }

    public static Libro ObtenerLibroPorId(int IdLibro)
    {
        llenarLibros();
        return _lista.Find(libro => libro.ID == IdLibro);
    }

    public static Libro ObtenerLibroPorTitulo(string titulo)
    {
        llenarLibros();
        return _lista.Find(libro => libro.Titulo == titulo);
    }


    public static Libro BuscarLibro(int id)
    {

        return new Libro();
    }

    public static Libro BuscarLibro(string titulo)
    {

        return new Libro();
    }




}

