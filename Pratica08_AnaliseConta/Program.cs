// Prática 8 — Análise de código: descubra o que está errado
//
// Código original:
//
// class Conta
// {
//     public decimal Saldo { get; set; }
//
//     public void Depositar(decimal valor)
//     {
//         Saldo += valor;
//     }
// }
//
// 1. Qual regra do sistema pode ser quebrada?
//    A regra de que o saldo só muda por operações válidas. Com set público,
//    qualquer código pode fazer conta.Saldo = -999999, deixando o saldo
//    negativo (ou inventando dinheiro) sem depósito, saque ou validação.
//    Além disso, Depositar aceitava valores negativos ou zero.
//
// 2. Como alterar a propriedade para impedir a alteração externa?
//    Trocando "set" por "private set":
//        public decimal Saldo { get; private set; }
//
// 3. Como o método Depositar() continuará conseguindo modificar o saldo?
//    O private set restringe a escrita ao código de dentro da própria classe.
//    Depositar() é um membro de Conta, então "Saldo += valor" continua válido.
//
// 4. Existe alguma situação em que get; set; público seria aceitável?
//    Sim, quando o dado não tem regra para proteger e qualquer valor é
//    aceitável — por exemplo, um apelido, uma observação, ou classes simples
//    que só transportam dados (DTOs, modelos de formulário, configurações).
//    Nesses casos não há invariante que o código externo possa quebrar.

class Conta
{
    public decimal Saldo { get; private set; }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O depósito deve ser maior que zero.");
        }

        Saldo += valor; // permitido: estamos dentro da classe
    }
}

class Program
{
    static void Main()
    {
        Conta conta = new Conta();
        conta.Depositar(300);
        Console.WriteLine(conta.Saldo); // 300

        // conta.Saldo = -999999; // agora NÃO compila (CS0272)
    }
}
