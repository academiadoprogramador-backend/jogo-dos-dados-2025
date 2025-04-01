namespace JogoDosDados.ConsoleApp
{
    /* Versão 3 - Incluir o computador como oponente 
        Requisitos:

        Informar que o computador está jogando
        Armazenar a posição do computador na pista e atualizar o valor após o lançamento do dado
        Atualizar a posição do computador após seu lançamento de dado
        Exibir a nova posição
        Verificar se o computador alcançou ou ultrapassou a linha de chegada
        Informar quem venceu o jogo
        Implementar turnos alternados entre jogador e computador
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            const int limiteLinhaChegada = 30;

            while (true)
            {
                int posicaoUsuario = 0;
                int posicaoComputador = 0;

                bool jogoEstaEmAndamento = true;

                while (jogoEstaEmAndamento)
                {
                    // Turno do Usuário
                    ExibirCabecalho("Usuário");

                    int resultado = LancarDado();

                    ExibirResultadoSorteio(resultado);

                    posicaoUsuario += resultado;

                    if (posicaoUsuario >= limiteLinhaChegada)
                    {
                        Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                        Console.ReadLine();

                        jogoEstaEmAndamento = false;
                        continue;
                    }
                    else
                        Console.WriteLine($"O jogador está na posição: {posicaoUsuario} de {limiteLinhaChegada}");

                    Console.WriteLine("---------------------------------------------");

                    Console.Write("Pressione ENTER para continuar...");
                    Console.ReadLine();

                    // Turno do Computador
                    ExibirCabecalho("Computador");

                    int resultadoComputador = LancarDado();

                    ExibirResultadoSorteio(resultadoComputador);

                    posicaoComputador += resultadoComputador;


                    if (posicaoComputador >= limiteLinhaChegada)
                    {
                        Console.WriteLine("Que pena! O computador alcançou a linha de chegada!");
                        Console.ReadLine();

                        jogoEstaEmAndamento = false;
                        continue;
                    }
                    else
                        Console.WriteLine($"O computador está na posição: {posicaoComputador} de {limiteLinhaChegada}");

                    Console.WriteLine("---------------------------------------------");

                    Console.Write("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }

                string opcaoContinuar = ExibirMenuContinuar();
        
                if (opcaoContinuar != "S")
                    break;
            }
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
