using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


internal class RepositorioCategorias: IRepositorio<Categoria>
{
    private static List<Categoria> _lista = new List<Categoria>();

    public static List<Categoria> ObtenerCategorias()
    {
        LlenarCategorias();
        return _lista;
    }

    private static void LlenarCategorias()
    {
        Categoria cat = new Categoria
        {
            ID = 1,
            Nombre = "Accion"
        };
        _lista.Add(cat);

        cat = new Categoria
        {
            ID = 2,
            Nombre = "Novela"
        };
        _lista.Add(cat);
        cat = new Categoria
        {
            ID = 3,
            Nombre = "Infantil"
        };
        _lista.Add(cat);
    }

    /// <summary>
    /// Retorna una lista de categorias
    /// </summary>
    /// <returns></returns>
    public List<Categoria> ObtenerDatos()
    {
        Categoria cat = new Categoria
        {
            ID = 0,
            Nombre="Todas"
        };
        _lista.Add(cat);
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=123456;database=biblioteca");
        MySqlCommand comm = new MySqlCommand("SELECT * FROM categorias", conn);
        comm.CommandType = System.Data.CommandType.Text;
        try
        {
            conn.Open();
            MySqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Categoria categoria= new Categoria
                    {
                        ID = Convert.ToInt32(dr["IDCategoria"].ToString()),
                        Nombre = dr["Nombre"].ToString()
                    };
                    _lista.Add(categoria);
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
}

