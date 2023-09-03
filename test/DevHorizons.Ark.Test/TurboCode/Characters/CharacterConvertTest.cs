namespace DevHorizons.Ark.Test.Characters
{
    using System.Globalization;
    using TurboCode;

    public class CharacterConvertTest
    {
        [Fact]
        public void FromSingleCharacterStringToChar()
        {
            var source = "A";
            var expected = 'A';
            var actual = source.ToChar();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FromSingleCharacterDigitToChar()
        {
            var source = 9;
            var expected = '\t';
            var actual = source.ToChar();
            Console.WriteLine(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FromSingleCharacterDigitStringToChar()
        {
            var source = '9';
            var expected = '9';
            var actual = source.ToChar();
            Console.WriteLine(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToCharBoolean()
        {
            var source = true;

            var ex = Record.Exception(() => source.ToChar());
            Assert.NotNull(ex);
            Assert.IsType<InvalidCastException>(ex);
        }

        [Fact]
        public void ToCharNull()
        {
            string source = null;
            var expected = Character.Null;
            var actual = source.ToChar();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToCharDefaultValue()
        {
            var source = true;
            var expected = Character.Null;
            var actual = source.ToChar(Character.Null);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToCharDefaultValueOptional()
        {
            var source = 'A';
            var expected = 'A';
            var actual = source.ToChar(Character.Null);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAsciiCode()
        {
            var source = 'A';
            var expected = 65;
            var actual = source.GetAsciiCode();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertFromDigitToChar()
        {
            var source = 65;
            var expected = 'A';
            var actual = source.ToChar();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestToCharString()
        {
            var source = 65;

            var ex = Record.Exception(() => source.ToCharString());
            Assert.NotNull(ex);
            Assert.IsType<FormatException>(ex);
        }


        [Fact]
        public void TestToCharStringFromDigit()
        {
            var source = 9;

            var expected = '9';
            var actual = source.ToCharString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestToCharStringDefaultValue()
        {
            var source = 65;

            var expected = 'A';
            var actual = source.ToCharString('A');
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToCharStringDefaultValueOptional()
        {
            var source = 'A';
            var expected = 'A';
            var actual = source.ToCharString(Character.Null);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUpperCaseCharcter()
        {
            var source = 'a';
            var expected = 'A';
            var actual = source.ToUpper();
            Assert.Equal(expected, actual);

            actual = source.ToUpper(CultureInfo.InvariantCulture);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToLowerCaseCharcter()
        {
            var source = 'A';
            var expected = 'a';
            var actual = source.ToLower();
            Assert.Equal(expected, actual);

            actual = source.ToLower(CultureInfo.InvariantCulture);
            Assert.Equal(expected, actual);
        }
    }
}