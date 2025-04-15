namespace JogoDosDados.ConsoleApp
{
    internal class Program
    {
        public static int limiteLinhaChegada = 30;

        static void Main(string[] args)
        {
            while (true)
            {
                bool jogoEstaEmAndamento = true;

                Jogador usuario = new Jogador();
                usuario.nome = "Usuário";

                Jogador computador = new Jogador();
                computador.nome = "Computador";

                while (jogoEstaEmAndamento)
                {
                    bool usuarioVenceu = usuario.ExecutarRodada();

                    Console.Write("Pressione ENTER para continuar...");
                    Console.ReadLine();

                    bool computadorVenceu = computador.ExecutarRodada();

                    if (usuarioVenceu || computadorVenceu) jogoEstaEmAndamento = false;

                    Console.WriteLine("---------------------------------------------");
                    Console.Write("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }
        
                if (ExibirMenuContinuar() != "S") break;
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
