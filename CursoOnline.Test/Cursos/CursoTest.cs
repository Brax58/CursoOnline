using CursoOnline.Test.Util;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.Test.Cursos
{
    public class CursoTest
    {
        private Curso curso;

        public CursoTest()
        {
            curso = new Curso("Informática", 80, PublicoAlvo.Estudante, 950.50);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CursoNaoDeveTerNomeVazioOuNulo(string nome)
        {

            //Arrange
            curso.AlterarNomeCurso(nome);

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => curso.Validar())
                .ExecaoComMensagem("Nome Invalido!");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void CargaHorariaNaoPodeSerMenorQueUm(int cargaHoraria)
        {

            //Arrange
            curso.AlterarCargaHorariaCurso(cargaHoraria);

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => curso.Validar())
                .ExecaoComMensagem("Carga horaria invalida!");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void ValorNaoPodeSerMenorQueUm(int valor)
        {

            //Arrange
            curso.AlterarValorCurso(valor);

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => curso.Validar())
                .ExecaoComMensagem("Valor invalido!");
        }
    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }

    public class Curso
    {
        public string Nome { get; private set; }
        public int CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

        public Curso(string nome, int cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
        }
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                throw new ArgumentException("Nome Invalido!");
            }

            if (CargaHoraria <= 0)
            {
                throw new ArgumentException("Carga horaria invalida!");
            }

            if (Valor <= 0)
            {
                throw new ArgumentException("Valor invalido!");
            }

            return true;
        }

        public void AlterarNomeCurso(string nome)
        {
            Nome = nome;
        }

        public void AlterarCargaHorariaCurso(int cargaHoraria)
        {
            CargaHoraria = cargaHoraria;
        }
        public void AlterarPublicoAlvoCurso(PublicoAlvo publicoAlvo)
        {
            PublicoAlvo = publicoAlvo;
        }
        public void AlterarValorCurso(double valor)
        {
            Valor = valor;
        }
    }
}
