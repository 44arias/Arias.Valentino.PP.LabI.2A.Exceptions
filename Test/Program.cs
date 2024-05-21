using System;
using Entidades;

namespace TestConsola {
    class Program {
        static void Main(string[] args) {

            Escaner escanerNulo = new Escaner(null, Escaner.TipoDoc.libro);
            Escaner escanerVacio = new Escaner("", Escaner.TipoDoc.mapa);
            Console.ReadLine();
        }
    }
}
