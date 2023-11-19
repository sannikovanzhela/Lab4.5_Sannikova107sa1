using ConverterApp;
using System;

namespace TestConverter
{
    public class Tests
    {

        [TestCase(12.23f)]
        [TestCase(9.3332f)]
        [TestCase(321.45545646f)]
        public void ValueHaveTwoAndMoreSymbolsAfterDot(float x)
        {
            Assert.Throws<ArgumentException>(() => Converter.Do(x));
        }

        [Test]
        public void ValueIsZero()
        {
            Assert.Throws<ArgumentException>(() => Converter.Do(0));
        }

        [TestCase(96)]
        [TestCase(3)]
        [TestCase(124)]
        public void ValueIsInteger(float x)
        {
            Assert.Throws<ArgumentException>(() => Converter.Do(x));
        }


        [TestCase(100.7f)]
        [TestCase(1324.1f)]
        [TestCase(563.8f)]
        public void ResultIsThousand(float x)
        {
            var expect = 1000;
            var actual = Converter.Do(x);
            Assert.That(actual, Is.EqualTo(expect));
        }

        [TestCase(-300.7f)]
        [TestCase(-30.5f)]
        [TestCase(-45.2f)]
        public void ResultIsMinusTwoThousand(float x)
        {
            var expect = -2000;
            var actual = Converter.Do(x);
            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void ResultIsInteger32()
        {
            int actual = Converter.Do(32.2f);
            Assert.That(actual, Is.EqualTo(32));
        }

        [Test]
        public void ResultIsIntegerMinusFiveMinusSeven()
        {
            int actual = Converter.Do(-2.2f);
            Assert.That(actual, Is.EqualTo(-7));
        }
    }
}