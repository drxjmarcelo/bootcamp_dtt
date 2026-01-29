using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;


class Program
{
    static void Main()
    {
        List<Produto> estoque = new List<Produto>();

        string opcao;
        string opcao1;

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
            
            Console.WriteLine("\nDeseja cadastrar mais algum produto? (s/n): ");
            opcao = Console.ReadLine().ToLower();
            
        }
        while (opcao == "s");
        
        Console.WriteLine($"\nProdutos totais no estoque: {estoque.Count}");
        Console.WriteLine("\nProdutos no estoque: ");
        foreach(var produto in estoque)
        {
            Console.WriteLine($"Nome: {produto.Nome} - Preco: {produto.Preco} - Quantidade: {produto.Quantidade}");
        } 

        Console.WriteLine("\nDeseja remover algum produto? (s/n)");
        opcao1 = Console.ReadLine().ToLower();

        while (opcao1 == "s")
        {
            if (estoque.Count == 0)
            {
                Console.WriteLine("Estoque vazio! Não há produtos para remover.");
                break;
            }

            for (int i = 0; i < estoque.Count; i++)
            {
                Console.WriteLine($"{i} - Nome: {estoque[i].Nome} - Preco: {estoque[i].Preco} - Quantidade: {estoque[i].Quantidade} ");
            }

            Console.WriteLine("\nDigite o número do produto que deseja remover:");
            int indice = Convert.ToInt32(Console.ReadLine());

            if (indice >= 0 && indice < estoque.Count)
            {
                estoque.RemoveAt(indice);
                Console.WriteLine("Produto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Índice inválido!");
            }
            
            Console.WriteLine("\nDeseja remover mais algum produto? (s/n)");
            opcao1 = Console.ReadLine().ToLower();
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