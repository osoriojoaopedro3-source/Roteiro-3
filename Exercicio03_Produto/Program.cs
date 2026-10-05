// Exercício 3 — Validação com setter

class Produto
{
    private decimal preco;
    private string nome = "Sem nome";

    public decimal Preco
    {
        get { return preco; }
        set
        {
            // value é o valor que está sendo atribuído: produto.Preco = value;
            if (value < 0)
            {
                throw new ArgumentException("O preço não pode ser negativo.");
            }

            preco = value;
        }
    }

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
}

class Program
{
    static void Main()
    {
        Produto produto = new Produto();

        try
        {
            produto.Preco = 100;
            Console.WriteLine($"Preço: {produto.Preco}");

            produto.Preco = 250;
            Console.WriteLine($"Preço: {produto.Preco}");

            produto.Preco = -50; // lança ArgumentException
            Console.WriteLine($"Preço: {produto.Preco}"); // não é executada
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        Console.WriteLine($"Preço mantido: {produto.Preco}"); // continua 250

        try
        {
            produto.Nome = "Teclado";
            Console.WriteLine($"Nome: {produto.Nome}");

            produto.Nome = ""; // lança ArgumentException
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        Console.WriteLine($"Nome mantido: {produto.Nome}"); // continua Teclado
    }
}
