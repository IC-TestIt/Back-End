using System.Linq;
using Xunit;
using TestIt.CorrectionAlgorithms;
using System.Collections.Generic;

namespace TestIt.Tests
{
    public class CorrectionAlgorithmsTests
    {
        [Fact]
        public void CanSplitText1()
        {
            var originalText = "Essa é a primeira frase. Essa é a segunda! Mas voce já sabia? Eu acho que sim.";
            var sentences = Core.SeparateIntoSentences(originalText);

            Assert.Equal(new List<string>
            {
                "Essa é a primeira frase.",
                "Essa é a segunda!",
                "Mas voce já sabia?",
                "Eu acho que sim."
            }, sentences.ToList());
        }
        
        [Fact]
        public void CanSplitText2()
        {
            var originalText = "Essa é a primeira frase. Essa é a segunda! Mas voce já sabia? Eu acho que sim, Voce deve continuar, " +
                               "lendo. Até que acabe o espaço na pagina. Quando acabar, voce pode parar de ler.";

            var sentences = Core.SeparateIntoSentences(originalText).ToList();

            Assert.Equal(sentences[0], "Essa é a primeira frase.");
            Assert.Equal(sentences[1], "Essa é a segunda!");
            Assert.Equal(sentences[2], "Mas voce já sabia?");
            Assert.Equal(sentences[3], "Eu acho que sim, Voce deve continuar, lendo.");
            Assert.Equal(sentences[4], "Até que acabe o espaço na pagina.");
            Assert.Equal(sentences[5], "Quando acabar, voce pode parar de ler.");
        }

        [Fact]
        public void CanCalculateMinorDif()
        {
            Assert.Equal(1, Core.TextDif("gato", "rato"));
        }

        [Fact]
        public void CanCalculateNoDif()
        {
            Assert.Equal(0, Core.TextDif("brasil", "brasil"));
            Assert.Equal(1, Core.TextDif("Brasil", "brasil"));
        }

        [Fact]
        public void CanCalculateSenteceDif()
        {
            Assert.Equal(9, Core.TextDif("o rato roeu a roupa do rei de roma", "o jato voou alem da roupa do rei de roma"));
        }

        [Fact]
        public void CanCalculateLargeSentence()
        {
            var text1 = "Uma pilha é uma estrutura de dados que admite remoção de elementos e inserção de novos objetos.  Mais especificamente, uma  pilha (= stack)  é uma estrutura sujeita à seguinte regra de operação:  sempre que houver uma remoção,  o elemento removido é o que está na estrutura há menos tempo.  Em outras palavras, o primeiro objeto a ser inserido na pilha é o último a ser removido. Essa política é conhecida pela sigla LIFO (= Last-In-First-Out).";
            var text2 = "Uma pilha é uma estrutura de dados que admite inserção de novos objetos.  Mais especificamente, uma  pilha é uma estrutura que possui a regra de operação:  sempre que houver uma remoção,  o elemento removido está na estrutura há menos tempo.  Em outras palavras, o primeiro objeto a ser inserido na pilha é o último a ser removido. Essa política é conhecida pela sigla FIFO (= First-In-First-Out).";
            var text3 = "Uma fila é uma estrutura de dados dinâmica que admite remoção de elementos e inserção de novos objetos.  Mais especificamente, uma  fila  (= queue)  é uma estrutura sujeita à seguinte regra de operação:  sempre que houver uma remoção,  o elemento removido é o que está na estrutura há mais tempo.  Em outras palavras, o primeiro objeto inserido na fila é também o primeiro a ser removido. Essa política é conhecida pela sigla FIFO (= First-In-First-Out).";

            Assert.Equal(58, Core.TextDif(text1, text2));
            Assert.Equal(47, Core.TextDif(text1, text3));
        }

        [Fact]
        public void CanNormalizeGender()
        {
            Assert.Equal("gat", Core.NormalizeText("gato"));
            Assert.Equal("gat", Core.NormalizeText("gata"));

            Assert.Equal("crianc", Core.NormalizeText("crianças"));
            Assert.Equal("brasil", Core.NormalizeText("brasilia"));
        }

        [Fact]
        public void CanNormalizePlural()
        {
            Assert.Equal("gat", Core.NormalizeText("gatos"));
            Assert.Equal("gat", Core.NormalizeText("gatas"));
        }

        [Fact]
        public void CanNormalizeAdverb()
        {
            Assert.Equal("divertid", Core.NormalizeText("divertidamente"));
            Assert.Equal("pront", Core.NormalizeText("prontamente"));
        }

        [Fact]
        public void CanNormalizeAugmentative()
        {
            Assert.Equal("barulha", Core.NormalizeText("barulhao"));
            Assert.Equal("boladã", Core.NormalizeText("boladão"));
        }

        [Fact]
        public void CanNormalizeDiminuitive()
        {
            Assert.Equal("barulinh", Core.NormalizeText("barulinho"));
        }

        [Fact]
        public void CanNormalizeNounSuffix()
        {
            Assert.Equal("especial", Core.NormalizeText("especialista"));
            Assert.Equal("dibrabil", Core.NormalizeText("dibrabilidade"));
            Assert.Equal("idad", Core.NormalizeText("idade"));
        }

        [Fact]
        public void CanNormalizeVerbSuffix()
        {
            Assert.Equal("saind", Core.NormalizeText("saindo"));
            Assert.Equal("arrum", Core.NormalizeText("arrumava"));
            Assert.Equal("arrum", Core.NormalizeText("arrumaria"));
        }

        [Fact]
        public void CanNormalizeVowels()
        {
            Assert.Equal("geladeir", Core.NormalizeText("geladeira"));
        }

        [Fact]
        public void CanMatchKeywords()
        {
            var keywords = new List<string>()
            {
                "brasil",
                "1500",
                "portugueses"
            };

            Assert.Equal(3, Core.KeyWordMatcher("O brasil foi descoberto em 1500 pelos portugueses", keywords));
            Assert.Equal(3, Core.KeyWordMatcher("O brasil foi descoberot em 1500. O brasil foi descoberto pelos portugueses", keywords));
        }
    }
}
