using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pratica6
{
    public class Aluno
    {
        public string matricula;
        public string nome;
        public string[] disciplinas = null;
    }

    class Init
    {
        [STAThread]
        static void Main(string[] args)
        {
            bool active = true;
            string line;

            Arvore arvore = new Arvore();

       
            OpenFileDialog theDialog = new OpenFileDialog();

            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = Directory.GetCurrentDirectory();

            while (active) {
                Console.Clear();
                Console.WriteLine("\n\n1 - Informar arquivo" +
                    "\n2 - Imprimir disciplinas em ordem crescente" +
                    "\n3 - Imprimir disciplinas em 'pré-ordem'" +
                    "\n4 - Imprimir disciplinas em 'pós - ordem'"+
                    "\n5 - Listar Turma" +
                    "\n6 - Sair");

                Console.Write("Digite a tecla correspondente a opção desejada: ");
                switch(Console.ReadKey().Key) {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        if (theDialog.ShowDialog() == DialogResult.OK)
                        {
                            string[] materias = null;
                            List<Aluno> alunos = new List<Aluno>();
                            StreamReader file = new StreamReader(theDialog.FileName.ToString());

                            while ((line = file.ReadLine()) != null)
                            {
                                string[] linhas = line.Split(';');
                                Aluno aluno = new Aluno();
                                aluno.matricula = linhas[0];
                                aluno.nome = linhas[1];
                             
                                var lista = linhas.ToList<string>();
                                lista.RemoveRange(0, 2);
                                materias = lista.ToArray();
                                materias = OrdernaMaterias(materias);
                                aluno.disciplinas = materias;
                            }

                            materias = OrdernaMaterias(materias);
                            arvore.inserir(materias[0]);

                            for (int i = 0; i <  materias.Length; i++)
                            {
                                arvore.inserir(materias[i]);
                                arvore.raiz.alunos = alunos;
                                foreach (Aluno aluno in alunos)
                                {
                                    foreach(string disciplina in aluno.disciplinas)
                                    {
                                        if (disciplina == materias[i])
                                        {
                                            arvore.raiz.alunos.Add(aluno);
                                        }
                                    }
                                }
                            }


                        }

                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        foreach (Aluno aluno in arvore.raiz.alunos)
                        {
                            Console.WriteLine(aluno.nome);
                        }

                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("fafa");
                        break;
                }

        }
            Console.ReadLine();
        }


        static string[] OrdernaMaterias(string[] materias)
        {
            StringComparer comparador = StringComparer.OrdinalIgnoreCase;
            Array.Sort(materias, comparador);
  
            return materias;
        }
        
    }
}
