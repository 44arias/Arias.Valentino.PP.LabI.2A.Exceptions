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

        public bool CambiarEstadoDocumento(Documento d) => listaDocumentos.Contains(d) ? listaDocumentos[listaDocumentos.IndexOf(d)].AvanzarEstado() : false;

        public Escaner(string marca, TipoDoc tipo) {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();
            this.location = (tipo == TipoDoc.mapa) ? Departamento.mapoteca : Departamento.procesosTenicos;
        }

        public static bool operator ==(Escaner e, Documento d) {
            return e.listaDocumentos.Contains(d);
        }

        public static bool operator !=(Escaner e, Documento d) {
            return !(e == d);
        }

        public static Escaner operator +(Escaner e, Documento d) {
            if (e != d && d.Estado == Documento.Paso.Inicio && e.Tipo == (d is Libro ? TipoDoc.libro : TipoDoc.mapa)) {
                d.AvanzarEstado();
                e.listaDocumentos.Add(d);
            }
            return e;
        }
    }
}