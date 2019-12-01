using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pratica6;


namespace Pratica6
{
    class Arvore
    {
        public NoArvore raiz = null;

        public void inserir(string chave)
        {
            if (raiz == null)
            {
                raiz = new NoArvore(chave);
            }
            else
            {
                raiz.inserir(chave);
            }
        }

        public void emOrdem(NoArvore x)
        {
            if (x != null)
            {
                emOrdem(x.esq);
                Console.Write(x.chave + " ");
                emOrdem(x.dir);
            }
        }

        public void preOrdem(NoArvore x)
        {
            if (x != null)
            {
                Console.Write(x.chave + " ");
                preOrdem(x.esq);
                preOrdem(x.dir);
            }
        }

        public void posOrdem(NoArvore x)
        {
            if (x != null)
            {
                posOrdem(x.esq);
                posOrdem(x.dir);
                Console.Write(x.chave + " ");
            }
        }

        public NoArvore pesquisar(string c, NoArvore x)
        {
            if (x == null || x.chave == c)
                return x;
            else if (String.Compare(c, x.chave) < 0)
                return pesquisar(c, x.esq);
            else
                return pesquisar(c, x.dir);

        }
    }

    public class NoArvore
    {
        public string chave;
        public NoArvore esq, dir;
        public List<Aluno> alunos;

        public NoArvore(string c)
        {
            chave = c;
            esq = dir = null;
            alunos = new List<Aluno>();
        }

        internal List<Aluno> Alunos { get => alunos; set => alunos = value; }

        public void inserir(string c)
        {
            if (String.Compare(c, chave) < 0)
            {
                if (esq == null)
                    esq = new NoArvore(c);
                else
                    esq.inserir(c);
            }
            else if (String.Compare(c, chave) > 0)
            {
                if (dir == null)
                    dir = new NoArvore(c);
                else
                    dir.inserir(c);
            }
            else
                Console.Write("\nChave duplicada. Impossível inserir! {0}", chave );
        } // fim do metodo inserir
    }
}

