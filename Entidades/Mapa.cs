using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    /// <summary>
    /// Representa un mapa como un tipo específico de documento.
    /// </summary>
    public class Mapa : Documento {

        /// <summary>
        /// Altura y ancho del mapa en centímetros.
        /// </summary>
        int alto, ancho;

        /// <summary>
        /// Obtiene la altura del mapa.
        /// </summary>
        public int Alto {
            get => alto;
        }

        /// <summary>
        /// Obtiene el ancho del mapa.
        /// </summary>
        public int Ancho {
            get => ancho;
        }

        /// <summary>
        /// Obtiene la superficie del mapa en centímetros cuadrados.
        /// </summary>
        public int Superficie {
            get => this.alto * this.ancho;
        }

        /// <summary>
        /// Constructor de la clase Mapa.
        /// </summary>
        /// <param name="titulo">Título del mapa.</param>
        /// <param name="autor">Autor del mapa.</param>
        /// <param name="anio">Año de publicación del mapa.</param>
        /// <param name="numNormalizado">Número de referencia del mapa.</param>
        /// <param name="codebar">Código de barras del mapa.</param>
        /// <param name="ancho">Ancho del mapa en centímetros.</param>
        /// <param name="alto">Alto del mapa en centímetros.</param>
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, codebar) {
            this.alto = alto;
            this.ancho = ancho;
        }

        /// <summary>
        /// Comprueba si dos mapas son iguales (mismo código de barras, título, autor, año y superficie).
        /// </summary>
        /// <param name="m1">El primer mapa.</param>
        /// <param name="m2">El segundo mapa.</param>
        /// <returns>True si los mapas son iguales, false en caso contrario.</returns>
        public static bool operator ==(Mapa m1, Mapa m2) {
            return (m1.Barcode == m2.Barcode) ||
                   (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie);
        }

        /// <summary>
        /// Comprueba si dos mapas no son iguales.
        /// </summary>
        /// <param name="m1">El primer mapa.</param>
        /// <param name="m2">El segundo mapa.</param>
        /// <returns>True si los mapas no son iguales, false en caso contrario.</returns>
        public static bool operator !=(Mapa m1, Mapa m2) {
            return !(m1 == m2);
        }

        /// <summary>
        /// Devuelve una representación en cadena del mapa.
        /// </summary>
        /// <returns>Cadena con los detalles del mapa.</returns>
        public override string ToString() {
            return base.ToString();
        }
    }
}