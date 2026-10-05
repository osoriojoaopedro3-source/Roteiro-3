// Exercício 6 — Sistema de alunos

class Aluno
{
    private string nome = "";
    private decimal nota1;
    private decimal nota2;

    public string Nome
    {
        get { return nome; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O nome não pode ser vazio.");
            }

            nome = value;
        }
    }

    public decimal Nota1
    {
        get { return nota1; }
        set { nota1 = ValidarNota(value); }
    }

    public decimal Nota2
    {
        get { return nota2; }
        set { nota2 = ValidarNota(value); }
    }

    // Calculada e somente leitura.
    public decimal Media
    {
        get { return (Nota1 + Nota2) / 2; }
    }

    private static decimal ValidarNota(decimal nota)
    {
        if (nota < 0 || nota > 10)
        {
            throw new ArgumentException("A nota deve estar entre 0 e 10.");
        }

        return nota;
    }
}

class Program
{
    static void Main()
    {
        Aluno aluno = new Aluno();
        aluno.Nome = "Maria";
        aluno.Nota1 = 8;
        aluno.Nota2 = 6;
        Console.WriteLine(aluno.Media); // 7

        aluno.Nota2 = 10;
        Console.WriteLine(aluno.Media); // 9

        try
        {
            aluno.Nota1 = 11;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        try
        {
            aluno.Nome = "";
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        // aluno.Media = 10; // ERRO CS0200: Media é somente leitura
    }
}
