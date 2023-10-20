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
             M�todo AAA para testes:
              -> Arrange: prepara��o do ambiente, do cen�rio para incovcar o m�todo testado
              -> Act: o m�todo testado
              -> Assert: verifica��o do resultado obtido da execu��o do m�todo
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
            veiculo.Proprietario = "Z� Carioca";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ABC-1234";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Fusca";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Ve�culo", dados);
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
            Assert.Equal("O 4� caractere deve ser um h�fen", mensagemRetorno.Message);
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
            Assert.Equal("Do 5� ao 8� caractere deve-se ter um n�mero!", mensagemRetorno.Message);
        }



        [Fact(Skip = "Teste ignorado para exemplificar como ignorar um m�todo de testes quando necess�rio")]
        public void ValidaNomeProprietarioDoVeiculo()
        {
            //m�todo de teste para exemplificar um teste ignorado
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
