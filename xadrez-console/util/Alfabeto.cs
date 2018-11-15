using System;
using System.Collections.Generic;

namespace util {
    class Alfabeto {
        public static char[] ArrayAlfabeto = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        public static char getLetra(int index) {
            return ArrayAlfabeto[index];
        }

        public static Array getAlfabeto() {
            return ArrayAlfabeto;
        }
    }
}
