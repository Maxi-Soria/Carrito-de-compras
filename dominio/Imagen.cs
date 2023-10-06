using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public int IdArticulo { get; set; }
        public string Url { get; set; }
        public Imagen()
        {
            IdArticulo = 0;
            Url = "";
        }
    }
}
