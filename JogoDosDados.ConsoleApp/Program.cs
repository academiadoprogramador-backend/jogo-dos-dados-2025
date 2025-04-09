namespace JogoDosDados.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        //teste
        while (true)
        {
            JogoDados jogo = new JogoDados();
            jogo.NovoJogo(); 

            while (jogo.jogoEstaEmAndamento)
            {
                jogo.RealizarNovaRodada();                   
            }

            Console.WriteLine("---------------------------------------------");
            Console.Write("Deseja continuar? (s/N) ");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();

            if (opcaoContinuar != "S")
                break;
        }
    }
}
