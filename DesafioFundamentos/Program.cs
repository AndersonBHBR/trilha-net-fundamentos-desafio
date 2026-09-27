using System.Globalization;
using DesafioFundamentos.Models;

// Usa o padrão brasileiro para ler preços e exibir valores monetários.
Console.OutputEncoding = System.Text.Encoding.UTF8;
CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!");
if (!LerPreco("Digite o preço inicial (ex.: 5,00):", out decimal precoInicial)
    || !LerPreco("Agora digite o preço por hora (ex.: 2,50):", out decimal precoPorHora))
{
    Console.WriteLine("O programa se encerrou");
    return;
}

Estacionamento es = new Estacionamento(precoInicial, precoPorHora);
bool exibirMenu = true;

while (exibirMenu)
{
    Console.WriteLine("\nDigite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine()?.Trim())
    {
        case "1":
            es.AdicionarVeiculo();
            break;
        case "2":
            es.RemoverVeiculo();
            break;
        case "3":
            es.ListarVeiculos();
            break;
        case "4":
        case null: // Encerra também quando a entrada do console termina.
            exibirMenu = false;
            break;
        default:
            Console.WriteLine("Opção inválida. Escolha uma opção de 1 a 4.");
            break;
    }
}

Console.WriteLine("O programa se encerrou");

static bool LerPreco(string mensagem, out decimal preco)
{
    preco = 0;
    while (true)
    {
        Console.WriteLine(mensagem);
        string entrada = Console.ReadLine();
        if (entrada == null)
            return false;

        // Não aceita separador de milhar para evitar interpretar 2.50 como 250.
        if (decimal.TryParse(entrada, NumberStyles.AllowLeadingWhite
            | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign
            | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out preco)
            && preco >= 0)
        {
            return true;
        }

        Console.WriteLine("Preço inválido. Digite um número não negativo, usando vírgula para os centavos.");
    }
}
