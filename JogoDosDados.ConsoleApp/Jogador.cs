using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDosDados.ConsoleApp
{
    internal class Jogador
    {
        static int posicaoUsuario = 0;
        public static bool RelizarJogada()
        {
            bool rodadaExtraUsuario;
            bool jogadorVenceu = false;
            const int limiteLinhaChegada = 30;

            do
            {
                rodadaExtraUsuario = false;

                ExibirCabecalho("Usuário");

                int resultado = LancarDado();

                ExibirResultadoSorteio(resultado);

                posicaoUsuario += resultado;

                if (posicaoUsuario == 5 || posicaoUsuario == 10 || posicaoUsuario == 15 || posicaoUsuario == 25)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Evento Especial: Avanço Extra de 3 casas!");
                    Console.WriteLine("---------------------------------------------");

                    posicaoUsuario += 3;

                    Console.WriteLine($"Nova posição: {posicaoUsuario}!");
                }

                else if (posicaoUsuario == 7 || posicaoUsuario == 13 || posicaoUsuario == 20)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Evento Especial: Recuo de 2 casas!");
                    Console.WriteLine("---------------------------------------------");

                    posicaoUsuario -= 2;

                    Console.WriteLine($"Nova posição: {posicaoUsuario}!");
                }

                if (resultado == 6)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Evento Especial: RODADA EXTRA!");
                    Console.WriteLine("---------------------------------------------");

                    Console.ReadLine();
                    rodadaExtraUsuario = true;
                }

                else if (posicaoUsuario >= limiteLinhaChegada)
                {
                    Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                    Console.ReadLine();

                    jogadorVenceu = true;
                }

                Console.WriteLine($"O jogador está na posição: {posicaoUsuario} de {limiteLinhaChegada}");

                Console.WriteLine("---------------------------------------------");

            } while (rodadaExtraUsuario);

            return jogadorVenceu;
        }

        static void ExibirCabecalho(string nomeJogador)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Jogo dos Dados");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Turno do(a): {nomeJogador}");
            Console.WriteLine("---------------------------------------------");

            if (nomeJogador != "Computador")
            {
                Console.Write("Pressione ENTER para lançar o dado...");
                Console.ReadLine();
            }
        }

        static int LancarDado()
        {
            Random geradorDeNumeros = new Random();

            int resultado = geradorDeNumeros.Next(1, 7);

            return resultado;
        }

        static void ExibirResultadoSorteio(int resultado)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"O valor sorteado foi: {resultado}");
            Console.WriteLine("---------------------------------------------");
        }
    }
}
