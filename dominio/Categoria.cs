using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio   
{
    public class Categoria
    {
        public Categoria()
        {
            Id = 0;
            Descripcion = "";
        }
        public Categoria(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
        public int Id { get; set; }
        public string Descripcion { get; set;}

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
