namespace JogoDosDados.ConsoleApp;

public class Jogador
{
    public string nome;
    public int posicaoAtual;
    const int limiteLinhaChegada = 30;
    public bool Venceu;


    public void RolarDados()
    {
        int numero = SortearNumero();            

        AtualizarPosicao(numero);

        if (posicaoAtual >= limiteLinhaChegada)            
            Venceu = true;                                        

        Console.Write("Pressione ENTER para continuar...");
        
        Console.ReadLine();
    }       

    public void AtualizarPosicao(int numeroSorteado)
    {
        ExibirCabecalho();

        ExibirNumeroSorteado(numeroSorteado);            

        bool rodadaExtraUsuario;

        do
        {
            rodadaExtraUsuario = false;

            posicaoAtual += numeroSorteado;

            Console.WriteLine($"O jogador está na posição: {posicaoAtual} de {limiteLinhaChegada}");

            if (posicaoAtual == 5 || posicaoAtual == 10 || posicaoAtual == 15 || posicaoAtual == 25)
            {
                Console.WriteLine("Evento Especial: Avanço Extra de 3 casas!");

                posicaoAtual += 3;

                Console.WriteLine($"Nova posição: {posicaoAtual}!");

                Console.WriteLine("---------------------------------------------");
            }

            else if (posicaoAtual == 7 || posicaoAtual == 13 || posicaoAtual == 20)
            {
                Console.WriteLine("Evento Especial: Recuo de 2 casas!");

                posicaoAtual -= 2;

                Console.WriteLine($"Nova posição: {posicaoAtual}!");

                Console.WriteLine("---------------------------------------------");
            }

            if (numeroSorteado == 6)
            {
                Console.WriteLine("Evento Especial: RODADA EXTRA!");

                rodadaExtraUsuario = true;

                numeroSorteado = SortearNumero();
                
                ExibirNumeroSorteado(numeroSorteado);                    
            }                                

        } while (rodadaExtraUsuario);
    }

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("---------------------------------------------");

        Console.WriteLine($"Turno: {nome}");
    }

    private static int SortearNumero()
    {
        Random geradorDeNumeros = new Random();

        return geradorDeNumeros.Next(1, 7);
    }

    static void ExibirNumeroSorteado(int resultado)
    {
        Console.WriteLine($"O valor sorteado foi: {resultado}");

        Console.WriteLine("---------------------------------------------");
    }
}
