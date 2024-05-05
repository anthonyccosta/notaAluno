using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace notaAluno
{
    internal class PilhaAluno
    {
        Aluno topo;
        int matricula = 0;
        public PilhaAluno()
        {
            this.topo = null;
        }
        bool vazia()
        {
            if (topo == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void push(Aluno aux)
        {
            if (vazia() == true)
            {
                topo = aux;
            }
            else
            {
                aux.setAnterior(topo);
                topo = aux;
            }
            matricula++;
            aux.setNumero(matricula);
        }
        public void pop()
        {
            if (!vazia())
            {
                topo = topo.getAnterior();
                matricula--;
            }
        }
        public string print()
        {
            Aluno aux = topo;
            string texto = "";
            if (aux != null)
            {
                do
                {
                    texto += $"{aux.ToString()}\n";
                    aux = aux.getAnterior();
                } while (aux != null);
            }
            else
            {
                texto = "Não existem alunos cadastrados no sistema.";
            }

            return texto;
        }
        public int getContador()
        {
            int contador = 0;
            Aluno aux = topo;
            if (!vazia())
            {
                do
                {
                    contador++;
                    aux = aux.getAnterior();
                } while (aux != null);
            }
            return contador;
        }
        public int getMatriculas(int posicao)
        {
            int contador = 0, matricula = 0;
            Aluno aux = topo;
            if (!vazia())
            {
                matricula = aux.getMatricula();
                do
                {
                    contador++;
                    aux = aux.getAnterior();
                    if (aux != null && posicao > 0)
                    {
                        matricula = aux.getMatricula();
                    }
                } while (aux != null && contador < posicao);
            }
            return matricula;
        }
        public string getNomeMatriculas(int matricula)
        {
            Aluno aux = topo;
            string texto = "";
            if (!vazia())
            {
                do
                {
                    if (aux != null)
                    {
                        if (aux.getMatricula() == matricula)
                        {
                            texto = "Matrícula...: [ " + aux.getMatricula() + " ] Aluno...: " + aux.getNome() + "\n";
                        }
                    }
                    aux = aux.getAnterior();
                } while (aux != null);
            }
            return texto;
        }
    }
}