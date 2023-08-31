namespace DevHorizons.Ark.Test
{
    using System.Globalization;
    using Exceptions;
    using TurboCode;
    using Validation;

    public class SplitRightCharDelimiterTest
    {
        #region Test Exceptions
        [Fact]
        public void TestSplitWithNullExceptionSource()
        {
            string source = null;
            var delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.SplitRight(delimiter));
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
            var delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.SplitRight(delimiter, 0 , 4));
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
            var delimiter = Character.Null;
            var ex = Record.Exception(() => source.SplitRight(delimiter));
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
            var ex = Record.Exception(() => source.SplitRight(Character.WhiteSpace));
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
            var delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.SplitRight(delimiter, -1));
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
            var delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.SplitRight(delimiter, 0, -1));
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
            var delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.SplitRight(delimiter, source.Length));
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
            var delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.SplitRight(delimiter, 0, source.Length));
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
            var delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.SplitRight(delimiter, 3, 2));
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
            expected.Reverse();
            var actual = source.SplitRight(Character.WhiteSpace, false);
            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitMatchigCaseWord()
        {
            var source = "JanZFebZMarZApril";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            expected.Reverse();
            var actual = source.SplitRight('Z', true);
            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitNonMatchigCaseWord()
        {
            var source = "JanZFebZMarZApril";
            var actual = source.SplitRight('z', true);

            Assert.Null(actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseWord()
        {
            var source = "JanZFebZMarZApril";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April" };
            expected.Reverse();
            var actual = source.SplitRight('z', false, CultureInfo.InvariantCulture);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }


        [Fact]
        public void SplitStartIndexOkWord()
        {
            var source = "Jan ZFebZ Mar Z April";
            var expected = new List<string> { JString.WhiteSpace, " Mar ", "Feb", "Jan " };
            var actual = source.SplitRight('Z', 5, true, CultureInfo.InvariantCulture);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterAtBegining()
        {
            var source = "ZJanZFebZMarZApril";
            var expected = new List<string> { string.Empty, "Jan", "Feb", "Mar", "April" };
            expected.Reverse();
            var actual = source.SplitRight('Z');
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterAtEnd()
        {
            var source = "JanZFebZMarZAprilZ";
            var expected = new List<string> { "Jan", "Feb", "Mar", "April", string.Empty };
            expected.Reverse();
            var actual = source.SplitRight('Z');
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd()
        {
            var source = "ZJanZFebZMarZAprilZ";
            var expected = new List<string> { string.Empty , "Jan", "Feb", "Mar", "April", string.Empty };
            expected.Reverse();
            var actual = source.SplitRight('Z');
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitRedundantDelimiter()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var expected = new List<string> { string.Empty, string.Empty, string.Empty, "Jan", "Feb", string.Empty, "Mar", "April", string.Empty, string.Empty, string.Empty };
            expected.Reverse();
            var actual = source.SplitRight('Z');
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord()
        {
            var source = "Jan ZFebZ Mar Z April";
            var expected = new List<string> { JString.WhiteSpace, " Mar ", "Feb", "Jan " };
            var actual = source.SplitRight('z', 5, false);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitStartIndexWrongCaseWord()
        {
            var source = "Jan ZFebZ Mar Z April";
            var actual = source.SplitRight('z', 5);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWrongCaseWord()
        {
            var source = "JanZFebZMarZApril";
            var actual = source.SplitRight('z', 5, 13);
            Assert.Null(actual);
        }


        [Fact]
        public void SplitStartIndexEndIndexWord()
        {
            var source = "JanZFebZMarZApril";
            var expected = new List<string> { string.Empty, "Mar", "Feb", string.Empty };
            var actual = source.SplitRight('z', 5, 13, false);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitStartNonValidatedEndIndexII()
        {
            var source = "JanZFebZMarZApril";
            var actual = source.SplitRight('m', 0, 5, false);
            Assert.Null(actual);
        }


        [Fact]
        public void SplitDelimiterOnly()
        {
            var source = "Z";
            var expected = new List<string> { string.Empty, string.Empty };
            expected.Reverse();
            var actual = source.SplitRight('Z');
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterOnly2()
        {
            var source = "Z";
            var expected = new List<string> { string.Empty, string.Empty };
            expected.Reverse();
            var actual = source.SplitRight('z', false);
            Assert.NotNull(actual);

            Assert.True(expected.CompareTo(actual));
        }

        [Fact]
        public void SplitDelimiterOnlyNotMatch()
        {
            var source = "Z";
            var actual = source.SplitRight('z');
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyNotMatch2()
        {
            var source = "Z";
            var actual = source.SplitRight('M');
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyWhiteSpace()
        {
            var source = JString.WhiteSpace;
            var expected = new List<string> { string.Empty, string.Empty };
            expected.Reverse();
            var actual = source.SplitRight(Character.WhiteSpace);
            Assert.NotNull(actual);
            Assert.True(expected.CompareTo(actual));
        }
    }
}
