using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDosDados.ConsoleApp
{
    internal class Computador
    {
        static int posicaoComputador = 0;
        public static bool RealizarJogada()
        {
            bool rodadaExtraComputador;

            bool computadorVenceu = false;
            const int limiteLinhaChegada = 30;

            do
            {
                rodadaExtraComputador = false;

                ExibirCabecalho("Computador");

                int resultadoComputador = LancarDado();

                ExibirResultadoSorteio(resultadoComputador);

                posicaoComputador += resultadoComputador;

                if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15 || posicaoComputador == 25)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Evento Especial: Avanço Extra de 3 casas!");
                    Console.WriteLine("---------------------------------------------");

                    posicaoComputador += 3;

                    Console.WriteLine($"Nova posição: {posicaoComputador}!");
                }

                else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Evento Especial: Recuo de 2 casas!");
                    Console.WriteLine("---------------------------------------------");

                    posicaoComputador -= 2;

                    Console.WriteLine($"Nova posição: {posicaoComputador}!");
                }

                if (resultadoComputador == 6)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Evento Especial: RODADA EXTRA!");
                    Console.WriteLine("---------------------------------------------");

                    Console.ReadLine();
                    rodadaExtraComputador = true;
                }

                else if (posicaoComputador >= limiteLinhaChegada)
                {
                    Console.WriteLine("Que pena! O computador alcançou a linha de chegada!");
                    Console.ReadLine();

                    computadorVenceu = true;
                }

                Console.WriteLine($"O computador está na posição: {posicaoComputador} de {limiteLinhaChegada}");

            } while (rodadaExtraComputador);

            return computadorVenceu;
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
