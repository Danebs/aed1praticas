using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposAbstratosDeDados
{
    class TestaLista
    {


        public void Menu()
        {
            int opc;
            Lista l = new Lista();

            do
            {
                Console.WriteLine("----------Menu----------");
                Console.WriteLine("1     -       INSERIR");
                Console.WriteLine("2     -       PESQUISAR");
                Console.WriteLine("3     -       IMPRIMIR LISTA");
                Console.WriteLine("4     -       REMOVER        ");
                Console.WriteLine("5     -       SAIR");
                Console.Write("Opção:");
                opc = Convert.ToInt32(Console.ReadLine());
                int c;
                string nome;

                switch (opc)
                {
                    case 1:

                        Console.Write("Digite um nº (-1 para sair): ");
                        c = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite um nome:");
                        nome = Console.ReadLine();

                        while (c != -1)
                        {
                            while(l.pesquisar(c) != null)
                            {
                                Console.WriteLine("Erro o valor inserido já existe na lista !!");
                                Console.Write("Digite outro nº (-1 para sair): ");
                                 c = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Digite um nome:");
                                nome = Console.ReadLine();

                            }
                          
                           
                            l.inserir(new NoLista(c, nome));
                            Console.Write("Digite outro nº (-1 para sair): ");
                            c = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Digite um nome:");
                            nome = Console.ReadLine();
                        }
                        break;

                    case 2:
                        Console.Write("Digite um nº a ser pesquisado: ");
                        c = Convert.ToInt32(Console.ReadLine());

                        NoLista n = l.pesquisar(c);
                        if (n == null)
                            Console.WriteLine("Valor não encontrado!");
                        else
                            Console.WriteLine("Achou: Chave: {0} nome: {1} " ,n.chave, n.nome);
                        break;
                    case 3:
                        l.imprimir();
                        break;

                    case 4:
                        Console.WriteLine("Digite um número para remover da Lista:");
                        c = Convert.ToInt32(Console.ReadLine());
                        if(l.remover(c))
                        {
                            Console.WriteLine("Item removido com sucesso !!");
                        }
                        else
                        {
                            Console.WriteLine("Item não encontrado !!");
                        }
                        
                        break;
                    case 5:
                        Console.WriteLine("Saindo...");
                        
                        break;
                    default:
                        l.TrocarChaves();
                        Console.WriteLine("Opção Inválida, digite novamente selecionando uma das opções do menu.");
                        break;

                }

            } while (opc != 5);
        }

        //--- Método Main

        static void Main(string[] args)
        {
            TestaLista t = new TestaLista();
            
            t.Menu();











            Console.ReadKey();
        }
    }
}