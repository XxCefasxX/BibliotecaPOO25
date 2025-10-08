using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Prestamo
{
    public int ID { get; set; }
    public int IDLibro { get; set; }
    public string Libro { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaDev { get; set; }
    public int IDCliente { get; set; }
    public string Cliente { get; set; }
}

