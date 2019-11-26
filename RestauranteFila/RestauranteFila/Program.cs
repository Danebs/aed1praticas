using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteFila
{
    class Restaurante
    {
        public ConsoleKeyInfo opc;

        public void Menu()
        {
            int clienteAtual = 0;
            int cliente = 0;
            Fila f1 = new Fila(100);
            Fila f2 = new Fila(100);
            Fila f3 = new Fila(100);

            do
            {
                Console.Clear();
                Console.WriteLine("\n|| Menu de ações:");
                Console.WriteLine("\n|| 1 - Inserir CLiente na fila de pedidos");
                Console.WriteLine("\n||2 - Remover Cliente da fila de pedidos");
                Console.WriteLine("\n||3 - Remover Cliente da fila de pagamentos");
                Console.WriteLine("\n||4 - Remover cliente da fila de encomendas");
                Console.WriteLine("\n||5 - Sair");
                Console.Write("\n\tPressiona a tecla correspondente a sua escolha:");
                opc = Console.ReadKey();
            
                switch (opc.Key)
                {
                    case ConsoleKey.D1:
                        cliente++;
                        f1.Inserir(cliente);
                        Console.WriteLine("\n\n\t\t==== Cliente {0} ====\n - Entrou na ||| Fila de pedidos |||", cliente);
                        break;
                    case ConsoleKey.D2:
                        clienteAtual = f1.desenfileirar();
                        Console.WriteLine("\n\n\t\t==== O cliente {0} ====\n\n - Saiu da fila de pedidos e entrou na ||| Fila de Pagamentos |||", clienteAtual);
                        f2.Inserir(clienteAtual);
                        
                        break;
                    case ConsoleKey.D3:
                        clienteAtual = f2.desenfileirar();
                        Console.WriteLine("\n\n\t\t==== O cliente {0} ====\n\n - Saiu da fila de pagamentos e entrou na ||| Fila de encomendas  |||", clienteAtual);
                        f3.Inserir(clienteAtual);
                        break;
                    case ConsoleKey.D4:
                        clienteAtual = f3.desenfileirar();
                        Console.WriteLine("\n\n\t\t==== O cliente {0} ====\n - Pegou recebeu o pedido !!", clienteAtual);
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("\n\nSaindo....");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n\t\tOpção inválida, digite novamente uma opção descrita no menu.");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine("\n\n\tPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opc.Key!=ConsoleKey.D5);

        }
        static void Main(string[] args)
        {
            Restaurante restaurante = new Restaurante();
            restaurante.Menu();
            Console.ReadKey();
        }
    }
}
