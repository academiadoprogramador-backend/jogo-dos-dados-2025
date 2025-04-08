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
                bool jogoEstaEmAndamento = true;

                Jogador jogador = new Jogador();
                jogador.nome = "Usuário";

                Jogador computador = new Jogador();
                jogador.nome = "Computador";

                while (jogoEstaEmAndamento)
                {                                       
                    jogador.RolarDados();                                                         

                    computador.RolarDados();

                    if (computador.Venceu || jogador.Venceu)
                    {
                        jogoEstaEmAndamento = false;

                        if (computador.posicaoAtual > jogador.posicaoAtual)
                            Console.WriteLine("Computador Venceu");

                        else if (jogador.posicaoAtual > computador.posicaoAtual)
                            Console.WriteLine("Jogador Venceu");

                        else 
                            Console.WriteLine("Empate");
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
}
