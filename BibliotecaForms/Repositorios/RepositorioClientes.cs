using BibliotecaForms.config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class RepositorioClientes: IRepositorio<Cliente>
{


    public static List<Cliente> _lista = new List<Cliente>();

    public List<Cliente> ObtenerDatos()
    {
        MySqlConnection conn = new MySqlConnection(Settings.connstr);
        MySqlCommand comm = new MySqlCommand("SELECT * FROM Clientes", conn);
        comm.CommandType = System.Data.CommandType.Text;
        try
        {
            conn.Open();
            MySqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        ID = Convert.ToInt32(dr["ID"].ToString()),
                        Nombre = dr["Nombre"].ToString()
                    };
                    _lista.Add(cliente);
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

