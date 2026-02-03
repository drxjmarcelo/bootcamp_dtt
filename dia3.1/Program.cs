using System;
using System.Linq;

class Programa
{
    static void Main()
    {   
        Servicos servicos = new Servicos();
        List<Visitante> visitantes = new List<Visitante>();
        int proximoId = 1;

        int opcao = -1;

        while (opcao != 0)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1 - Cadastrar visitante");
            Console.WriteLine("2 - Listar visitantes");
            Console.WriteLine("3 - Buscar visitante por nome");
            Console.WriteLine("4 - Registrar saída");
            Console.WriteLine("5 - Ordenar por ID");
            Console.WriteLine("6 - Filtrar primeira visita");
            Console.WriteLine("0 - Sair");

            Console.Write("Escolha uma opção: ");
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida!");
                Console.WriteLine("\n--Pressione ENTER para voltar ao menu--");
                Console.ReadLine();
                continue;
            }

            switch (opcao)
            {
                //Cadastro
                case 1:
                {
                    servicos.Cadastrar();
                    break;
                }

                //Listar
                case 2:
                {
                    servicos.Listar();
                    break;
                }
                // Buscar
                case 3:
                {
                    servicos.Buscar();
                    break;
                }
                //Saída
                case 4:
                {
                    servicos.RegistrarSaida();
                    break;
                }
                //Id list
                case 5:
                {
                    servicos.OrdenarID();
                    break;
                }
                //Listar visitantes por primeira vez
                case 6:
                {
                    servicos.FiltrarPVisita();
                    break;
                }
                //Sair do Console...
                case 0:
                    Console.WriteLine("Saindo...");
                break;

                //auto explicativo 
                default:
                   Console.WriteLine("Opção inválida");
                   Console.ReadLine();
                break;
            }
        }

    }
}