using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposAbstratosDeDados
{
    class NoLista
    {
        public int chave;
        public string nome;
        public NoLista prox;
        public NoLista(int c, string n)
        {
            chave = c;
            prox = null;
            nome = n;

        }
    }

    class Lista
    {
        private NoLista prim, ult;

        public Lista()
        {
            prim = ult = null;
        }

        public void inserir(NoLista item)
        {
            if (prim == null)
            {
                prim = item;
            }
            else
                ult.prox = item;
            ult = item;
        }

        public void imprimir()
        {
            NoLista aux = prim;
            while (aux != null)
            {
                Console.WriteLine("chave: {0} nome : {1}", aux.chave, aux.nome);
                aux = aux.prox;
            }
        }

        public NoLista pesquisar(int c)
        {
            NoLista aux = prim;
            while (aux != null && aux.chave != c)
            {
                aux = aux.prox;
            }
            return aux;
        }

        public bool remover(int c)
        {
            NoLista aux = prim, ant = null;
            while (aux != null && aux.chave != c)
            {
                ant = aux;
                aux = aux.prox;
            }
            if (aux != null)
            {
                if (ant != null) // não é o primeiro 
                    ant.prox = aux.prox;
                else // é o primeiro
                    prim = aux.prox;
                if (aux == ult) // é o último
                    ult = ant;
                aux.prox = null; // desconecta o nó da lista
                return true;
            }
            return false;
        }


        public int ContadorFila()
        {
            int cont = 0;

            NoLista aux = prim;
            while (aux != null)
            {
                aux = aux.prox;
                cont++;
            }
            return cont;
        }

        public NoLista GetNo(int indice)
        {
            int cont = 0;
            NoLista aux = prim;
            while (aux != null)
            {
                if (cont == indice)
                {
                    return aux;
                }
                aux = aux.prox;
                cont++;
            }

            return null;
        }


        public void TrocarChaves()
        {
            NoLista aux = prim;
            prim = ult;
            prim.prox = aux.prox;
            ult = aux;
            ult.prox = null;

        }

        public void RetirarPrefixo(int n)
        {
            int cont = 0;
            NoLista aux = prim ;
            while(aux !=null && cont < n)
            {
                prim = aux.prox;
                aux.prox = null;
                cont++;

            }

        }




    }












}

