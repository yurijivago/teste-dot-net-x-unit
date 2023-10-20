

using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes: IDisposable
    {
        private Veiculo veiculo;
        private Operador operador;
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            this.veiculo = new Veiculo();

            this.operador = new Operador();
            operador.Nome = "Godofredo";
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();

            estacionamento.OperadorPatio = operador;
            
            veiculo.Proprietario = "Zé Carioca";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ABC-1234";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Antônio", "AAA-1111", "Azul", "Argo")]
        [InlineData("Gabriel", "GGG-8888", "Branco", "Gol")]
        [InlineData("Pedro", "PPP-3333", "Preto", "Prisma")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();

            estacionamento.OperadorPatio = operador;

            veiculo.Proprietario = proprietario;
            veiculo.Placa = "ABC-1234";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Antônio", "AAA-1111", "Azul", "Argo")]
        public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();

            estacionamento.OperadorPatio = operador;

            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisarVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("### Ticket Estacionamento Alura ###", veiculo.Ticket);

        }

        [Fact]
        public void AlterarDadosDoVeiculoDoProprioVeiculo()
        {
            //Arrange
            Patio estacionamento = new Patio();

            estacionamento.OperadorPatio = operador;

            veiculo.Proprietario = "Zé Carioca";
            veiculo.Placa = "ABC-1234";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Fusca";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Zé Carioca";
            veiculoAlterado.Placa = "ABC-1234";
            veiculoAlterado.Cor = "Azul"; //valor alterado
            veiculoAlterado.Modelo = "Fusca";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosDoVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(veiculoAlterado.Cor, alterado.Cor);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
