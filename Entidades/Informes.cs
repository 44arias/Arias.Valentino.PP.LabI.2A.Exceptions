using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    /// <summary>
    /// Clase estática que proporciona métodos para generar informes sobre documentos en un escáner.
    /// </summary>
    public static class Informes {

        /// <summary>
        /// Muestra información sobre los documentos distribuidos en un escáner.
        /// </summary>
        /// <param name="e">El escáner del cual obtener los documentos.</param>
        /// <param name="extension">Salida: La extensión total de los documentos (páginas para libros, superficie para mapas).</param>
        /// <param name="cantidad">Salida: La cantidad de documentos distribuidos.</param>
        /// <param name="resumen">Salida: Un resumen de los documentos distribuidos.</param>
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen) {
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }


        /// <summary>
        /// Método privado auxiliar para mostrar documentos en un estado específico.
        /// </summary>
        /// <param name="e">El escáner del cual obtener los documentos.</param>
        /// <param name="estado">El estado de los documentos a mostrar.</param>
        /// <param name="extension">Salida: La extensión total de los documentos (páginas para libros, superficie para mapas).</param>
        /// <param name="cantidad">Salida: La cantidad de documentos en el estado especificado.</param>
        /// <param name="resumen">Salida: Un resumen de los documentos en el estado especificado.</param>
        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen) {
            extension = 0;
            cantidad = 0;
            StringBuilder sb = new StringBuilder();

            foreach (Documento doc in e.ListaDocumentos) {
                if (doc.Estado == estado) {
                    cantidad++;
                    sb.AppendLine(doc.ToString());
                    extension += (doc is Libro libro) ? libro.NumPaginas : (doc is Mapa mapa) ? (int)mapa.Superficie : 0;
                }
            }

            resumen = sb.ToString();
        }

        /// <summary>
        /// Muestra información sobre los documentos que están siendo escaneados.
        /// </summary>
        /// <param name="e">El escáner del cual obtener los documentos.</param>
        /// <param name="extension">Salida: La extensión total de los documentos (páginas para libros, superficie para mapas).</param>
        /// <param name="cantidad">Salida: La cantidad de documentos en proceso de escaneo.</param>
        /// <param name="resumen">Salida: Un resumen de los documentos en proceso de escaneo.</param>
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen) {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }


        /// <summary>
        /// Muestra información sobre los documentos en revisión.
        /// </summary>
        /// <param name="e">El escáner del cual obtener los documentos.</param>
        /// <param name="extension">Salida: La extensión total de los documentos (páginas para libros, superficie para mapas).</param>
        /// <param name="cantidad">Salida: La cantidad de documentos en revisión.</param>
        /// <param name="resumen">Salida: Un resumen de los documentos en revisión.</param>
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen) {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Muestra información sobre los documentos terminados.
        /// </summary>
        /// <param name="e">El escáner del cual obtener los documentos.</param>
        /// <param name="extension">Salida: La extensión total de los documentos (páginas para libros, superficie para mapas).</param>
        /// <param name="cantidad">Salida: La cantidad de documentos terminados.</param>
        /// <param name="resumen">Salida: Un resumen de los documentos terminados.</param>
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen) {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}