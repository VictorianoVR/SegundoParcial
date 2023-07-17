using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    public class AgendaModel
    {
        
        [ColumnSqlAttribute("Nombre")]
        public string Nombre { get; set; }
        [ColumnSqlAttribute("Apellido")]
        public string Apellido { get; set; }
        [ColumnSqlAttribute("Direccion")]
        public string Direccion { get; set; }
        [ColumnSqlAttribute("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [ColumnSqlAttribute("Celular")]
        public string Celular { get; set; }
       
    }
}
