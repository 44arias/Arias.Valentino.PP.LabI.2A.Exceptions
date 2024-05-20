using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public static class Informes {

        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen) {
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }

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

        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen) {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen) {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen) {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}