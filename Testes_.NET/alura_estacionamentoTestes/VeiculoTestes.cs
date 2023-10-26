using Alura.Estacionamento.Modelos; 

namespace alura_estacionamentoTestes
{
    public class VeiculoTestes
    {
        [Fact(DisplayName ="Teste 1")]
        [Trait("Funcionalidade", "Acelerar")] // Feito para mostrar no gerenciador de testes o que você está testando
        public void TestaVeiculoAcelerar()
        {

            //Arrange - Preparo
            var veiculo = new Veiculo();

            //Act - Método de Teste
            veiculo.Acelerar(10);
            
            //Assert - Resultado Esperado
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName ="Teste 2")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {

            var veiculo = new Veiculo();

            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        
    }
}