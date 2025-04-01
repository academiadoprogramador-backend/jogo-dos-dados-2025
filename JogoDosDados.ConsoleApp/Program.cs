namespace JogoDosDados.ConsoleApp
{
    /** Versão 2 - Controle de posição do jogador
        Armazenar a posição do jogador na pista e atualizar o valor após o lançamento do dado
        Exibir a posição atual do jogador na pista
        Definir a linha de chegada em 30 verificar se o jogador alcançou ou ultrapassou a linha de chegada
        Permitir o jogador realizar várias jogadas
    **/
    internal class Program
    {
        static void Main(string[] args)
        {
            const int limiteLinhaChegada = 30;

            while (true)
            {
                int posicaoUsuario = 0;
                bool jogoEstaEmAndamento = true;

                while (jogoEstaEmAndamento)
                {
                    ExibirCabecalho();

                    int resultado = LancarDado();

                    ExibirResultadoSorteio(resultado);

                    posicaoUsuario += resultado;

                    Console.WriteLine("---------------------------------------------");

                    if (posicaoUsuario >= limiteLinhaChegada)
                    {
                        Console.WriteLine("Parabéns, você alcançou a linha de chegada!");

                        jogoEstaEmAndamento = false;
                    }
                    else
                        Console.WriteLine($"O jogador está na posição: {posicaoUsuario} de {limiteLinhaChegada}");

                    Console.Write("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }

                string opcaoContinuar = ExibirMenuContinuar();
        
                if (opcaoContinuar != "S")
                    break;
            }
        }

        static void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Jogo dos Dados");
            Console.WriteLine("---------------------------------------------");

            Console.Write("Pressione ENTER para lançar o dado...");
            Console.ReadLine();
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
