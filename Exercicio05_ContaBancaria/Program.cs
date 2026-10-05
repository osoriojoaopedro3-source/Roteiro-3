// Exercício 5 — Conta bancária completa

class ContaBancaria
{
    // Regra 1: definido apenas no construtor (sem set).
    public string Titular { get; }

    // Regras 2, 3 e 4: começa em zero, leitura pública, escrita privada.
    public decimal Saldo { get; private set; } = 0;

    public ContaBancaria(string titular)
    {
        if (string.IsNullOrWhiteSpace(titular))
        {
            throw new ArgumentException("O titular é obrigatório.");
        }

        Titular = titular;
    }

    // Regra 5
    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O depósito deve ser maior que zero.");
        }

        Saldo += valor;
    }

    // Regra 6
    public void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O saque deve ser maior que zero.");
        }

        if (valor > Saldo)
        {
            throw new InvalidOperationException("Saldo insuficiente.");
        }

        Saldo -= valor;
    }
}

class Program
{
    static void Main()
    {
        ContaBancaria conta = new ContaBancaria("Carlos");
        conta.Depositar(1000);
        conta.Sacar(250);
        Console.WriteLine(conta.Saldo); // 750

        try
        {
            conta.Sacar(5000);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        try
        {
            conta.Depositar(-10);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        // Tentativa deliberada — NÃO compila por causa do private set:
        // conta.Saldo = -5000;
        // erro CS0272: the set accessor is inaccessible
    }
}
