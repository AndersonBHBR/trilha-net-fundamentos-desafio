namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            if (precoInicial < 0)
                throw new ArgumentOutOfRangeException(nameof(precoInicial), "O preço não pode ser negativo.");
            if (precoPorHora < 0)
                throw new ArgumentOutOfRangeException(nameof(precoPorHora), "O preço não pode ser negativo.");

            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = LerPlaca();
            if (placa == null)
                return;

            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Esse veículo já está estacionado.");
                return;
            }

            veiculos.Add(placa);
            Console.WriteLine($"O veículo {placa} foi cadastrado com sucesso.");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = LerPlaca();
            if (placa == null)
                return;

            if (!veiculos.Contains(placa))
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
                return;
            }

            int horas;
            while (true)
            {
                Console.WriteLine("Digite a quantidade de horas inteiras que o veículo permaneceu estacionado:");
                string entrada = Console.ReadLine();
                if (entrada == null)
                    return;
                if (int.TryParse(entrada, out horas) && horas >= 0)
                    break;

                Console.WriteLine("Quantidade inválida. Digite um número inteiro não negativo.");
            }

            decimal valorTotal;
            try
            {
                // A taxa inicial é somada ao preço por hora multiplicado pelas horas.
                valorTotal = precoInicial + precoPorHora * horas;
            }
            catch (OverflowException)
            {
                Console.WriteLine("O valor calculado excede o limite permitido. O veículo permanece estacionado.");
                return;
            }

            veiculos.Remove(placa);
            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
        }

        public void ListarVeiculos()
        {
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            }

            Console.WriteLine("Os veículos estacionados são:");
            foreach (string placa in veiculos)
                Console.WriteLine(placa);
        }

        private static string LerPlaca()
        {
            string entrada = Console.ReadLine();
            if (entrada == null)
                return null;

            // Padroniza placas com letras minúsculas, espaços nas bordas e hífen.
            string placa = entrada.Trim().Replace("-", "").ToUpperInvariant();
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("A placa não pode ficar vazia.");
                return null;
            }

            return placa;
        }
    }
}
