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
                    imprimirPeca(tabuleiro.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.Write(" ");
            for (int i = 0; i < tabuleiro.colunas; i++) {
                Console.Write(" " + Alfabeto.getLetra(i));
            }
            Console.WriteLine();
        }

        public static void imprimirTabuleiro(Tabuleiro tabuleiro, bool[,] possicoesPossiveis) {
            int contadorColuna = 0;
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tabuleiro.linhas; i++) {
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    if (j == 0) {
                        Console.Write(tabuleiro.colunas - contadorColuna + " ");
                        contadorColuna++;
                    }
                    if (possicoesPossiveis[i,j]) {
                        Console.BackgroundColor = fundoAlterado;
                    } else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tabuleiro.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.Write(" ");
            for (int i = 0; i < tabuleiro.colunas; i++) {
                Console.Write(" " + Alfabeto.getLetra(i));
            }
            Console.BackgroundColor = fundoOriginal;
            Console.WriteLine();
        }

        public static PosicaoXadrez lerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1].ToString());

            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca) {
            if (peca == null) {
                Console.Write("- ");
            } else {
                if (peca.cor == Cor.Branca) {
                    Console.Write(peca);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
