namespace DevHorizons.Ark.Test
{
    using Exceptions;
    using TurboCode;
    using Validation;

    public class JStringSplitCharDelimiter
    {
        #region Test Exceptions
        [Fact]
        public void TestSplitWithNullExceptionSource()
        {
            string source = null;
            char delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.JSplit(delimiter));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
            var argumentNullException = ex as ArgumentNullException;
            Assert.NotNull(argumentNullException);
            Assert.Equal("source", argumentNullException.ParamName);
        }

        [Fact]
        public void TestSplitWithNullExceptionSourceWithStartAndEndSpecified()
        {
            string source = null;
            char delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.JSplit(delimiter, 0, 4));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
            var argumentNullException = ex as ArgumentNullException;
            Assert.NotNull(argumentNullException);
            Assert.Equal("source", argumentNullException.ParamName);
        }

        [Fact]
        public void TestSplitWithNullExceptionDelimiter()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.Null;
            var ex = Record.Exception(() => source.JSplit(delimiter));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
            var argumentNullException = ex as ArgumentNullException;
            Assert.NotNull(argumentNullException);
            Assert.Equal("delimiter", argumentNullException.ParamName);
        }

        [Fact]
        public void TestSplitWithEmptyExceptionSource()
        {
            string source = string.Empty;
            var ex = Record.Exception(() => source.JSplit(Character.WhiteSpace));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("source", argumentException.Origin.Argument);
            Assert.Equal(ArgumentExceptionCode.EmptyString, argumentException.ExceptionCode);
            Assert.Equal((int)ArgumentExceptionCode.EmptyString, argumentException.Code);
        }

        [Fact]
        public void TestSplitWithEmptyExceptionSourceWithStartAndEnd()
        {
            string source = string.Empty;
            var ex = Record.Exception(() => source.JSplit(Character.WhiteSpace, 1, 2));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("source", argumentException.Origin.Argument);
            Assert.Equal(ArgumentExceptionCode.EmptyString, argumentException.ExceptionCode);
            Assert.Equal((int)ArgumentExceptionCode.EmptyString, argumentException.Code);
        }



        [Fact]
        public void TestSplitExceptionStartLessThanZero()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.JSplit(delimiter, -1));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("start", argumentException.Origin.Argument);
            Assert.Null(argumentException.ConflictArguement);
            var expectedErrorCode = ArgumentExceptionCode.OutRange;
            Assert.Equal(expectedErrorCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedErrorCode, argumentException.Code);
        }

        [Fact]
        public void TestSplitExceptionEndLessThanZero()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.JSplit(delimiter, 0, -1));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("end", argumentException.Origin.Argument);
            Assert.Null(argumentException.ConflictArguement);
            var expectedErrorCode = ArgumentExceptionCode.OutRange;
            Assert.Equal(expectedErrorCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedErrorCode, argumentException.Code);
        }

        [Fact]
        public void TestSplitExceptionStartGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.JSplit(delimiter, source.Length));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("start", argumentException.Origin.Argument);
            Assert.NotNull(argumentException.ConflictArguement);
            Assert.Equal("source", argumentException.ConflictArguement);
            var expectedErrorCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
            Assert.Equal(expectedErrorCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedErrorCode, argumentException.Code);
        }

        [Fact]
        public void TestSplitExceptionEndtGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.JSplit(delimiter, 0, source.Length));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("end", argumentException.Origin.Argument);
            Assert.NotNull(argumentException.ConflictArguement);
            Assert.Equal("source", argumentException.ConflictArguement);
            var expectedErrorCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
            Assert.Equal(expectedErrorCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedErrorCode, argumentException.Code);
        }

        [Fact]
        public void TestSplitExceptionStartGreaterThanEnd()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.JSplit(delimiter, 3, 2));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("start", argumentException.Origin.Argument);
            Assert.NotNull(argumentException.ConflictArguement);
            Assert.Equal("end", argumentException.ConflictArguement);
            var expectedErrorCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
            Assert.Equal(expectedErrorCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedErrorCode, argumentException.Code);
        }
        #endregion Test Exceptions

        [Fact]
        public void SplitWhiteSpaceMatchCase()
        {
            var source = "Jan Feb Mar April";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            List<string> actual = source.JSplit(' ', true);
            IReadOnlyList<string> actualReadOnlyList = source.JSplit(' ', true);
            string[] actualArray = source.JSplit(' ', true).ToArray();
            HashSet<string> actualHashSet = source.JSplit(' ', true).ToHashSet();
            // var actual = source.JSplit(' ', true);
            Assert.True(expected.CompareTo(actual));
            Assert.True(expected.CompareTo(actualArray));
            Assert.True(expected.CompareTo(actualHashSet));
            Assert.True(expected.CompareTo(actualReadOnlyList));
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

        [Fact]
        public void SplitelimiterOnly()
        {
            var source = JString.WhiteSpace;
            var expected = new List<string> { string.Empty, string.Empty };
            var actual = source.JSplit(Character.WhiteSpace);
            Assert.NotNull(actual);
            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitelimiterOnly2()
        {
            var source = "A";
            var expected = new List<string> { string.Empty, string.Empty };
            var actual = source.JSplit('A');
            Assert.NotNull(actual);
            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitelimiterOnly3()
        {
            var source = "A";
            var expected = new List<string> { string.Empty, string.Empty };
            var actual = source.JSplit('a', false);
            Assert.NotNull(actual);
            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitelimiterOnlyNotMatch()
        {
            var source = JString.WhiteSpace;
            var expected = new List<string> { string.Empty, string.Empty };
            var actual = source.JSplit('X');
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining()
        {
            var source = " Jan Feb Mar April";
            var expected = new List<string> { string.Empty, "Jan", "Feb", "Mar", "April" };
            var actual = source.JSplit(Character.WhiteSpace);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterAtEnd()
        {
            var source = "Jan Feb Mar April ";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April", string.Empty };
            var actual = source.JSplit(Character.WhiteSpace);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd()
        {
            var source = " Jan Feb Mar April ";
            var expected = new List<string> { string.Empty, "Jan", "Feb", "Mar", "April", string.Empty };
            var actual = source.JSplit(Character.WhiteSpace);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitRedundantDelimiter()
        {
            var source = "   Jan Feb  Mar April   ";
            var expected = new List<string> { string.Empty, string.Empty, string.Empty, "Jan", "Feb", string.Empty, "Mar", "April", string.Empty, string.Empty, string.Empty };
            var actual = source.JSplit(Character.WhiteSpace);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }
    }
}
