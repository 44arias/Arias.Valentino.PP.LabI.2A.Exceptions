using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public class Escaner {

        List<Documento> listaDocumentos;
        Departamento location;
        string marca;
        TipoDoc tipo;

        public enum Departamento {
            nulo,
            mapoteca,
            procesosTenicos
        }

        public enum TipoDoc {
            libro,
            mapa
        }

        public List<Documento> ListaDocumentos {
            get => listaDocumentos;
        }

        public Departamento Location {
            get => location;
        }

        public string Marca {
            get => marca;
        }

        public TipoDoc Tipo {
            get => tipo;
        }

        public bool CambiarEstadoDocumento(Documento d) => d == null 
            ? throw new ArgumentNullException(nameof(d), "El documento no puede ser nulo.")
                : listaDocumentos.Contains(d)
                    ? listaDocumentos[listaDocumentos.IndexOf(d)].AvanzarEstado()
                        : throw new ArgumentException("El documento no se encuentra en la lista del escáner.");


        public Escaner(string marca, TipoDoc tipo) {
            if (string.IsNullOrWhiteSpace(marca))
                throw new ArgumentException("La marca del escáner no puede estar vacía.");

            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();
            this.location = (tipo == TipoDoc.mapa) ? Departamento.mapoteca : Departamento.procesosTenicos;
        }

        public static bool operator ==(Escaner e, Documento d) {
            if (e == null || d == null)
                throw new ArgumentNullException("El escáner o el documento no pueden ser nulos.");

            return e.listaDocumentos.Contains(d);
        }

        public static bool operator !=(Escaner e, Documento d) {
            if (e == null || d == null)
                throw new ArgumentNullException("El escáner o el documento no pueden ser nulos.");

            return !(e == d);
        }

        public static Escaner operator +(Escaner e, Documento d) {
            if (e == null || d == null)
                throw new ArgumentNullException("El escáner o el documento no pueden ser nulos.");

            if (e == d)
                throw new ArgumentException("El documento ya está en la lista del escáner.");

            if (d.Estado != Documento.Paso.Inicio)
                throw new ArgumentException("Solo se pueden agregar documentos en estado 'Inicio'.");

            if (e.Tipo != (d is Libro ? TipoDoc.libro : TipoDoc.mapa))
                throw new ArgumentException("El tipo de documento no coincide con el tipo de escáner.");

            d.AvanzarEstado();
            e.listaDocumentos.Add(d);
            return e;
        }
    }
}