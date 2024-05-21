using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    /// <summary>
    /// Representa un escáner que procesa documentos de tipos específicos.
    /// </summary>
    public class Escaner {

        /// <summary>
        /// Lista de documentos actualmente en el escáner.
        /// </summary>
        List<Documento> listaDocumentos;

        /// <summary>
        /// Departamento donde se encuentra el escáner.
        /// </summary>
        Departamento location;

        /// <summary>
        /// Marca del escáner.
        /// </summary>
        string marca;

        /// <summary>
        /// Tipo de documentos que el escáner puede procesar.
        /// </summary>
        TipoDoc tipo;

        /// <summary>
        /// Enumeración que representa los posibles departamentos.
        /// </summary>
        public enum Departamento {
            nulo,
            mapoteca,
            procesosTenicos
        }

        /// <summary>
        /// Enumeración que representa los posibles tipos de documentos.
        /// </summary>
        public enum TipoDoc {
            libro,
            mapa
        }

        /// <summary>
        /// Obtiene la lista de documentos en el escáner.
        /// </summary>
        public List<Documento> ListaDocumentos {
            get => listaDocumentos;
        }

        /// <summary>
        /// Obtiene el departamento donde se encuentra el escáner.
        /// </summary>
        public Departamento Location {
            get => location;
        }

        /// <summary>
        /// Obtiene la marca del escáner.
        /// </summary>
        public string Marca {
            get => marca;
        }

        /// <summary>
        /// Obtiene el tipo de documentos que el escáner puede procesar.
        /// </summary>
        public TipoDoc Tipo {
            get => tipo;
        }

        /// <summary>
        /// Cambia el estado de un documento en el escáner.
        /// </summary>
        /// <param name="d">El documento al que se le cambiará el estado.</param>
        /// <returns>True si el estado se cambió exitosamente, false en caso contrario.</returns>
        public bool CambiarEstadoDocumento(Documento d) => listaDocumentos.Contains(d) ? listaDocumentos[listaDocumentos.IndexOf(d)].AvanzarEstado() : false;

        /// <summary>
        /// Constructor de la clase Escaner.
        /// </summary>
        /// <param name="marca">Marca del escáner.</param>
        /// <param name="tipo">Tipo de documentos que el escáner puede procesar.</param>
        /// <exception cref="ArgumentException">Si la marca del escáner está vacía o es nula.</exception>
        public Escaner(string marca, TipoDoc tipo) {
            try {
                if (string.IsNullOrEmpty(marca))
                    throw new ArgumentException("La marca del escáner no puede ser vacía o nula.");

                this.marca = marca;
                this.tipo = tipo;
                this.listaDocumentos = new List<Documento>();
                this.location = (tipo == TipoDoc.mapa) ? Departamento.mapoteca : Departamento.procesosTenicos;
            }
            catch (ArgumentException ex) {
                Console.WriteLine("Excepción controlada capturada: " + ex.Message);
            }
        }

        /// <summary>
        /// Comprueba si un documento está en el escáner.
        /// </summary>
        /// <param name="e">El escáner.</param>
        /// <param name="d">El documento a comprobar.</param>
        /// <returns>True si el documento está en el escáner, false en caso contrario.</returns>
        public static bool operator ==(Escaner e, Documento d) {
            return e.listaDocumentos.Contains(d);
        }

        /// <summary>
        /// Comprueba si un documento no está en el escáner.
        /// </summary>
        /// <param name="e">El escáner.</param>
        /// <param name="d">El documento a comprobar.</param>
        /// <returns>True si el documento no está en el escáner, false en caso contrario.</returns>
        public static bool operator !=(Escaner e, Documento d) {
            return !(e == d);
        }

        /// <summary>
        /// Agrega un documento al escáner si es del tipo correcto y está en el estado inicial.
        /// </summary>
        /// <param name="e">El escáner.</param>
        /// <param name="d">El documento a agregar.</param>
        /// <returns>True si el documento se agregó correctamente, false en caso contrario.</returns>
        public static bool operator +(Escaner e, Documento d) {
            if (e != d && d.Estado == Documento.Paso.Inicio && e.Tipo == (d is Libro ? TipoDoc.libro : TipoDoc.mapa)) {
                d.AvanzarEstado();
                e.listaDocumentos.Add(d);
                return true;
            }
            return false;
        }
    }
}