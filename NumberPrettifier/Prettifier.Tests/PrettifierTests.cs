using Prettifier.Factories;
using Prettifier.Interfaces;
using Prettifier.Locales.en;
using Prettifier.Locales.fr;

namespace Prettifier.Tests;

public class PrettifierTests
{
    private IEnumerable<IPrettifierDictionary>? _dictionaryServices;
    private IPrettifier? _fullWordPrettifier;
    private IPrettifier? _abbreviatedPrettifier;
    private PrettifierDictionaryFactory? _prettifierDictionaryFactory;

    [SetUp]
    public void Setup()
    {
        _dictionaryServices = new List<IPrettifierDictionary> {
            new EnglishPrettyDictionary(),
            new FrenchPrettyDictionary()
        };

        _prettifierDictionaryFactory = new PrettifierDictionaryFactory(_dictionaryServices);
        _fullWordPrettifier = new FullWordPrettifier(_prettifierDictionaryFactory);
        _abbreviatedPrettifier = new AbbreviatedPrettifier();
    }
    
    [Test]
    public void TestThat_532_IsEqualTo_532()
    {
        const int number = 532;
        var prettifiedText = _abbreviatedPrettifier?.Pretty(number);
        Assert.That(prettifiedText, Is.EqualTo("532"));
    }
    
    [Test]
    public void TestThat100BecomesToOneHundred()
    {
        const int number = 100;
        var prettifiedText = _fullWordPrettifier?.Pretty(number, "en");
        var prettifiedTextInFrench = _fullWordPrettifier?.Pretty(number, "fr");
        Assert.That(prettifiedText, Is.EqualTo("one hundred"));
        StringAssert.Contains("un cent", prettifiedTextInFrench);
    }
    
    [Test]
    public void TestThat_999_999_99_IsEqualTo_999_999_9()
    {
        const decimal number = 999_999.99m;
        var prettifiedText = _abbreviatedPrettifier?.Pretty(number);
        Assert.That(prettifiedText, Is.EqualTo("999999.9"));
    }

    [Test]
    public void TestThat_1_000_000_IsEqualTo_IM()
    {
        const int number = 1000000;
        var prettifiedText = _abbreviatedPrettifier?.Pretty(number);
        Assert.That(prettifiedText, Is.EqualTo("1M"));
    }
    
    [Test]
    public void TestThat_1_000_001_IsEqualTo_1M()
    {
        const int number = 1_000_001;
        var prettifiedText = _abbreviatedPrettifier?.Pretty(number);
        Assert.That(prettifiedText, Is.EqualTo("1M"));
    }
    
    [Test]
    public void TestThat1_000_000IsEqualToOneMillion()
    {
        const int number = 1_000_000;
        var prettifiedText = _fullWordPrettifier?.Pretty(number, "en");
        var prettifiedTextInFrench = _fullWordPrettifier?.Pretty(number, "fr");
        StringAssert.Contains("one million", prettifiedText);
        StringAssert.Contains("un million", prettifiedTextInFrench);
    }

    [Test]
    public void TestThat_1_000_001_0_IsEqualTo_1M()
    {
        const decimal number = 1000_000.0m;
        var prettifiedText = _abbreviatedPrettifier?.Pretty(number);
        Assert.That(prettifiedText, Is.EqualTo("1M"));
    }
    
    [Test]
    public void TestThat1234567IsEqualToOneMillion()
    {
        const int number = 1_234_567;
        var prettifiedText = _fullWordPrettifier?.Pretty(number, "en");
        StringAssert.Contains("one million, two hundred and three-four thousand five hundred and six-seven", prettifiedText);
    }

    [Test]
    public void TestThat_2_500_000_34_IsEqualTo_2_5M()
    {
        const decimal number = 2500000.34m;
        var prettifiedText = _abbreviatedPrettifier?.Pretty(number);
        Assert.That(prettifiedText, Is.EqualTo("2.5M"));
    }

    [Test]
    public void TestThat_1_000_000_000_BecomesTo_1B()
    {
        const int number = 1_000_000_000;
        var prettifiedText = _abbreviatedPrettifier?.Pretty(number);
        Assert.That(prettifiedText, Is.EqualTo("1B"));
    }

    [Test]
    public void TestThat_1123456789_BecomesTo_1_1B()
    {
        const int number = 1123456789;
        var prettifiedText = _abbreviatedPrettifier?.Pretty(number);
        Assert.That(prettifiedText, Is.EqualTo("1.1B"));
    }
}