// Exercício 2 — Pessoa (get e set básicos)

class Pessoa
{
    // Primeira versão (todas com get e set públicos):
    // public string Nome { get; set; } = "";

    // Segunda versão: Nome com private set.
    // Agora só a própria classe pode alterar o nome; por isso foi criado
    // um construtor para defini-lo na criação do objeto.
    public string Nome { get; private set; }
    public int Idade { get; set; }
    public string Email { get; set; } = "";

    public Pessoa(string nome)
    {
        Nome = nome; // permitido: estamos dentro da classe
    }
}

class Program
{
    static void Main()
    {
        // 1. cria uma pessoa (e 2. atribui os três valores)
        Pessoa pessoa = new Pessoa("Ana");
        pessoa.Idade = 25;
        pessoa.Email = "ana@email.com";

        // 3. exibe os três valores
        Console.WriteLine($"Nome: {pessoa.Nome}");
        Console.WriteLine($"Idade: {pessoa.Idade}");
        Console.WriteLine($"Email: {pessoa.Email}");

        // 4. altera a idade
        pessoa.Idade = 26;

        // 5. exibe novamente
        Console.WriteLine();
        Console.WriteLine($"Nome: {pessoa.Nome}");
        Console.WriteLine($"Idade: {pessoa.Idade}");
        Console.WriteLine($"Email: {pessoa.Email}");

        // Com private set, a linha abaixo NÃO compila:
        // pessoa.Nome = "Beatriz";
        // erro CS0272: The property or indexer 'Pessoa.Nome' cannot be used
        // in this context because the set accessor is inaccessible
    }
}
