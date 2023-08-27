namespace DevHorizons.Ark.Test
{
    using TurboCode;
    using Validation;

    public class JCompareTest
    {
        [Fact]
        public void CompareMatchingStringListToArray()
        {
            var source = new List<string> { "Jan", "Feb", "Mar", "April" };
            var value = new string[4] { "Jan", "Feb", "Mar", "April" };

            var expected = true;
            var actual = source.CompareTo(value);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CompareMatchingStringList02ToArray()
        {
            var source = new List<string> { string.Empty, "\r", "\n", "\t", "\r\n" };
            var value = new string[5] { "", Character.Cr.ToString(), Character.Lf.ToString(), Character.HorizontalTab.ToString(), JString.CrLf };

            var expected = true;
            var actual = source.CompareTo(value);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CompareMatchingDigitsListToArray()
        {
            var source = new List<int> { 3, 33, 50};
            var value = new int[3] {3, 33, 50};

            var expected = true;
            var actual = source.CompareTo(value);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CompareNotMatchingStringCasingListToArray()
        {
            var source = new List<string> { "Jan", "Feb", "Mar", "April" };
            var value = new string[4] { "Jan", "Feb", "Mar", "april" };

            var expected = false;
            var actual = source.CompareTo(value);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void CompareNotMatchingStringCountListToArray()
        {
            var source = new List<string> { "Jan", "Feb", "Mar" };
            var value = new string[4] { "Jan", "Feb", "Mar", "April" };

            var expected = false;
            var actual = source.CompareTo(value);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CompareNullableSource()
        {
            string[]? source = null;
            var value = new string[4] { "Jan", "Feb", "Mar", "April" };
            var ex = Record.Exception(() => source.CompareTo(value));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void CompareNullableValue()
        {
            string[]? value = null;
            var source = new string[4] { "Jan", "Feb", "Mar", "April" };
            var ex = Record.Exception(() => source.CompareTo(value));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }
    }
}
