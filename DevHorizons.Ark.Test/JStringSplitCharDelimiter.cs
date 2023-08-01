namespace DevHorizons.Ark.Test
{
    public class JStringSplitCharDelimiter
    {
        [Fact]
        public void SplitWhiteSpace()
        {
            var source = "Jan Feb Mar April";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            var actual = source.JSplit(" ", false);
            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitMatchigCaseWord()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            var actual = source.JSplit("HELLO", true);
            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitNonMatchigCaseWord()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var actual = source.JSplit("hello", true);

            Assert.Null(actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseWord()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            var actual = source.JSplit("hello", false);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterIsLongerThanTextWord()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var actual = source.JSplit("helloWorldhelloWorldhelloWorldhelloWorld", true);

            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexOkWord()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var expected = new List<string> { "ELLOFeb", " Mar ", " April" };
            var actual = source.JSplit("HELLO", 5, true);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var expected = new List<string> { "ELLOFeb", " Mar ", " April" };
            var actual = source.JSplit("hello", 5, false);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitStartIndexWrongCaseWord()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var expected = new List<string> { "ELLOFeb", " Mar ", " April" };
            var actual = source.JSplit("hello", 5);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWrongCaseWord()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            var actual = source.JSplit("hello", 5, 25);
            Assert.Null(actual);
        }


        [Fact]
        public void SplitStartIndexEndIndexWord()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "LLOFeb", "Mar", "Ap" };
            var actual = source.JSplit("hello", 5, 25, false);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitStartNonValidatedStartIndex()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "LLOFeb", "Mar", "Ap" };
            var actual = source.JSplit("hello", 30, 25, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartNonValidatedStartIndexII()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "LLOFeb", "Mar", "Ap" };
            var actual = source.JSplit("hello", -1, 25, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartNonValidatedStartIndexIII()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "LLOFeb", "Mar", "Ap" };
            var actual = source.JSplit("hello", 25, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartNonValidatedEndIndex()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "LLOFeb", "Mar", "Ap" };
            var actual = source.JSplit("hello", 0, -1, false);
            Assert.Null(actual);
        }


        [Fact]
        public void SplitStartNonValidatedEndIndexII()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "LLOFeb", "Mar", "Ap" };
            var actual = source.JSplit("hello", 0, 5, false);
            Assert.Null(actual);
        }


        [Fact]
        public void SplitStartNonValidatedEndIndexIII()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "LLOFeb", "Mar", "Ap" };
            var actual = source.JSplit("hello", 10, 5, false);
            Assert.Null(actual);
        }


        [Fact]
        public void SplitStartNonValidatedEndIndexIV()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "LLOFeb", "Mar", "Ap" };
            var actual = source.JSplit("hello", 10, 30, false);
            Assert.Null(actual);
        }
    }
}
