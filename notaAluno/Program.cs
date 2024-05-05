
using System;
using notaAluno;

internal class Program
{
    private static void Main(string[] args)
    {
        int opc;
        PilhaAluno pilha = new PilhaAluno();
        FilaNota fila = new FilaNota();
        do
        {
            Console.Clear();
            Console.WriteLine("1 - Cadastrar Aluno");
            Console.WriteLine("2 - Cadastrar Nota");
            Console.WriteLine("3 - Cadastrar Média");
            Console.WriteLine("4 - Listar Alunos sem Nota");
            Console.WriteLine("5 - Excluir Aluno");
            Console.WriteLine("6 - Excluir Nota");
            Console.WriteLine("7 - Sair");
            opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    pilha.push(cadastrarAluno());
                    break;
                case 2:
                    int matricula = -1;
                    Console.WriteLine(pilha.print());
                    while (matricula < 0 || matricula > pilha.getContador())
                    {
                        Console.WriteLine("Informe a matrícula do aluno ou digite 0 para voltar:");
                        matricula = int.Parse(Console.ReadLine());
                        if (matricula > pilha.getContador())
                        {
                            Console.WriteLine("Aluno não cadastrado!");
                        }
                    }
                    if (matricula > 0)
                    {
                        fila.push(cadastrarNota(pilha, matricula));
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    Console.WriteLine(pilha.print());
                    cadastrarMedia(fila, pilha);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 4:
                    listarAlunosSemNota(fila, pilha);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 5:
                    excluirAluno(fila, pilha);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 6:
                    excluirNota(fila);
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 7:
                    Console.WriteLine("Saindo do Programa");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (opc != 7);
    }
    static Aluno cadastrarAluno()
    {
        Console.WriteLine("Informe o nome do aluno:");
        Aluno temp = new Aluno(Console.ReadLine());
        return temp;
    }
    static Nota cadastrarNota(PilhaAluno pilha, int matricula)
    {
        float nota = -1;
        while (nota < 0 || nota > 10)
        {
            Console.WriteLine("Informe a nota do aluno:");
            nota = float.Parse(Console.ReadLine());
        }

        Nota temp = new Nota(matricula, nota);
        return temp;
    }
    static void cadastrarMedia(FilaNota fila, PilhaAluno pilha)
    {
        int matricula;
        int nromatriculas = pilha.getContador();

        Console.WriteLine("Informe a matrícula do aluno que deseja cadastrar a média.");
        matricula = int.Parse(Console.ReadLine());
        if (matricula > nromatriculas)
        {
            Console.WriteLine("Aluno não cadastrado!");
        }
        else
        {
            Console.WriteLine("A média do aluno é: " + fila.getMedia(matricula));
        }
    }
    static void listarAlunosSemNota(FilaNota fila, PilhaAluno pilha)
    {
        int numeroAlunos = pilha.getContador();
        int numeroNotas = fila.getContador();
        int aluno;
        bool possuiNota;

        Console.WriteLine("Matrículas que não possuem notas cadastradas:");
        for (int i = 0; i < numeroAlunos; i++)
        {
            possuiNota = false;
            aluno = pilha.getMatriculas(i);
            for (int j = 0; j < numeroNotas && !possuiNota; j++)
            {
                if (aluno == fila.getNotasMatriculas(j))
                {
                    possuiNota = true;
                }
            }
            if (!possuiNota)
            {
                Console.WriteLine(pilha.getNomeMatriculas(aluno));
            }
        }
    }
    static void excluirNota(FilaNota fila)
    {
        int opc = 0, contador = 0;
        contador = fila.getContador();
        if (contador == 0)
        {
            Console.WriteLine("Não há notas para serem excluídas.");
        }
        else
        {
            Console.WriteLine("Notas cadastradas:");
            Console.WriteLine(fila.print());
            Console.WriteLine("Deseja excluir a primeira nota da fila? Digite 1 para sim.");
            opc = int.Parse(Console.ReadLine());
            if (opc == 1)
            {
                fila.pop();
            }
        }
    }
    static void excluirAluno(FilaNota fila, PilhaAluno pilha)
    {
        int opc = 0;
        int topo = 0;
        int numeroAlunos = pilha.getContador();
        int[] notas = new int[numeroAlunos];
        int[] alunos = new int[numeroAlunos];
        bool insere;

        topo = pilha.getContador();
        if (topo == 0)
        {
            Console.WriteLine("Não há alunos para serem excluídos.");
        }
        else
        {
            Console.WriteLine("Alunos cadastrados:");
            Console.WriteLine(pilha.print());
            Console.WriteLine("Deseja excluir o aluino do topo da pilha? Digite 1 para sim.");
            opc = int.Parse(Console.ReadLine());
            if (opc == 1)
            {
                if (!fila.possuiNotas(topo))
                {
                    pilha.pop();
                }
                else
                {
                    Console.WriteLine("Atenção:");
                    Console.WriteLine(pilha.getNomeMatriculas(topo));
                    Console.WriteLine("Possui notas e não pode ser excluído.");
                }
            }
        }
    }
}
