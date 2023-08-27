namespace DevHorizons.Ark.Test
{
    using System.Globalization;
    using Validation;

    public class JStringValidationTest
    {
        [Fact]
        public void IsUpperCaseStringTrue()
        {
            var source = "AHMAD GAD";
            var expected = true;
            var actual = source.IsUpper();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsUpperCaseStringFalse()
        {
            var source = "Ahmad Gad";
            var expected = false;
            var actual = source.IsUpper();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsLowerCaseStringTrue()
        {
            var source = "ahmad gad";
            var expected = true;
            var actual = source.IsLower();
            Assert.Equal(expected, actual);

            actual = source.IsLower(CultureInfo.InvariantCulture);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsLowerCaseStringFalse()
        {
            var source = "Ahmad Gad";
            var expected = false;
            var actual = source.IsLower();
            Assert.Equal(expected, actual);

            actual = source.IsLower(CultureInfo.InvariantCulture);
            Assert.Equal(expected, actual);
        }
    }
}
