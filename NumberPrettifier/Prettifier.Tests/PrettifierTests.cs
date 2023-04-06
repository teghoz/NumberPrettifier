using Moq;
using Prettifier.Factories;
using Prettifier.Interfaces;
using Prettifier.Locales.en;
using Prettifier.Locales.fr;
using System.ComponentModel.Design;

namespace Prettifier.Tests
{
    public class PrettifierTests
    {
        private IEnumerable<IPrettifierDictionary> _dictionaryServices;
        private PrettifierDictionaryFactory _prettifierDictionaryFactory;

        [SetUp]
        public void Setup()
        {
            _dictionaryServices = new List<IPrettifierDictionary>() {
                new EnglishPrettyDictionary(),
                new FrenchPrettyDictionary()
            };

            _prettifierDictionaryFactory = new PrettifierDictionaryFactory(_dictionaryServices);
        }

        [Test]
        public void TestThat_1_000_000_IsEqualTo_IM()
        {
            var prettifier = new AbbreviatedPrettifier();
            var number = 1000000;
            var prettifiedText = prettifier.Pretty(number);
            Assert.That(prettifiedText, Is.EqualTo("1M"));
        }

        [Test]
        public void TestThat_2_500_000_34_IsEqualTo_2_5M()
        {
            var prettifier = new AbbreviatedPrettifier();
            var number = 2500000.34;
            var prettifiedText = prettifier.Pretty(number);
            Assert.That(prettifiedText, Is.EqualTo("2.5M"));
        }

        [Test]
        public void TestThat_532_IsEqualTo_532()
        {
            var prettifier = new AbbreviatedPrettifier();
            var number = 532;
            var prettifiedText = prettifier.Pretty(number);
            Assert.That(prettifiedText, Is.EqualTo("532"));
        }

        [Test]
        public void TestThat_1123456789_IsEqualTo_1_1B()
        {
            var prettifier = new AbbreviatedPrettifier();
            var number = 1123456789;
            var prettifiedText = prettifier.Pretty(number);
            Assert.That(prettifiedText, Is.EqualTo("1.1B"));
        }

        [Test]
        public void TestThat100IsEqualToOneHundred()
        {           
            var prettifier = new FullWordPrettifier(_prettifierDictionaryFactory);

            var number = 100;
            var prettifiedText = prettifier.Pretty(number, "en");
            var prettifiedTextInFrench = prettifier.Pretty(number, "fr");
            Assert.That(prettifiedText, Is.EqualTo("one hundred"));
            StringAssert.Contains("un cent", prettifiedTextInFrench);
        }

        [Test]
        public void TestThat1_000_000IsEqualToOneMillion()
        {
            var prettifier = new FullWordPrettifier(_prettifierDictionaryFactory);

            var number = 1_000_000;
            var prettifiedText = prettifier.Pretty(number, "en");
            var prettifiedTextInFrench = prettifier.Pretty(number, "fr");
            StringAssert.Contains("one million", prettifiedText);
            StringAssert.Contains("un million", prettifiedTextInFrench);
        }

        [Test]
        public void TestThat1234567IsEqualToOneMillion()
        {
            var prettifier = new FullWordPrettifier(_prettifierDictionaryFactory);

            var number = 1_234_567;
            var prettifiedText = prettifier.Pretty(number, "en");
            StringAssert.Contains("one million, two hundred and three-four thousand five hundred and six-seven", prettifiedText);
        }
    }
}