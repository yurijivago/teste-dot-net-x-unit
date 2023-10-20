using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes: IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            this.veiculo = new Veiculo();
        }



        /*
             Método AAA para testes:
              -> Arrange: preparação do ambiente, do cenário para incovcar o método testado
              -> Act: o método testado
              -> Assert: verificação do resultado obtido da execução do método
        */

        [Fact]
        public void TestaVeiculoAceleraromParametro10()
        {
            //Arrange
            //veiculo instanciado no construtor

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //veiculo instanciado no construtor

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            //veiculo instanciado no construtor
            veiculo.Proprietario = "Zé Carioca";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ABC-1234";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Fusca";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDe3Caracteres()
        {
            //Arrange
            string proprietario = "Ab";

            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo(proprietario)
            );
        }

        [Fact]
        public void TestarMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "AAA 1234";


            //Act
            var mensagemRetorno = Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo().Placa = placa
            );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagemRetorno.Message);
        }

        [Fact]
        public void TestaUltimosCaracteresPlacaVeiculoComoNumeros()
        {
            //Arrange
            string placa = "AAA-123Y";


            //Act
            var mensagemRetorno = Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo().Placa = placa
            );

            //Assert
            Assert.Equal("Do 5º ao 8º caractere deve-se ter um número!", mensagemRetorno.Message);
        }



        [Fact(Skip = "Teste ignorado para exemplificar como ignorar um método de testes quando necessário")]
        public void ValidaNomeProprietarioDoVeiculo()
        {
            //método de teste para exemplificar um teste ignorado
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
