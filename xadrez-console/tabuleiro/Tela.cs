using System;
using tabuleiro;
using util;
using xadrez;

namespace xadrez_console {
    class Tela {
        public static void imprimirTabuleiro(Tabuleiro tabuleiro) {
            int contadorColuna = 0;
            for (int i = 0; i < tabuleiro.linhas; i++) {
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    if (j == 0) {
                        Console.Write(tabuleiro.colunas - contadorColuna + " ");
                        contadorColuna++;
                    }
                    if (tabuleiro.peca(i,j) == null) {
                        Console.Write("- ");
                    } else {
                        imprimirPeca(tabuleiro.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.Write(" ");
            for (int i = 0; i < tabuleiro.colunas; i++) {
                Console.Write(" " + Alfabeto.getLetra(i));
            }
        }

        public static PosicaoXadrez lerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1].ToString());

            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca) {
            if (peca.cor == Cor.Branca) {
                Console.Write(peca);
            } else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
