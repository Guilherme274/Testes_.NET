using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace alura_estacionamentoTestes
{
    public class PatioTestes
    {

        [Fact]
        public void ValidaFaturamento()
        {

            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Guilherme P";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);


        }

        [Theory] // Permite trabalhar com uma quantidade maior de Dados
        [InlineData("André Silva", "ASD-1498", "preto", "Gol")] // Usado para validar vários valores de uma vez
        [InlineData("Jose Silva", "POL-9242", "Cinza", "Fusca")]
        [InlineData("Maria Silva", "GDR-6524", "Azul", "Opala")]

        public void ValidaFaturamentoComVariosVeiculo(string proprietario, string placa, string cor, string modelo)
        {

            //Arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);


            //Act
            double faturamento = estacionamento.TotalFaturado();


            //Assert

            Assert.Equal(2, faturamento);
        }

        [Fact(Skip = "Teste não implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {

        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
        public void LocalizaVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
        {

            //Arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlterarDadosVeiculo()
        {
            //Arrange

            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Guilherme";
            veiculo.Placa = "ZXC-8523";
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Gol";
            estacionamento.RegistrarEntradaVeiculo(veiculo);


            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Guilherme";
            veiculoAlterado.Placa = "ZXC-8523";
            veiculoAlterado.Cor = "Roxo"; //Alteração do valor
            veiculoAlterado.Modelo = "Gol";

            //Act 
            Veiculo alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

            //Assert
        }
    }
}
