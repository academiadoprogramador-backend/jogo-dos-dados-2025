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
        static void Main(string[] args)
        {
            while (true)
            {
                bool jogoEmAndamento = true;

                Jogador jogador = new Jogador();
                Jogador computador = new Jogador();   

                while (jogoEmAndamento)
                {
                    bool jogadorVenceu = jogador.RealizarJogada();
                    
                    Console.Write("Pressione ENTER para continuar...");
                    Console.ReadLine();

                    bool computadorVenceu = computador.RealizarJogada();

                    if (jogadorVenceu || computadorVenceu)
                        jogoEmAndamento = false;

                    Console.WriteLine("---------------------------------------------");

                    Console.Write("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }

                string opcaoContinuar = ExibirMenuContinuar();

                if (opcaoContinuar != "S")
                    break;
            }
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
