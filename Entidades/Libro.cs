using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    /// <summary>
    /// Representa un libro como un tipo específico de documento.
    /// </summary>
    public class Libro : Documento {

        /// <summary>
        /// Número de páginas del libro.
        /// </summary>
        int numPaginas;

        /// <summary>
        /// Obtiene el ISBN del libro (International Standard Book Number).
        /// </summary>
        public string ISBN {
            get => NumNormalizado;
        }

        /// <summary>
        /// Obtiene el número de páginas del libro.
        /// </summary>
        public int NumPaginas {
            get => this.numPaginas;
        }

        /// <summary>
        /// Constructor de la clase Libro.
        /// </summary>
        /// <param name="titulo">Título del libro.</param>
        /// <param name="autor">Autor del libro.</param>
        /// <param name="anio">Año de publicación del libro.</param>
        /// <param name="numNormalizado">ISBN del libro.</param>
        /// <param name="codebar">Código de barras del libro.</param>
        /// <param name="numPaginas">Número de páginas del libro.</param>
        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, codebar) {
            this.numPaginas = numPaginas;
        }

        /// <summary>
        /// Comprueba si dos libros son iguales (mismo código de barras, ISBN, o título y autor).
        /// </summary>
        /// <param name="l1">El primer libro.</param>
        /// <param name="l2">El segundo libro.</param>
        /// <returns>True si los libros son iguales, false en caso contrario.</returns>
        public static bool operator ==(Libro l1, Libro l2) {
            return (l1.Barcode == l2.Barcode) ||
                  (l1.ISBN == l2.ISBN) ||
                  (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor);
        }

        /// <summary>
        /// Comprueba si dos libros no son iguales.
        /// </summary>
        /// <param name="l1">El primer libro.</param>
        /// <param name="l2">El segundo libro.</param>
        /// <returns>True si los libros no son iguales, false en caso contrario.</returns>
        public static bool operator !=(Libro l1, Libro l2) {
            return !(l1 == l2);
        }

        /// <summary>
        /// Devuelve una representación en cadena del libro.
        /// </summary>
        /// <returns>Cadena con los detalles del libro.</returns>
        public override string ToString() {
            return base.ToString();
        }
    }
}