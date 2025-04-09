using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDosDados.ConsoleApp
{
    public class JogoDados
    {
        private Jogador jogador;
        private Jogador computador;
        public bool jogoEstaEmAndamento;

        public void NovoJogo()
        {
            jogador = new Jogador();
            jogador.nome = "Usuário";

            computador = new Jogador();
            computador.nome = "Computador";

            jogoEstaEmAndamento = true;
        }
        

        public void RealizarNovaRodada()
        {
            jogador.RolarDados();

            computador.RolarDados();

            if (computador.Venceu || jogador.Venceu)
            {
                jogoEstaEmAndamento = false;

                if (computador.posicaoAtual > jogador.posicaoAtual)
                    Console.WriteLine("Computador Venceu a partida ");

                else if (jogador.posicaoAtual > computador.posicaoAtual)
                    Console.WriteLine("Parabéns, vc venceu!!");

                else
                    Console.WriteLine("Deu empate");
            }
        }
    }
}
