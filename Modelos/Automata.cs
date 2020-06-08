using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatasFinitos.Modelos
{
    class Automata
    {
        public List<Estado> Estados { get; protected set; }

        public Estado EstadoInicial { get; protected set; }

        public Estado EstadoActual { get; protected set; }

        public Dictionary<string, uint> Repeticiones { get; protected set; }
 

        public Automata()
        {
            Estados = new List<Estado>();
            Repeticiones = new Dictionary<string, uint>();
        }

        public void AgregarEstado(Estado estado)
        {
            Estados.Add(estado);
            estado.AutomataPadre = this;
        }


        public void AgregarEstados(params Estado[] estados)
        {
            foreach(Estado estado in estados)
            {
               AgregarEstado(estado);
            }
        }

        public bool SetInicial(Estado estado)
        {
            bool isInEstados = Estados.IndexOf( estado) != -1;
            if(isInEstados)
            {
                EstadoInicial = estado;
                return true;
            }
            return false;
        }

        public Dictionary<string, uint> Evaluar(string cadena)
        {
            Repeticiones = new Dictionary<string, uint>();
            EstadoActual = EstadoInicial;
            while(cadena.Length > 0)
            {
                EstadoActual = EstadoActual.Navegar(cadena[0]);
                cadena = cadena.Substring(1);
                if(EstadoActual.Aceptacion != null)
                {
                    var ea = EstadoActual.Aceptacion;
                    if (Repeticiones.ContainsKey(ea))
                    {
                        Repeticiones[ea] = Repeticiones[ea] + 1;
                    } else
                    {
                        Repeticiones[ea] = 1;
                    }
                }
            }
            return Repeticiones;
        }

    }
}
