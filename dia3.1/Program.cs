using System;
using System.Linq;

class Programa
{
    static void Main()
    {
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
            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                //Cadastro
                case 1:
                {
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("CPF: ");
                    string cpf = Console.ReadLine();

                    Console.Write("Primeira vez? (s/n): ");
                    bool primeiraVez = Console.ReadLine().ToLower() == "s";

                    Visitante v = new Visitante(proximoId++, nome, cpf, primeiraVez);

                    visitantes.Add(v);

                    Console.WriteLine("Cadastrado com sucesso!");
                    break;
                }

                //Listar
                case 2:
                {
                    if (visitantes.Count == 0)
                    {
                        Console.WriteLine("Nenhum visitante cadastrado.");
                        break;
                    }

                    Console.WriteLine("\n=== LISTA DE VISITANTES ===");

                    foreach (Visitante v in visitantes)
                    {
                        Console.WriteLine("---------------------------");
                        Console.WriteLine($"ID: {v.Id}");
                        Console.WriteLine($"Nome: {v.Nome}");
                        Console.WriteLine($"CPF: {v.Cpf}");
                        Console.WriteLine($"Hora de chegada: {v.HoraChegada}");
                        Console.WriteLine($"Primeira vez: {(v.PrimeiraVez ? "Sim" : "Não")}");

                        if (v.HoraSaida == null)
                        {
                            Console.WriteLine("Saída: Ainda no local");
                        }
                        else
                        {
                            Console.WriteLine($"Saída: {v.HoraSaida}");
                        }
                    }
                    break;
                }
                // Buscar
                case 3:
                {
                    Console.Write("Digite o nome para buscar: ");
                    string buscaNome = Console.ReadLine().ToLower();

                    bool encontrou = false;

                    foreach (Visitante v in visitantes)
                    {
                        if (v.Nome.ToLower().Contains(buscaNome))
                        {
                            Console.WriteLine("---------------------------");
                            Console.WriteLine($"ID: {v.Id}");
                            Console.WriteLine($"Nome: {v.Nome}");
                            Console.WriteLine($"CPF: {v.Cpf}");
                            Console.WriteLine($"Hora de chegada: {v.HoraChegada}");
                            Console.WriteLine($"Primeira vez: {(v.PrimeiraVez ? "Sim" : "Não")}");

                            if (v.HoraSaida == null)
                                Console.WriteLine("Saída: Ainda no local");
                            else
                                Console.WriteLine($"Saída: {v.HoraSaida}");

                            encontrou = true;
                        }
                    }

                    if (!encontrou)
                    {
                        Console.WriteLine("Nenhum visitante encontrado.");
                    }
                    break;
                }
                //Saída
                case 4:
                {
                    Console.Write("Digite o ID do visitante: ");
                    int idBusca = Convert.ToInt32(Console.ReadLine());

                    bool encontrou = false;

                    foreach (Visitante v in visitantes)
                    {
                        if (v.Id == idBusca)
                        {
                            v.RegistrarSaida();
                            Console.WriteLine("Saída registrada com sucesso!");
                            encontrou = true;
                            break;
                        }
                    }

                    if (!encontrou)
                    {
                        Console.WriteLine("Visitante não encontrado.");
                    }
                    break;
                }
                //Id list
                case 5:
                {
                    var ordenados = visitantes.OrderBy(v => v.Id);

                    foreach (Visitante v in ordenados)
                    {
                        Console.WriteLine($"{v.Id} - {v.Nome} - {v.Cpf} - {v.HoraChegada}" + (v.HoraSaida == null ? "Ainda no local" : v.HoraSaida.ToString()));
                    }

                    break;
                }
                //Listar visitantes por primeira vez
                case 6:
                {
                    var primeiraVisita = visitantes.Where(v => v.PrimeiraVez);

                    if (!primeiraVisita.Any())
                    {
                        Console.WriteLine("Nenhum visitante de primeira viagem.");
                        break;
                    }

                    Console.WriteLine("\n=== PRIMEIRA VISITA ===");

                    foreach (Visitante v in primeiraVisita)
                    {
                        Console.WriteLine(
                            $"{v.Id} - {v.Nome} - {v.Cpf} - {v.HoraChegada}"
                        );
                    }
                    
                    break;
                }
                //Sair do Console...
                case 0:
                    Console.WriteLine("Saindo...");
                break;

                //auto explicativo 
                default:
                    Console.WriteLine("Opção inválida");
                break;
            }
        }

    }
}