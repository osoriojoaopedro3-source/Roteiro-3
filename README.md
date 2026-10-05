# Roteiro 3 — Propriedades e Encapsulamento em C#

Cada exercício é um projeto de console independente (.NET 8). Para executar:

```bash
dotnet run --project Exercicio01_GetParaPropriedade
```

| Pasta | Exercício |
|---|---|
| `Exercicio01_GetParaPropriedade` | 18. Transformando `GetSaldo()` em propriedade |
| `Exercicio02_Pessoa` | 19. Propriedades automáticas e `private set` |
| `Exercicio03_Produto` | 20. Validação no setter (`Preco` e `Nome`) |
| `Exercicio04_Retangulo` | 21. Propriedade calculada (`Area`) |
| `Exercicio05_ContaBancaria` | 22. Conta bancária completa |
| `Exercicio06_Alunos` | 23. Sistema de alunos |
| `Desafio_ControleEstoque` | 24. Controle de estoque (com resposta sobre `private set`) |
| `Pratica08_AnaliseConta` | 25. Análise e correção da classe `Conta` (respostas nos comentários) |

As linhas que **não devem compilar** (ex.: `conta.Saldo = -5000;`) estão comentadas no código. Para observar o erro, basta descomentá-las.

## Prática 8 — Análise de código

1. **Qual regra pode ser quebrada?** A de que o saldo só muda por operações válidas. Com `set` público, `conta.Saldo = -999999` deixa o saldo negativo sem nenhuma validação.
2. **Como impedir a alteração externa?** Usando `public decimal Saldo { get; private set; }`.
3. **Como `Depositar()` continua modificando o saldo?** `private set` só bloqueia o código *fora* da classe. `Depositar()` é membro de `Conta`, então pode escrever `Saldo += valor`.
4. **`get; set;` público é aceitável?** Sim, quando não existe regra a proteger e qualquer valor é válido, como em classes que só transportam dados (DTOs, formulários, configurações) ou campos livres como um apelido.

## Prática 9 — Propriedade ou método?

| Item | Escolha | Justificativa |
|---|---|---|
| Nome de uma pessoa | Propriedade | É uma característica do objeto que se consulta e, eventualmente, se altera. |
| Saldo de uma conta | Propriedade (`private set`) | É um estado que se consulta, mas que só muda por operações da própria conta. |
| Depositar dinheiro | Método | É uma ação que recebe um valor, aplica regras e altera o estado. |
| Sacar dinheiro | Método | É uma ação com regras (saldo suficiente, valor positivo) que pode falhar. |
| Preço de um produto | Propriedade | É um dado do produto, que pode ter validação no `set`. |
| Calcular frete | Método | Depende de parâmetros externos (destino, peso) e pode ser um processamento custoso. |
| Altura de um retângulo | Propriedade | É uma característica simples do objeto. |
| Calcular área | Propriedade calculada (`Area`) | É um valor derivado, barato e sem parâmetros, então lê-se como um dado (`retangulo.Area`). Se o nome tiver verbo, como "Calcular", o natural seria um método `CalcularArea()`. |
| Ativar usuário | Método | É uma ação que muda o estado do objeto. |
| Usuário está ativo? | Propriedade (`bool Ativo { get; private set; }`) | É uma consulta ao estado atual, sem efeito colateral. |

## O que você precisa conseguir fazer

- **Encapsulamento × propriedades:** a propriedade é a "porta" controlada para um campo privado. O código externo usa sintaxe de campo, mas a classe mantém o controle por meio do `get`/`set`.
- **Quando o `get` executa:** sempre que a propriedade é *lida*, como em `Console.WriteLine(conta.Saldo)` ou `x = p.Idade`.
- **Quando o `set` executa:** sempre que a propriedade recebe uma *atribuição*, como em `produto.Preco = 100` (inclusive em `+=` e `-=`, que fazem `get` e depois `set`).
- **O que é `value`:** é o parâmetro implícito do `set`, que contém o valor do lado direito da atribuição.
- **Propriedade automática:** `public int Idade { get; set; }`, em que o compilador cria o campo privado.
- **Propriedade com validação:** campo privado + `set` que verifica `value` e lança `ArgumentException` (Exercício 3).
- **`private set`:** leitura pública e escrita só dentro da classe (Exercícios 2, 5 e Desafio).
- **Somente leitura:** só `get` (Exercício 1) ou `{ get; }` definida no construtor (`Titular`, Exercício 5).
- **Propriedade calculada:** `get` que retorna uma expressão, como `Area`, `Media` e `EstoqueBaixo`.
- **Propriedade × método:** propriedades representam dados/estado (substantivos), e métodos representam ações (verbos), principalmente quando recebem parâmetros, têm efeitos colaterais ou são custosos.
- **`GetSaldo()` → `Saldo`:** feito no Exercício 1.
