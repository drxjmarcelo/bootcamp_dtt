using System;
using System.ComponentModel;

class Programa
{
    public static void Main()
    {
        Conta conta = new Conta("Joao", "69", 1600, 1, true, 350);

        int opcao = -1;
        while (opcao != 5)
        {
            Console.WriteLine("Bem vindo ao Banco DTT");
            Console.WriteLine("Escolha uma Operação:");
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1 - Ver saldo");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Depositar");
            Console.WriteLine("4 - VerChequeEspecial");
            Console.WriteLine("5 - Sair");
            
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida!");
                Console.WriteLine("\n--Pressione ENTER para voltar ao menu--");
                Console.ReadLine();
                continue;
            }

            switch (opcao)
            {
                //Ver saldo
                case 1:
                    Servicos.VerSaldo(conta);
                    break;

                //Sacar
                case 2:
                    Servicos.Sacar(conta);
                    break;

                //Depositar
                case 3:
                    Servicos.Depositar(conta);
                    break;
                
                //VerChequeEspeial
                case 4:
                    Servicos.VerChequeEspecial(conta);
                    break;

                //Sair
                case 5:
                    Console.WriteLine("Saindo...");
                    break;
                
                //Opção padrão
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.WriteLine("\n--Pressione ENTER para voltar ao menu--");
                    Console.ReadLine();
                    break;
            }
        }
        
    }
}
