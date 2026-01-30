using System;


class Programa
{
    static void Main()
    {
        try 
        {
            Console.WriteLine("Digite seu nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite sua idade:");
            int idade = Convert.ToInt32(Console.ReadLine());

            if (String.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Cadastro não realizado!");
                
            }
            else if (idade == 0)
            {
                Console.WriteLine("Cadastro não realizado! Idade deve ser maior que zero");
            }
            else
            {
                Console.WriteLine("Cadastro realizado!");
            }
        }
        
        catch (FormatException)
        {
            Console.WriteLine("Formato inválido! Digite apenas números.");
        }

    }
}