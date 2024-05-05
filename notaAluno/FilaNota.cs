using notaAluno;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace notaAluno
{
    internal class FilaNota
    {
        Nota? inicio;
        Nota? fim;
        public FilaNota()
        {
            this.inicio = null;
            this.fim = null;
        }
        internal bool vazia()
        {
            return inicio == null && fim == null;
        }
        public void push(Nota aux)
        {
            int contador = 0;
            Nota aux2 = inicio;
            if (vazia())
            {
                this.inicio = this.fim = aux;
            }
            else
            {
                do
                {
                    if (aux2.getMatricula() == aux.getMatricula())
                    {
                        contador++;
                    }
                    aux2 = aux2.getProximo();
                } while (aux2 != null);
                if (contador == 2)
                {
                    Console.WriteLine("Não pode inserir mais de 2 notas.");
                }
                else
                {
                    this.fim.setProximo(aux);
                    this.fim = aux;
                }
            }
        }
        public void pop()
        {
            if (!vazia())
            {
                if (fim == inicio) 
                {
                    inicio = fim = null;
                }
                else
                {
                    this.inicio = this.inicio.getProximo();
                }
            }
        }
        public float getNotas(int matricula)
        {
            float nota1 = -1, nota2 = -1;
            Nota aux = inicio;
            do
            {
                if (aux.getMatricula() == matricula)
                {
                    if (nota1 < 0)
                    {
                        nota1 = aux.getNota(matricula);
                    }
                    else
                    {
                        nota2 = aux.getNota(matricula);
                    }
                }
                aux = aux.getProximo();
            } while (aux != null);
            if (nota1 < 0)
            {
                nota1 = 0;
            }
            return nota1;
        }
        public bool possuiNotas(int matricula)
        {
            bool resultado = false;
            Nota aux = inicio;
            do
            {
                if (aux != null)
                {

                    if (aux.getMatricula() == matricula)
                    {
                        resultado = true;
                    }
                    aux = aux.getProximo();
                }
            } while (aux != null);
            return resultado;
        }
        public float getMedia(int matricula)
        {
            float nota1 = -1, nota2 = -1;
            Nota aux = inicio;
            if (aux != null)
            {
                do
                {
                    if (aux.getMatricula() == matricula)
                    {
                        if (nota1 < 0)
                        {
                            nota1 = aux.getNota(matricula);
                        }
                        else
                        {
                            nota2 = aux.getNota(matricula);
                        }
                    }
                    aux = aux.getProximo();
                } while (aux != null);
            }
            else
            {
                Console.WriteLine("Não existem notas cadastradas no sistema.");
            }

            if (nota1 < 0)
            {
                nota1 = 0;
            }
            if (nota2 < 0)
            {
                nota2 = 0;
            }
            return (nota1 + nota2) / 2;
        }
        public int getNotasMatriculas(int posicao)
        {
            Nota aux = inicio;
            int contador = 0, matricula = 0;
            if (!vazia())
            {
                matricula = aux.getMatricula();
                do
                {
                    contador++;
                    aux = aux.getProximo();
                    if (aux != null && posicao > 0)
                    {
                        matricula = aux.getMatricula();
                    }
                } while (aux != null && contador < posicao);
            }
            return matricula;
        }
        public int getContador()
        {
            Nota aux = inicio;
            int contador = 0;
            if (!vazia())
            {
                do
                {
                    contador++;
                    aux = aux.getProximo();
                } while (aux != null);
            }
            return contador;
        }
        public string print()
        {
            Nota aux = inicio;
            string texto = "Inicio =>\n";
            if (aux != null)
            {
                do
                {
                    texto += $"{aux.ToString()}\n";
                    aux = aux.getProximo();
                } while (aux != null);
                texto += " <= Fim";
            }
            else
            {
                texto = "Não existem notas cadastradas no sistema.";
            }

            return texto;
        }
    }
}