using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notaAluno
{
    internal class Nota
    {
        int matricula;
        float nota;
        Nota proximo;
        public Nota(int matricula, float nota)
        {
            this.nota = nota;
            this.matricula = matricula;
        }
        public void setNota(int matricula, float nota)
        {
            this.nota = nota;
            this.matricula = matricula;
        }
        public int getMatricula()
        {
            return this.matricula;
        }
        public float getNota(int matricula)
        {
            return this.nota;
        }
        public void setProximo(Nota aux)
        {
            this.proximo = aux;
        }
        public Nota getProximo()
        {
            return this.proximo;
        }
        public override string? ToString()
        {
            return "Matricula: " + matricula + " Nota: " + nota;
        }
    }
}