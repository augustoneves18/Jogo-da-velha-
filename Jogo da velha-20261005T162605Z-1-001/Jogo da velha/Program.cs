using System;

class Program
{
    static char[,] tabuleiro = {
        { '1','2','3' },
        { '4','5','6' },
        { '7','8','9' }
    };

    static char jogadorAtual = 'X';

    static void Main()
    {
        int rodadas = 0;
        bool venceu = false;

        while (rodadas < 9 && !venceu)
        {
            Console.Clear();
            DesenharTabuleiro();

            Console.WriteLine($"Vez do jogador {jogadorAtual}. Escolha uma posição (1-9): ");
            string entrada = Console.ReadLine();

            if (TentarJogada(entrada))
            {
                venceu = VerificarVitoria();
                if (!venceu)
                {
                    jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
                    rodadas++;
                }
            }
            else
            {
                Console.WriteLine("Posição inválida ou ocupada! Pressione ENTER para tentar novamente.");
                Console.ReadLine();
            }
        }

        Console.Clear();
        DesenharTabuleiro();

        if (venceu)
        {
            Console.WriteLine($"Parabéns! O jogador {jogadorAtual} venceu!");
        }
        else
        {
            Console.WriteLine("O jogo deu velha (empate).");
        }
    }

    static void DesenharTabuleiro()
    {
        Console.WriteLine("Jogo da Velha\n");

        Console.WriteLine($" {tabuleiro[0, 0]} | {tabuleiro[0, 1]} | {tabuleiro[0, 2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {tabuleiro[1, 0]} | {tabuleiro[1, 1]} | {tabuleiro[1, 2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {tabuleiro[2, 0]} | {tabuleiro[2, 1]} | {tabuleiro[2, 2]} \n");
    }

    static bool TentarJogada(string escolha)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tabuleiro[i, j] == escolha[0])
                {
                    tabuleiro[i, j] = jogadorAtual;
                    return true;
                }
            }
        }
        return false;
    }

    static bool VerificarVitoria()
    {
        // Linhas e Colunas
        for (int i = 0; i < 3; i++)
        {
            if (tabuleiro[i, 0] == tabuleiro[i, 1] && tabuleiro[i, 1] == tabuleiro[i, 2])
                return true;
            if (tabuleiro[0, i] == tabuleiro[1, i] && tabuleiro[1, i] == tabuleiro[2, i])
                return true;
        }
        // Diagonais
        if (tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2])
            return true;
        if (tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0])
            return true;

        return false;
    }
}