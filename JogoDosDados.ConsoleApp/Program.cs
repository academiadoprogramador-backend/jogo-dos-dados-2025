namespace JogoDosDados.ConsoleApp
{
    /* Versão 5 Eventos Especiais:
        Requisitos:
        
        - Avanço extra: Se o competidor parar em uma posição específica (ex.: 5, 10, 15), ele avança +3
        casas. [x]
        - Recuo: Se o competidor parar em outra posição específica (ex.: 7, 13, 20), ele recua -2 casas. [x]
        - Rodada extra: Se o competidor tirar 6 no dado, ele ganha uma rodada extra. [x]
    */
    internal class Program
    {
        static int posicaoUsuario = 0;
        static int posicaoComputador = 0;
        static int limiteLinhaChegada = 30;

        static void Main(string[] args)
        {
            while (true)
            {
                bool jogoEstaEmAndamento = true;

                while (jogoEstaEmAndamento)
                {
                    bool usuarioVenceu = ExecutarRodadaUsuario();

                    Console.Write("Pressione ENTER para continuar...");
                    Console.ReadLine();

                    bool computadorVenceu = ExecutarRodadaComputador();

                    if (usuarioVenceu || computadorVenceu)
                        jogoEstaEmAndamento = false;

                    Console.WriteLine("---------------------------------------------");
                    Console.Write("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }

                string opcaoContinuar = ExibirMenuContinuar();
        
                if (opcaoContinuar != "S")
                    break;
            }
        }

        static bool ExecutarRodadaUsuario()
        {
            bool rodadaExtraUsuario;
            bool usuarioVenceu = false;

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

                    rodadaExtraUsuario = true;
                }

                else if (posicaoUsuario >= limiteLinhaChegada)
                {
                    Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                    Console.ReadLine();

                    usuarioVenceu = true;
                    break;
                }
                else
                    Console.WriteLine($"O jogador está na posição: {posicaoUsuario} de {limiteLinhaChegada}");

                Console.WriteLine("---------------------------------------------");

            } while (rodadaExtraUsuario);

            return usuarioVenceu;
        }

        static bool ExecutarRodadaComputador()
        {
            bool rodadaExtraComputador;
            bool computadorVenceu = false;

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

                    rodadaExtraComputador = true;
                }

                else if (posicaoComputador >= limiteLinhaChegada)
                {
                    Console.WriteLine("Que pena! O computador alcançou a linha de chegada!");
                    Console.ReadLine();

                    computadorVenceu = true;
                    break;
                }
                else
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

        static string ExibirMenuContinuar()
        {
            Console.WriteLine("---------------------------------------------");
            Console.Write("Deseja continuar? (s/N) ");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();

            return opcaoContinuar;
        }
    }
}
