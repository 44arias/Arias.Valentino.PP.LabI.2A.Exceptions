using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {
    public abstract class Documento {
        int anio;
        string autor, barcode, numNormalizado, titulo;
        Paso estado;

        public enum Paso {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        public int Anio {
            get => this.anio;
        }

        public string Autor {
            get => this.autor;
        }

        public string Barcode {
            get => this.barcode;
        }

        public Paso Estado {
            get => this.estado;
        }

        protected string NumNormalizado {
            get => this.numNormalizado;
        }

        public string Titulo {
            get => this.titulo;
        }

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

        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode) {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
        }

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