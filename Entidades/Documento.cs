using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    /// <summary>
    /// Clase abstracta que representa un documento genérico (libro, mapa, etc.).
    /// </summary>
    public abstract class Documento {

        // Campos privados para almacenar los datos del documento
        int anio;
        string autor, barcode, numNormalizado, titulo;
        Paso estado;

        /// <summary>
        /// Enumeración que define los posibles estados de un documento.
        /// </summary>
        public enum Paso {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        // Propiedades públicas para acceder a los datos del documento (solo lectura)
        /// <summary>
        /// Obtiene el año de publicación del documento.
        /// </summary>
        public int Anio {
            get => this.anio;
        }

        /// <summary>
        /// Obtiene el autor del documento.
        /// </summary>
        public string Autor {
            get => this.autor;
        }

        /// <summary>
        /// Obtiene el código de barras del documento.
        /// </summary>
        public string Barcode {
            get => this.barcode;
        }

        /// <summary>
        /// Obtiene el estado actual del documento.
        /// </summary>
        public Paso Estado {
            get => this.estado;
        }

        // Propiedad protegida para acceder al número normalizado (solo lectura)
        /// <summary>
        /// Obtiene el número normalizado del documento (ISBN para libros).
        /// </summary>
        protected string NumNormalizado {
            get => this.numNormalizado;
        }

        /// <summary>
        /// Obtiene el título del documento.
        /// </summary>
        public string Titulo {
            get => this.titulo;
        }

        /// <summary>
        /// Avanza el estado del documento al siguiente paso.
        /// </summary>
        /// <returns>True si el estado avanzó, False si ya estaba en el estado final.</returns>
        public bool AvanzarEstado() {
            switch (this.estado) {
                case Paso.Inicio:
                    this.estado = Paso.Distribuido;
                    break;
                case Paso.Distribuido:
                    this.estado = Paso.EnEscaner;
                    break;
                case Paso.EnEscaner:
                    this.estado = Paso.EnRevision;
                    break;
                case Paso.EnRevision:
                    this.estado = Paso.Terminado;
                    break;
                case Paso.Terminado:
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Constructor de la clase Documento.
        /// </summary>
        /// <param name="titulo">Título del documento.</param>
        /// <param name="autor">Autor del documento.</param>
        /// <param name="anio">Año de publicación del documento.</param>
        /// <param name="numNormalizado">Número normalizado del documento (ISBN para libros).</param>
        /// <param name="barcode">Código de barras del documento.</param>
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode) {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
        }

        /// <summary>
        /// Devuelve una representación en cadena del documento.
        /// </summary>
        /// <returns>Cadena con los detalles del documento.</returns>
        public override string ToString() {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Título: {this.titulo}");
            text.AppendLine($"Autor: {this.autor}");
            text.AppendLine($"Año: {this.anio}");

            if (this is Libro) {
                text.AppendLine($"ISBN: {NumNormalizado}");
            }

            text.AppendLine($"Cód. de barras: {this.barcode}");
            text.AppendLine((this is Libro libro) ? $"Número de páginas: {libro.NumPaginas}"
                : (this is Mapa mapa) ? $"Superficie: {mapa.Alto} * {mapa.Ancho} = {mapa.Superficie} cm2" : "");
            return text.ToString();
        }
    }
}