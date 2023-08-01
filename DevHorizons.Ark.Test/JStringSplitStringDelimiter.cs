namespace DevHorizons.Ark.Test
{
    public class JStringSplitStringDelimiter
    {
        [Fact]
        public void SplitWhiteSpaceMatchCase()
        {
            var source = "Jan Feb Mar April";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            var actual = source.JSplit(' ', true);
            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitWhiteSpaceNoMatchCase()
        {
            var source = "Jan Feb Mar April";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            var actual = source.JSplit(' ', false);
            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitNonMatchigCase()
        {
            var source = "JanZFebZMarZApril";
            var actual = source.JSplit('z');

            Assert.Null(actual);
        }

        [Fact]
        public void SplitNonMatchigCaseMatchCaseTrue()
        {
            var source = "JanZFebZMarZApril";
            var actual = source.JSplit('z', true);

            Assert.Null(actual);
        }

        [Fact]
        public void SplitMatchigCaseMatchCaseFalse()
        {
            var source = "JanZFebZMarZApril";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            var actual = source.JSplit('Z', false);
            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitMatchigCaseMatchCaseTrue()
        {
            var source = "JanZFebZMarZApril";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            var actual = source.JSplit('Z', true);
            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitNonMatchigCaseMatchCaseFalse()
        {
            var source = "JanZFebZMarZApril";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            var actual = source.JSplit('z', false);
            Assert.True(expected.CompareTo(actual));
        }
    }
}
