using System;
using System.ComponentModel;

class Programa
{
    public static void Main()
    {
        Conta conta = new Conta("Joao", "69", 0, 1, true, 350);

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
            
            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                //Ver saldo
                case 1:
                {
                    conta.VerSaldo();
                    break;
                }
                
                //Sacar
                case 2:
                {
                    conta.Sacar();
                    break;
                }

                //Depositar
                case 3:
                {
                    conta.Depositar();
                    break;
                }
                
                //VerChequeEspeial
                case 4:
                {
                    conta.VerChequeEspecial();
                    break;
                }

                //Sair
                case 5:
                    Console.WriteLine("Saindo...");
                break;
                
                //Opção padrao
                default:
                    Console.WriteLine("Opção inválida!");
                break;
            }
        }
        
    }
}
