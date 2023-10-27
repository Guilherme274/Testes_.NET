using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace alura_estacionamentoTestes
{
    public class VeiculoTestes
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;


        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        [Fact]
        //[Trait("Funcionalidade", "Acelerar")] // Feito para mostrar no gerenciador de testes o que você está testando
        public void TestaVeiculoAcelerarComParametro10()
        {

            //Arrange - Preparo
            var veiculo = new Veiculo();

            //Act - Método de Teste
            veiculo.Acelerar(10);
            
            //Assert - Resultado Esperado
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        //[Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrearComParametro10()
        {

            var veiculo = new Veiculo();

            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            //var carro = new Veiculo();
            veiculo.Proprietario = "Carlos Silva";
            veiculo.Placa = "ZAP-7419";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Tipo do Veículo: Automovel", dados);
        }

        [Fact]
        public void TesteNomeProprietariosComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";

            //Assert
            Assert.Throws<System.FormatException>( 
                //Act
                () =>  new Veiculo(nomeProprietario));
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaracterDaPlaca()
        {
            //Arrange
            string placa = "ASDF9999";


            //Act
             var mensagem = Assert.Throws<System.FormatException>( 
                
                () =>  new Veiculo().Placa = placa);

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }
    }
}