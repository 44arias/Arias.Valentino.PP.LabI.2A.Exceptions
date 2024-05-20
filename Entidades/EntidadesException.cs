using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    internal class EntidadesException : Exception {
        string nombreClase, nombreMetodo;

        public string NombreClase {
            get => nombreClase;
        }

        public string NombreMetodo {
            get => nombreMetodo;
        }

        public EntidadesException(string mensaje, string clase, string metodo, Exception innerException) 
            : base (mensaje, innerException) {
            nombreClase = clase;
            nombreMetodo = metodo;
        }

        public EntidadesException(string mensaje, string clase, string metodo)
            : this(mensaje, clase, metodo, null) { }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Excepción en el método {0} de la clase {1}\n", NombreMetodo, NombreClase);
            sb.AppendLine("Algo salió mal en el escáner, revisa los detalles");
            sb.AppendLine($"Detalles: {this.InnerException}");
            return sb.ToString();
        }
    }
}
