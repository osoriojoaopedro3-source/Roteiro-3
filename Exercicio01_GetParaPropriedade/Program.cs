// Exercício 1 — Transformando Get em propriedade

class ContaBancaria
{
    private decimal saldo;

    // ANTES:
    // public decimal GetSaldo()
    // {
    //     return saldo;
    // }

    // DEPOIS: a propriedade Saldo possui apenas o get.
    //
    // Por que Saldo deve ser somente leitura para o código externo?
    // O saldo só pode mudar como consequência de operações válidas
    // (depósitos e saques), que verificam as regras do sistema. Se o código
    // externo pudesse escrever "conta.Saldo = 1000", ele poderia criar
    // dinheiro do nada ou deixar o saldo negativo, sem passar por nenhuma
    // validação. Expor só a leitura mantém o encapsulamento: qualquer um
    // pode consultar o valor, mas apenas a própria classe decide como ele muda.
    public decimal Saldo
    {
        get { return saldo; }
    }

    // Método incluído apenas para que o saldo possa ter algum valor no teste.
    public void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            saldo += valor;
        }
    }
}

class Program
{
    static void Main()
    {
        ContaBancaria conta = new ContaBancaria();
        conta.Depositar(500);

        Console.WriteLine(conta.Saldo); // permitido: executa o get

        // conta.Saldo = 1000; // ERRO CS0200: a propriedade é somente leitura
    }
}
