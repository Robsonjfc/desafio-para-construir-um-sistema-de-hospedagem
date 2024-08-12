using System.Text;
using dio_cruso_laboratorio.models;

namespace dio_cruso_laboratorio.models
{
    public class Pessoa
    {
        public string Nome { get; set; }

        public Pessoa(string nome)
        {
            Nome = nome;
        }
    }

    public class Suite
    {
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }
    }

    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite != null && Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentException("A quantidade de hóspedes não pode exceder a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor -= valor * 0.10m;
            }

            return valor;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Cria os modelos de hóspedes e cadastra na lista de hóspedes
            List<Pessoa> hospedes = new List<Pessoa>();

            Pessoa p1 = new Pessoa(nome: "Hóspede 1");
            Pessoa p2 = new Pessoa(nome: "Hóspede 2");

            hospedes.Add(p1);
            hospedes.Add(p2);

            // Cria a suíte
            Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

            // Cria uma nova reserva, passando a suíte e os hóspedes
            Reserva reserva = new Reserva(diasReservados: 5);
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);

            // Exibe a quantidade de hóspedes e o valor da diária
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
        }
    }
}