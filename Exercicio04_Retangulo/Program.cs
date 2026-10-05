// Exercício 4 — Propriedade calculada

class Retangulo
{
    public double Largura { get; set; }
    public double Altura { get; set; }

    // Somente leitura e calculada: não guarda valor, recalcula a cada leitura.
    public double Area
    {
        get { return Largura * Altura; }
    }
}

class Program
{
    static void Main()
    {
        Retangulo retangulo = new Retangulo();
        retangulo.Largura = 10;
        retangulo.Altura = 5;

        Console.WriteLine(retangulo.Area); // 50

        retangulo.Largura = 20;

        // A área mudou sem que Area fosse alterada diretamente.
        Console.WriteLine(retangulo.Area); // 100

        // retangulo.Area = 300; // ERRO CS0200: Area é somente leitura
    }
}
