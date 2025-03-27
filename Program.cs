using System;

class Program
{
    static string[,] tabuleiro = new string[3, 3];
    static string jogadorO = "O";
    static string jogadorX = "X";
    static string jogadorAtual = jogadorX;

    static void Main()
    {
        int linha, coluna;
        bool fimDeJogo = false;

        while (!fimDeJogo)
        {
            if (jogadorAtual == jogadorO)
            {
                Random rand = new Random();
                bool jogadaValida = false;

                while (!jogadaValida)
                {
                    linha = rand.Next(0, 3);
                    coluna = rand.Next(0, 3);

                    if (tabuleiro[linha, coluna] == null)
                    {
                        jogadaValida = true;
                        tabuleiro[linha, coluna] = jogadorAtual;
                    }
                }

                Console.WriteLine($"Jogador O (Computador) jogou na linha {linha + 1}, coluna {coluna + 1}");
            }
            else
            {
                Console.WriteLine("Jogador atual: " + jogadorAtual);
                Console.WriteLine("Digite a linha (1 a 3):");
                linha = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.WriteLine("Digite a coluna (1 a 3):");
                coluna = Convert.ToInt32(Console.ReadLine()) - 1;

                if (linha < 0 || linha > 2 || coluna < 0 || coluna > 2)
                {
                    Console.WriteLine("Posição inválida. Tente novamente.");
                    continue;
                }
            }

            if (tabuleiro[linha, coluna] == null)
            {
                tabuleiro[linha, coluna] = jogadorAtual;

                if (
                    (tabuleiro[0, 0] == tabuleiro[0, 1] && tabuleiro[0, 1] == tabuleiro[0, 2] && tabuleiro[0, 0] != null) ||
                    (tabuleiro[1, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[1, 2] && tabuleiro[1, 0] != null) ||
                    (tabuleiro[2, 0] == tabuleiro[2, 1] && tabuleiro[2, 1] == tabuleiro[2, 2] && tabuleiro[2, 0] != null) ||
                    (tabuleiro[0, 0] == tabuleiro[1, 0] && tabuleiro[1, 0] == tabuleiro[2, 0] && tabuleiro[0, 0] != null) ||
                    (tabuleiro[0, 1] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 1] && tabuleiro[0, 1] != null) ||
                    (tabuleiro[0, 2] == tabuleiro[1, 2] && tabuleiro[1, 2] == tabuleiro[2, 2] && tabuleiro[0, 2] != null) ||
                    (tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2] && tabuleiro[0, 0] != null) ||
                    (tabuleiro[2, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[0, 2] && tabuleiro[2, 0] != null)
                )
                {
                    Console.Clear();
                    ImprimirTabuleiro();
                    Console.WriteLine($"Vitória do jogador {jogadorAtual}!");
                    fimDeJogo = true;
                }
                else if (
                    tabuleiro[0, 0] != null && tabuleiro[0, 1] != null && tabuleiro[0, 2] != null &&
                    tabuleiro[1, 0] != null && tabuleiro[1, 1] != null && tabuleiro[1, 2] != null &&
                    tabuleiro[2, 0] != null && tabuleiro[2, 1] != null && tabuleiro[2, 2] != null
                )
                {
                    Console.Clear();
                    ImprimirTabuleiro();
                    Console.WriteLine("Deu velha!");
                    fimDeJogo = true;
                }

                if (jogadorAtual == jogadorX)
                    jogadorAtual = jogadorO;
                else
                    jogadorAtual = jogadorX;
            }
            else
            {
                Console.WriteLine("Posição já ocupada. Tente novamente.");
                Console.ReadLine();
            }

            Console.Clear();
            ImprimirTabuleiro();
        }

        Console.ReadLine();
    }

    static void ImprimirTabuleiro()
    {
        for (int linhaTabuleiro = 0; linhaTabuleiro < 3; linhaTabuleiro++)
        {
            for (int colunaTabuleiro = 0; colunaTabuleiro < 3; colunaTabuleiro++)
            {
                if (tabuleiro[linhaTabuleiro, colunaTabuleiro] == null)
                    Console.Write("   ");
                else
                    Console.Write(" " + tabuleiro[linhaTabuleiro, colunaTabuleiro] + " ");
                if (colunaTabuleiro < 2)
                    Console.Write(" | ");
            }
            Console.WriteLine();
            if (linhaTabuleiro < 2)
                Console.WriteLine("----------------");
        }
    }
}
