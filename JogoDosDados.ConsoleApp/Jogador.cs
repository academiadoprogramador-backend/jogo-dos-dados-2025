namespace JogoDosDados.ConsoleApp;

public class Jogador
{
    int posicao = 0;
    public string nome = "";

    public bool ExecutarRodada()
    {
        bool rodadaExtra;
        bool jogadorVenceu = false;

        do
        {
            rodadaExtra = false;

            ExibirCabecalho();

            int resultado = LancarDado();

            ExibirResultadoSorteio(resultado);

            posicao += resultado;

            if (posicao == 5 || posicao == 10 || posicao == 15 || posicao == 25)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Evento Especial: Avanço Extra de 3 casas!");
                Console.WriteLine("---------------------------------------------");

                posicao += 3;

                Console.WriteLine($"Nova posição: {posicao}!");
            }

            else if (posicao == 7 || posicao == 13 || posicao == 20)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Evento Especial: Recuo de 2 casas!");
                Console.WriteLine("---------------------------------------------");

                posicao -= 2;

                Console.WriteLine($"Nova posição: {posicao}!");
            }

            if (resultado == 6)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Evento Especial: RODADA EXTRA!");
                Console.WriteLine("---------------------------------------------");

                rodadaExtra = true;
            }

            else if (posicao >= Program.limiteLinhaChegada)
            {
                Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                Console.ReadLine();

                jogadorVenceu = true;
                break;
            }
            else
                Console.WriteLine($"O jogador está na posição: {posicao} de {Program.limiteLinhaChegada}");

            Console.WriteLine("---------------------------------------------");

        } while (rodadaExtra);

        return jogadorVenceu;
    }

    void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"Turno do(a): {nome}");
        Console.WriteLine("---------------------------------------------");

        if (nome != "Computador")
        {
            Console.Write("Pressione ENTER para lançar o dado...");
            Console.ReadLine();
        }
    }

    int LancarDado()
    {
        Random geradorDeNumeros = new Random();

        int resultado = geradorDeNumeros.Next(1, 7);

        return resultado;
    }

    void ExibirResultadoSorteio(int resultado)
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"O valor sorteado foi: {resultado}");
        Console.WriteLine("---------------------------------------------");
    }
}
