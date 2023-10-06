using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Marca
    {
        public Marca() 
        {
            Id = 0;
            Descripcion = "";
        }
        public Marca(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
        
    }
}
