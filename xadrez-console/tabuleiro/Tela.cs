using System;
using System.Collections.Generic;
using tabuleiro;
using util;
using xadrez;

namespace xadrez_console {
    class Tela {
        public static void imprimirPartida(PartidaDeXadrez partida) {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada) {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque) {
                    Console.WriteLine("XEQUE!");
                }
                Console.WriteLine();
            } else {
                Console.WriteLine("XEQUE-MATE");
                Console.WriteLine("Vencedor: "+partida.jogadorAtual);
                Console.WriteLine();
            }
        }

        public static void definirPecaPromocao(PartidaDeXadrez partida) {
            char charPeca = 'P';
            bool escolheu = false;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Informe o tipo de peça a ser promovida:");
            Console.WriteLine("D - Dama");
            Console.WriteLine("T - Torre");
            Console.WriteLine("B - Bispo");
            Console.WriteLine("C - Cavalo");
            Console.Write("Informe a letra em maiúsculo: ");

            while (!escolheu) {
                try {
                    charPeca = char.Parse(Console.ReadLine());

                    switch (charPeca) {
                        case 'D':
                            partida.pecaPromocao = new Dama(partida.tab, partida.jogadorAtual);
                            escolheu = true;
                            break;
                        case 'T':
                            partida.pecaPromocao = new Torre(partida.tab, partida.jogadorAtual);
                            escolheu = true;
                            break;
                        case 'B':
                            partida.pecaPromocao = new Bispo(partida.tab, partida.jogadorAtual);
                            escolheu = true;
                            break;
                        case 'C':
                            partida.pecaPromocao = new Cavalo(partida.tab, partida.jogadorAtual);
                            escolheu = true;
                            break;
                        default:
                            Console.WriteLine("Peça escolhida inválida!");
                            Console.Write("Informe a letra em maiúsculo: ");
                            break;
                    }                   
                } catch {
                    Console.WriteLine("Peça informada inválida!");
                    Console.Write("Informe a letra em maiúsculo: ");
                }
            }
            Console.WriteLine();
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[");
            foreach (Peca x in conjunto) {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

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
