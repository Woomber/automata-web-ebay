using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatasFinitos.Modelos
{
    class Estado
    {
        public Dictionary<char, Estado> Transiciones { get; protected set; }
        public Automata AutomataPadre { get; set; }
        public string Aceptacion { get; protected set; }
        public Estado TransicionPorDefecto { get; protected set; }

        public Estado(string aceptacion = null)
        {
            Transiciones = new Dictionary<char, Estado>();
            Aceptacion = aceptacion;
        }

        public void AgregarTransicion(char transicion, Estado destino)
        {
            Transiciones.Add(transicion, destino);
        }

        public void AgregarTransicionPorDefecto(Estado destino)
        {
            TransicionPorDefecto = destino;
        }

        public Estado Navegar(char entrada)
        {
            if (Transiciones.TryGetValue(entrada, out Estado siguiente))
            {
                return siguiente;
            }

            if(TransicionPorDefecto != null)
            {
                return TransicionPorDefecto;
            }

            throw new Exception("No se definió una transición por defecto");

        }
    }
}
