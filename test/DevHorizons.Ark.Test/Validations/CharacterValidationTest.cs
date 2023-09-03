namespace DevHorizons.Ark.Test.Characters
{
    using System.Globalization;
    using Validation;

    public class CharacterValidationTest
    {
        [Fact]
        public void IsUpperCaseCharcterTrue()
        {
            var source = 'A';
            var expected = true;
            var actual = source.IsUpper();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsUpperCaseCharcterFalse()
        {
            var source = 'a';
            var expected = false;
            var actual = source.IsUpper();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsLowerCaseCharcterTrue()
        {
            var source = 'a';
            var expected = true;
            var actual = source.IsLower();
            Assert.Equal(expected, actual);

            actual = source.IsLower(CultureInfo.InvariantCulture);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsLowerCaseCharcterFalse()
        {
            var source = 'A';
            var expected = false;
            var actual = source.IsLower();
            Assert.Equal(expected, actual);

            actual = source.IsLower(CultureInfo.InvariantCulture);
            Assert.Equal(expected, actual);
        }
    }
}