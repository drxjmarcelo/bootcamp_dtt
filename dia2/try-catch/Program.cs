using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


class Program
{
    static void Main()
    {
        List<Produto> estoque = new List<Produto>();

        string opcao;

        do
        {
            try
            {
                Console.WriteLine("Digite o nome do produto:");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite o preço do produto:");
                double preco = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Digite a quantidade em estoque:");
                int quantidade = Convert.ToInt32(Console.ReadLine());
            
                Produto produto = new Produto(nome, preco, quantidade);
                if (!string.IsNullOrWhiteSpace(nome))
                {
                    estoque.Add(produto);
                    Console.WriteLine("Produto cadastrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Cadastro não realizado! Produto inválido.");
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Erro: Formato inválido. Digite apenas números!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erro: Número fora do limite permitido!");
            }
            
            Console.WriteLine("\nDeseja cadastrar um novo produto? (s/n): ");
            opcao = Console.ReadLine().ToLower();
            
        }
        while (opcao == "s");
        Console.WriteLine($"\nProdutos totais no estoque: {estoque.Count}");
        Console.WriteLine("\nProdutos no estoque: ");
        foreach(var produto in estoque)
        {
            Console.WriteLine($"Nome: {produto.Nome} - Preco: {produto.Preco} - Quantidade: {produto.Quantidade}");
        }

        Console.WriteLine("Pressioe ENTER para sair.");
        Console.ReadLine();
    }
}

class Produto
{
    public string Nome {get; private set; }
    public double Preco {get; private set; }
    public int Quantidade {get; private set; }
    public Produto(string nome, double preco, int quantidade)
        {
            if (string.IsNullOrWhiteSpace(nome) || preco <= 0 || quantidade <= 0)
            {
                return;
            }
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

}