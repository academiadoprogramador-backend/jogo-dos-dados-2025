using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDosDados.ConsoleApp
{
    public class Jogador
    {
        public string nome;
        public int posicaoAtual;
        const int limiteLinhaChegada = 30;
        public bool Venceu;


        public void RolarDados()
        {
            Random geradorDeNumeros = new Random();

            int resultado = geradorDeNumeros.Next(1, 7);

            AtualizarPosicao(resultado);

            ExibirResultadoSorteio(resultado);

            Console.Write("Pressione ENTER para continuar...");
            Console.ReadLine();
        }

        static void ExibirResultadoSorteio(int resultado)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"O valor sorteado foi: {resultado}");
            Console.WriteLine("---------------------------------------------");
        }


        public void AtualizarPosicao(int resultado)
        {
            ExibirCabecalho();

            bool rodadaExtraUsuario;

            do
            {
                rodadaExtraUsuario = false;

                posicaoAtual += resultado;

                if (posicaoAtual == 5 || posicaoAtual == 10 || posicaoAtual == 15 || posicaoAtual == 25)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Evento Especial: Avanço Extra de 3 casas!");
                    Console.WriteLine("---------------------------------------------");

                    posicaoAtual += 3;

                    Console.WriteLine($"Nova posição: {posicaoAtual}!");
                }

                else if (posicaoAtual == 7 || posicaoAtual == 13 || posicaoAtual == 20)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Evento Especial: Recuo de 2 casas!");
                    Console.WriteLine("---------------------------------------------");

                    posicaoAtual -= 2;

                    Console.WriteLine($"Nova posição: {posicaoAtual}!");
                }

                if (resultado == 6)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Evento Especial: RODADA EXTRA!");
                    Console.WriteLine("---------------------------------------------");

                    rodadaExtraUsuario = true;
                }

                else if (posicaoAtual >= limiteLinhaChegada)
                {
                    Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                    Console.ReadLine();

                    Venceu = false;
                    continue;
                }
                else
                    Console.WriteLine($"O jogador está na posição: {posicaoAtual} de {limiteLinhaChegada}");
                
                Console.WriteLine("---------------------------------------------");

            } while (rodadaExtraUsuario);
        }

        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Jogo dos Dados");
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine($"Turno do(a): {nome}");
            Console.WriteLine("---------------------------------------------");
        }
    }
}
