using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class Mapa : Documento {

        int alto, ancho;

        public int Alto {
            get => alto;
        }

        public int Ancho {
            get => ancho;
        }

        public int Superficie {
            get => this.alto * this.ancho;
        }

        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, codebar) {
            this.alto = alto;
            this.ancho = ancho;
        }

        public static bool operator ==(Mapa m1, Mapa m2) {
            return (m1.Barcode == m2.Barcode) ||
                   (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie);
        }

        public static bool operator !=(Mapa m1, Mapa m2) {
            return !(m1 == m2);
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}