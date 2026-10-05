// Desafio — Controle de estoque

class Produto
{
    private string nome = "";
    private string codigo = "";
    private decimal preco;

    public string Nome
    {
        get { return nome; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O nome é obrigatório.");
            }

            nome = value;
        }
    }

    public string Codigo
    {
        get { return codigo; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O código é obrigatório.");
            }

            codigo = value;
        }
    }

    public decimal Preco
    {
        get { return preco; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("O preço não pode ser negativo.");
            }

            preco = value;
        }
    }

    // Só muda pelos métodos AdicionarEstoque e RemoverEstoque.
    public int QuantidadeEstoque { get; private set; }

    // Calculada: true quando houver 5 unidades ou menos.
    public bool EstoqueBaixo
    {
        get { return QuantidadeEstoque <= 5; }
    }

    public Produto(string nome, string codigo, decimal preco)
    {
        // Atribuir pelas propriedades reaproveita as validações dos setters.
        Nome = nome;
        Codigo = codigo;
        Preco = preco;
    }

    public void AdicionarEstoque(int quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentException("A quantidade deve ser maior que zero.");
        }

        QuantidadeEstoque += quantidade;
    }

    public void RemoverEstoque(int quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentException("A quantidade deve ser maior que zero.");
        }

        if (quantidade > QuantidadeEstoque)
        {
            throw new InvalidOperationException("Estoque insuficiente.");
        }

        QuantidadeEstoque -= quantidade;
    }
}

class Program
{
    static void Main()
    {
        Produto produto = new Produto("Mouse", "MS-001", 89.90m);

        produto.AdicionarEstoque(20);
        Console.WriteLine(produto.QuantidadeEstoque); // 20

        produto.RemoverEstoque(10);
        Console.WriteLine(produto.QuantidadeEstoque); // 10

        Console.WriteLine(produto.EstoqueBaixo); // False

        try
        {
            produto.RemoverEstoque(50);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        produto.RemoverEstoque(6);
        Console.WriteLine(produto.QuantidadeEstoque); // 4
        Console.WriteLine(produto.EstoqueBaixo); // True

        // Tentativa de modificação direta — NÃO compila:
        // produto.QuantidadeEstoque = 500;
        // erro CS0272: the set accessor is inaccessible

        // Por que QuantidadeEstoque deve possuir private set em vez de set público?
        // Porque a quantidade em estoque só pode mudar por movimentações reais
        // (entradas e saídas), e são os métodos AdicionarEstoque e RemoverEstoque
        // que garantem as regras: nada de quantidade negativa e nada de remover
        // mais do que existe. Com set público, qualquer parte do programa poderia
        // escrever um valor arbitrário (500, -3...), ignorando essas regras e
        // deixando o estoque inconsistente. O private set mantém a leitura
        // livre, mas concentra a escrita dentro da classe.
    }
}
