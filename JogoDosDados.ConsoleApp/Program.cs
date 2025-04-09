namespace JogoDosDados.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {        
        while (true)
        {
            Jogador jogador = new Jogador();
            jogador.nome = "Usuário";

            Jogador computador = new Jogador();
            computador.nome = "Computador";

            bool jogoEstaEmAndamento = true;

            while (jogoEstaEmAndamento)
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

            Console.WriteLine("---------------------------------------------");
            Console.Write("Deseja continuar? (s/N) ");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();

            if (opcaoContinuar != "S")
                break;
        }
    }
}
