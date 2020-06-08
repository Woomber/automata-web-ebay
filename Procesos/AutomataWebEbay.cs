using System;
using System.Collections.Generic;
using System.Text;
using AutomatasFinitos.Modelos;

namespace AutomatasFinitos.Procesos
{
    static class AutomataWebEbay
    {
        private static readonly Automata automata;

        static AutomataWebEbay() {
            automata = new Automata();

            var _1 = new Estado();
            var _12 = new Estado();
            var _135 = new Estado();
            var _146 = new Estado("web");
            var _15 = new Estado();
            var _16 = new Estado();
            var _17 = new Estado();
            var _18 = new Estado("ebay");

            _1.AgregarTransicion('w', _12);
            _1.AgregarTransicion('e', _15);
            _1.AgregarTransicionPorDefecto(_1);

            _12.AgregarTransicion('w', _12);
            _12.AgregarTransicion('e', _135);
            _12.AgregarTransicionPorDefecto(_1);

            _135.AgregarTransicion('b', _146);
            _135.AgregarTransicion('e', _15);
            _135.AgregarTransicionPorDefecto(_1);

            _146.AgregarTransicion('w', _12);
            _146.AgregarTransicion('a', _17);
            _146.AgregarTransicion('e', _15);
            _146.AgregarTransicionPorDefecto(_1);

            _15.AgregarTransicion('w', _12);
            _15.AgregarTransicion('e', _15);
            _15.AgregarTransicion('b', _16);
            _15.AgregarTransicionPorDefecto(_1);

            _16.AgregarTransicion('w', _12);
            _16.AgregarTransicion('a', _17);
            _16.AgregarTransicion('e', _15);
            _16.AgregarTransicionPorDefecto(_1);

            _17.AgregarTransicion('w', _12);
            _17.AgregarTransicion('e', _15);
            _17.AgregarTransicion('y', _18);
            _17.AgregarTransicionPorDefecto(_1);

            _18.AgregarTransicion('w', _12);
            _18.AgregarTransicion('e', _15);
            _18.AgregarTransicionPorDefecto(_1);

            automata.AgregarEstados(_1, _12, _135, _146, _15, _16, _17, _18);
            automata.SetInicial(_1);
        }

        public static Dictionary<string, uint> Evaluar(string texto)
        {
            return automata.Evaluar(texto.ToLower());
        }
    }
}
