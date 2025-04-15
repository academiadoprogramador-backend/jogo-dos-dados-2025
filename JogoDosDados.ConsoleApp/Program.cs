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

                while (jogoEstaEmAndamento)
                {
                    bool usuarioVenceu = Usuario.ExecutarRodada();

                    Console.Write("Pressione ENTER para continuar...");
                    Console.ReadLine();

                    bool computadorVenceu = Computador.ExecutarRodada();

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

        static string ExibirMenuContinuar()
        {
            Console.WriteLine("---------------------------------------------");
            Console.Write("Deseja continuar? (s/N) ");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();

            return opcaoContinuar;
        }
    }
}
