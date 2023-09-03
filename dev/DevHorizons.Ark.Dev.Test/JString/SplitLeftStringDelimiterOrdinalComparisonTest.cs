namespace DevHorizons.Ark.Dev.Test
{
    using System.Globalization;
    using Exceptions;
    using TurboCode;
    using Validation;

    public class SplitLeftStringDelimiterOrdinalComparisonTest
    {
        #region Test Exceptions
        [Fact]
        public void TestSplitWithNullExceptionSource()
        {
            string source = null;
            string delimiter = string.Empty;
            var ex = Record.Exception(() => source.SplitLeftOrdinalComparison(delimiter));
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
            string delimiter = string.Empty;
            var ex = Record.Exception(() => source.SplitLeftOrdinalComparison(delimiter, 0 , 4));
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
            string delimiter = null;
            var ex = Record.Exception(() => source.SplitLeftOrdinalComparison(delimiter));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
            var argumentNullException = ex as ArgumentNullException;
            Assert.NotNull(argumentNullException);
            Assert.Equal("delimiter", argumentNullException.ParamName);
        }

        [Fact]
        public void TestSplitWithEmptyStringExceptionSource()
        {
            string source = string.Empty;
            var ex = Record.Exception(() => source.SplitLeftOrdinalComparison(string.Empty));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("source", argumentException.Origin.Argument);
            Assert.Equal(ArgumentExceptionCode.EmptyString, argumentException.ExceptionCode);
            Assert.Equal((int)ArgumentExceptionCode.EmptyString, argumentException.Code);
        }

        [Fact]
        public void TestSplitWithEmptyExceptionDelimiter()
        {
            string source = "Ahmad Gad";
            string delimiter = string.Empty;
            var ex = Record.Exception(() => source.SplitLeftOrdinalComparison(delimiter));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("delimiter", argumentException.Origin.Argument);
            Assert.Equal(ArgumentExceptionCode.EmptyString, argumentException.ExceptionCode);
            Assert.Equal((int)ArgumentExceptionCode.EmptyString, argumentException.Code);
        }

        [Fact]
        public void TestSplitExceptionDelimiterLengthComparedToSourceLength()
        {
            string source = "Ahmad Gad";
            string delimiter = "Ahmad Gad1";
            var ex = Record.Exception(() => source.SplitLeftOrdinalComparison(delimiter));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("delimiter", argumentException.Origin.Argument);
            Assert.NotNull(argumentException.ConflictArguement);
            Assert.Equal("source", argumentException.ConflictArguement);
            var expectedErrorCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
            Assert.Equal(expectedErrorCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedErrorCode, argumentException.Code);
        }

        [Fact]
        public void TestSplitExceptionStartLessThanZero()
        {
            string source = "Ahmad Gad";
            string delimiter = JString.WhiteSpace;
            var ex = Record.Exception(() => source.SplitLeftOrdinalComparison(delimiter, -1));
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
        public void TestSplitExceptionEndEqualZero()
        {
            string source = "Ahmad Gad";
            string delimiter = "12";
            var ex = Record.Exception(() => source.SplitLeftOrdinalComparison(delimiter, 0, 0));
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
        public void TestSplitExceptionEndLessThanZero()
        {
            string source = "Ahmad Gad";
            string delimiter = "12";
            var ex = Record.Exception(() => source.SplitLeftOrdinalComparison(delimiter, 0, -1));
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
            string delimiter = JString.WhiteSpace;
            var ex = Record.Exception(() => source.SplitLeftOrdinalComparison(delimiter, source.Length));
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
        public void TestSplitExceptionEndGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            string delimiter = "12";
            var ex = Record.Exception(() => source.SplitLeftOrdinalComparison(delimiter, 0, source.Length));
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
        public void TestSplitExceptionStartEqualToEnd()
        {
            string source = "Ahmad Gad";
            string delimiter = "12";
            var ex = Record.Exception(() => source.SplitLeftOrdinalComparison(delimiter, 2, 2));
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

        [Fact]
        public void TestSplitExceptionStartGreaterThanEnd()
        {
            string source = "Ahmad Gad";
            string delimiter = "12";
            var ex = Record.Exception(() => source.SplitLeftOrdinalComparison(delimiter, 3, 2));
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
        public void SplitWhiteSpace()
        {
            var source = "Jan Feb Mar April";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            var actual = source.SplitLeftOrdinalComparison(JString.WhiteSpace, true);
            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitMatchigCaseWord()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            var actual = source.SplitLeftOrdinalComparison("HELLO", false);
            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitNonMatchigCaseWord()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var actual = source.SplitLeftOrdinalComparison("hello", false);

            Assert.Null(actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseWord()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            var actual = source.SplitLeftOrdinalComparison("hello", StringComparison.OrdinalIgnoreCase);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }


        [Fact]
        public void SplitStartIndexOkWord()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var expected = new List<string> { "ELLOFeb", " Mar ", " April" };
            var actual = source.SplitLeftOrdinalComparison("HELLO", 5, false);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterAtBegining()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { string.Empty, "Jan", "Feb", "Mar", "April" };
            var actual = source.SplitLeftOrdinalComparison("HELLO");
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterAtEnd()
        {
            var source = "JanHELLOFebHELLOMarHELLOAprilHELLO";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April", string.Empty };
            var actual = source.SplitLeftOrdinalComparison("HELLO");
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOAprilHELLO";
            var expected = new List<string> { string.Empty , "Jan", "Feb", "Mar", "April", string.Empty };
            var actual = source.SplitLeftOrdinalComparison("HELLO");
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitRedundantDelimiter()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var expected = new List<string> { string.Empty, string.Empty, string.Empty, "Jan", "Feb", string.Empty, "Mar", "April", string.Empty, string.Empty, string.Empty };
            var actual = source.SplitLeftOrdinalComparison("HELLO");
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var expected = new List<string> { "ELLOFeb", " Mar ", " April" };
            var actual = source.SplitLeftOrdinalComparison("hello", 5, true);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitStartIndexWrongCaseWord()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var actual = source.SplitLeftOrdinalComparison("hello", 5);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWrongCaseWord()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var actual = source.SplitLeftOrdinalComparison("hello", 5, 25);
            Assert.Null(actual);
        }


        [Fact]
        public void SplitStartIndexEndIndexWord()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var expected = new List<string> { "LLOFeb", "Mar", "Ap" };
            var actual = source.SplitLeftOrdinalComparison("hello", 5, 25, true);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitStartNonValidatedStartIndexIII()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var actual = source.SplitLeftOrdinalComparison("hello", 25, true);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartNonValidatedEndIndexII()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var actual = source.SplitLeftOrdinalComparison("hello", 0, 5, true);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitLongDelimiter()
        {
            var source = "JanHELLOWORLDFeb";
            var expected = new List<string> { "Jan", "Feb" };
            var actual = source.SplitLeftOrdinalComparison("HELLOWORLD");
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitLongDelimiter2()
        {
            var source = "JanHELLOWORLDFebHELLOWORLD2";
            var expected = new List<string> { "Jan", "Feb", "2" };
            var actual = source.SplitLeftOrdinalComparison("HELLOWORLD");
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitLongDelimiter3()
        {
            var source = "HELLOWORLDJanHELLOWORLD";
            var expected = new List<string> { string.Empty, "Jan", string.Empty };
            var actual = source.SplitLeftOrdinalComparison("HELLOWORLD");
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterOnly()
        {
            var source = "HELLOWORLD";
            var expected = new List<string> { string.Empty, string.Empty };
            var actual = source.SplitLeftOrdinalComparison("HELLOWORLD");
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterOnly2()
        {
            var source = "HELLOWORLD";
            var expected = new List<string> { string.Empty, string.Empty };
            var actual = source.SplitLeftOrdinalComparison("helloworld", true);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterOnlyNotMatch()
        {
            var source = "HELLOWORLD";
            var actual = source.SplitLeftOrdinalComparison("helloworld");
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyWhiteSpace()
        {
            var source = JString.WhiteSpace;
            var expected = new List<string> { string.Empty, string.Empty };
            var actual = source.SplitLeftOrdinalComparison(JString.WhiteSpace);
            Assert.NotNull(actual);
            Assert.True(expected.CompareTo(actual));
        }
    }
}
