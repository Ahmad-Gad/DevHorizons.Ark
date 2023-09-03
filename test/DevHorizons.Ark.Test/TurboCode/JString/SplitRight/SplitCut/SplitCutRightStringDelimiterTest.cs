namespace DevHorizons.Ark.Test
{
    using System.Globalization;
    using Exceptions;
    using TurboCode;

    public class SplitCutRightStringDelimiterTest
    {
        #region Test Exceptions
        [Fact]
        public void TestSplitWithNullExceptionSource()
        {
            string source = null;
            string delimiter = string.Empty;
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, 0));
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
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, 0, 0, 4));
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
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, 0));
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
            var ex = Record.Exception(() => source.SplitCutRight(string.Empty, 0));
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
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, 0));
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
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, 0));
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
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, 0, -1));
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
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, 0, 0, 0));
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
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, 0, 0, -1));
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
        public void TestSplitExceptionIndexLessThanZero()
        {
            string source = "Ahmad Gad";
            string delimiter = "12";
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, -1));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("index", argumentException.Origin.Argument);
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
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, 0, source.Length));
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
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, 0, 0, source.Length));
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
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, 0, 2, 2));
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
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, 0, 3, 2));
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
        public void SplitWhiteSpace0()
        {
            var source = "Jan Feb Mar April";
            var delimiter = JString.WhiteSpace;
            var index = 0;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitWhiteSpace1()
        {
            var source = "Jan Feb Mar April";
            var delimiter = JString.WhiteSpace;
            var index = 1;
            var expected = "Mar";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitWhiteSpace2()
        {
            var source = "Jan Feb Mar April";
            var delimiter = JString.WhiteSpace;
            var index = 2;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitWhiteSpace3()
        {
            var source = "Jan Feb Mar April";
            var delimiter = JString.WhiteSpace;
            var index = 3;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitWhiteSpace4()
        {
            var source = "Jan Feb Mar April";
            var delimiter = JString.WhiteSpace;
            var index = 4;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitWhiteSpace5()
        {
            var source = "Jan Feb Mar April";
            var delimiter = JString.WhiteSpace;
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitWhiteSpace6()
        {
            var source = "Jan Feb Mar April";
            var delimiter = JString.WhiteSpace;
            var index = 6;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitMatchigCaseWord0()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 0;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index, true);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitMatchigCaseWord1()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 1;
            var expected = "Mar";
            var actual = source.SplitCutRight(delimiter, index, true);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitMatchigCaseWord2()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 2;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index, true);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitMatchigCaseWord3()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 3;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index, true);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitMatchigCaseWord4()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 4;
            var actual = source.SplitCutRight(delimiter, index, true);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitMatchigCaseWord5()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index, true);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitMatchigCaseWord6()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 6;
            var actual = source.SplitCutRight(delimiter, index, true);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitNonMatchigCaseWord()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "hello";
            var index = 0;
            var actual = source.SplitCutRight(delimiter, index, true);

            Assert.Null(actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseWord0()
        {
            var source = "JanHELLOFebHeLlOMarhELLoApril";
            var delimiter = "hello";
            var index = 0;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index, false, CultureInfo.InvariantCulture);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseWord1()
        {
            var source = "JanHELLOFebHeLlOMarhELLoApril";
            var delimiter = "hello";
            var index = 1;
            var expected = "Mar";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseWord2()
        {
            var source = "JanHELLOFebHeLlOMarhELLoApril";
            var delimiter = "hello";
            var index = 2;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseWord3()
        {
            var source = "JanHELLOFebHeLlOMarhELLoApril";
            var delimiter = "hello";
            var index = 3;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseWord4()
        {
            var source = "JanHELLOFebHeLlOMarhELLoApril";
            var delimiter = "hello";
            var index = 4;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseWord5()
        {
            var source = "JanHELLOFebHeLlOMarhELLoApril";
            var delimiter = "hello";
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseWord6()
        {
            var source = "JanHELLOFebHeLlOMarhELLoApril";
            var delimiter = "hello";
            var index = 6;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining0()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 0;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining1()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 1;
            var expected = "Mar";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining2()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 2;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining3()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 3;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining4()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 4;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining5()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining6()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOApril";
            var delimiter = "HELLO";
            var index = 6;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtEnd0()
        {
            var source = "JanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 0;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtEnd1()
        {
            var source = "JanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 1;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtEnd2()
        {
            var source = "JanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 2;
            var expected = "Mar";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtEnd3()
        {
            var source = "JanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 3;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void SplitDelimiterAtEnd4()
        {
            var source = "JanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 4;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtEnd5()
        {
            var source = "JanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtEnd6()
        {
            var source = "JanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 6;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd0()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 0;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd1()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 1;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd2()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 2;
            var expected = "Mar";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd3()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 3;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd4()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 4;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd5()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 5;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd6()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 6;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd7()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 7;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd100()
        {
            var source = "HELLOJanHELLOFebHELLOMarHELLOAprilHELLO";
            var delimiter = "HELLO";
            var index = 100;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitRedundantDelimiter0()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var delimiter = "HELLO";
            var index = 0;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter1()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var delimiter = "HELLO";
            var index = 1;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter2()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var delimiter = "HELLO";
            var index = 2;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter3()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var delimiter = "HELLO";
            var index = 3;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter4()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var delimiter = "HELLO";
            var index = 4;
            var expected = "Mar";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void SplitRedundantDelimiter5()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var delimiter = "HELLO";
            var index = 5;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter6()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var delimiter = "HELLO";
            var index = 6;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter7()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var delimiter = "HELLO";
            var index = 7;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter8()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var delimiter = "HELLO";
            var index = 8;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter9()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var delimiter = "HELLO";
            var index = 9;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter10()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var delimiter = "HELLO";
            var index = 10;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter11()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var delimiter = "HELLO";
            var index = 11;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitRedundantDelimiter12()
        {
            var source = "HELLOHELLOHELLOJanHELLOFebHELLOHELLOMarHELLOAprilHELLOHELLOHELLO";
            var delimiter = "HELLO";
            var index = 12;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnly0()
        {
            var source = "HELLOWORLD";
            var delimiter = source;
            var index = 0;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterOnly1()
        {
            var source = "HELLOWORLD";
            var delimiter = source;
            var index = 1;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterOnly2()
        {
            var source = "HELLOWORLD";
            var delimiter = source;
            var index = 2;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnly3()
        {
            var source = "HELLOWORLD";
            var delimiter = source;
            var index = 3;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyIgnoreCase0()
        {
            var source = "HELLOWORLD";
            var delimiter = "helloworld";
            var index = 0;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterOnlyIgnoreCase1()
        {
            var source = "HELLOWORLD";
            var delimiter = "helloworld";
            var index = 1;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterOnlyIgnoreCase2()
        {
            var source = "HELLOWORLD";
            var delimiter = "helloworld";
            var index = 2;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyIgnoreCase3()
        {
            var source = "HELLOWORLD";
            var delimiter = "helloworld";
            var index = 3;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyNotMatch0()
        {
            var source = "HELLOWORLD";
            var delimiter = "helloworld";
            var index = 0;
            var actual = source.SplitCutRight(delimiter, index, true);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyNotMatch1()
        {
            var source = "HELLOWORLD";
            var delimiter = "helloworld";
            var index = 1;
            var actual = source.SplitCutRight(delimiter, index, true);
            Assert.Null(actual);
        }


        [Fact]
        public void SplitDelimiterOnlyNotMatch100()
        {
            var source = "HELLOWORLD";
            var delimiter = "helloworld";
            var index = 100;
            var actual = source.SplitCutRight(delimiter, index, true);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyWhiteSpace0()
        {
            var source = JString.WhiteSpace;
            var delimiter = source;
            var index = 0;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterOnlyWhiteSpace1()
        {
            var source = JString.WhiteSpace;
            var delimiter = source;
            var index = 1;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterOnlyWhiteSpace2()
        {
            var source = JString.WhiteSpace;
            var delimiter = source;
            var index = 2;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyWhiteSpace3()
        {
            var source = JString.WhiteSpace;
            var delimiter = source;
            var index = 3;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitLongDelimiterCase1Test0()
        {
            var source = "JanHELLOWORLDFeb";
            var delimiter = "HELLOWORLD";
            var index = 0;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitLongDelimiterCase1Test1()
        {
            var source = "JanHELLOWORLDFeb";
            var delimiter = "HELLOWORLD";
            var index = 1;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitLongDelimiterCase1Test2()
        {
            var source = "JanHELLOWORLDFeb";
            var delimiter = "HELLOWORLD";
            var index = 2;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitLongDelimiterCase1Test3()
        {
            var source = "JanHELLOWORLDFeb";
            var delimiter = "HELLOWORLD";
            var index = 3;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitLongDelimiterCase2Test0()
        {
            var source = "JanHELLOWORLDFebHELLOWORLD2";
            var delimiter = "HELLOWORLD";
            var index = 0;
            var expected = "2";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitLongDelimiterCase2Test1()
        {
            var source = "JanHELLOWORLDFebHELLOWORLD2";
            var delimiter = "HELLOWORLD";
            var index = 1;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitLongDelimiterCase2Test2()
        {
            var source = "JanHELLOWORLDFebHELLOWORLD2";
            var delimiter = "HELLOWORLD";
            var index = 2;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitLongDelimiterCase2Test3()
        {
            var source = "JanHELLOWORLDFebHELLOWORLD2";
            var delimiter = "HELLOWORLD";
            var index = 3;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitLongDelimiterCase2Test4()
        {
            var source = "JanHELLOWORLDFebHELLOWORLD2";
            var delimiter = "HELLOWORLD";
            var index = 4;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitLongDelimiterCase3Test0()
        {
            var source = "HELLOWORLDJanHELLOWORLD";
            var delimiter = "HELLOWORLD";
            var index = 0;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitLongDelimiterCase3Test1()
        {
            var source = "HELLOWORLDJanHELLOWORLD";
            var delimiter = "HELLOWORLD";
            var index = 1;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitLongDelimiterCase3Test2()
        {
            var source = "HELLOWORLDJanHELLOWORLD";
            var delimiter = "HELLOWORLD";
            var index = 2;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitLongDelimiterCase3Test3()
        {
            var source = "HELLOWORLDJanHELLOWORLD";
            var delimiter = "HELLOWORLD";
            var index = 3;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }


        [Fact]
        public void SplitLongDelimiterCase3Test4()
        {
            var source = "HELLOWORLDJanHELLOWORLD";
            var delimiter = "HELLOWORLD";
            var index = 4;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexOkWord0()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var delimiter = "HELLO";
            var index = 0;
            var expected = JString.WhiteSpace;
            var actual = source.SplitCutRight(delimiter, index, 5);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkWord1()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var delimiter = "HELLO";
            var index = 1;
            var expected = " Mar ";
            var actual = source.SplitCutRight(delimiter, index, 5);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkWord2()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var delimiter = "HELLO";
            var index = 2;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index, 5);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkWord3()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var delimiter = "HELLO";
            var index = 3;
            var expected = "Jan ";
            var actual = source.SplitCutRight(delimiter, index, 5);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkWord4()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var delimiter = "HELLO";
            var index = 4;
            var actual = source.SplitCutRight(delimiter, index, 5);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexOkWord5()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var delimiter = "HELLO";
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index, 5);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord0()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var delimiter = "hello";
            var index = 0;
            var expected = JString.WhiteSpace;
            var actual = source.SplitCutRight(delimiter, index, 5, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord1()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var delimiter = "hello";
            var index = 1;
            var expected = " Mar ";
            var actual = source.SplitCutRight(delimiter, index, 5, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord2()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var delimiter = "hello";
            var index = 2;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index, 5, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord3()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var delimiter = "hello";
            var index = 3;
            var expected = "Jan ";
            var actual = source.SplitCutRight(delimiter, index, 5, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord4()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var delimiter = "hello";
            var index = 4;
            var actual = source.SplitCutRight(delimiter, index, 5, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord5()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var delimiter = "hello";
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index, 5, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWord0()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "hello";
            var index = 0;
            var expected = "MarHELL";
            var actual = source.SplitCutRight(delimiter, index, 6, 25, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWord1()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "hello";
            var index = 1;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index, 6, 25, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWord2()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "hello";
            var index = 2;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index, 6, 25, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWord3()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "hello";
            var index = 3;
            var actual = source.SplitCutRight(delimiter, index, 6, 25, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWord4()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "hello";
            var index = 4;
            var actual = source.SplitCutRight(delimiter, index, 6, 25, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWord0WrongMatchCase()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var delimiter = "hello";
            var index = 0;
            var actual = source.SplitCutRight(delimiter, index, 6, 25, true);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexWrongCaseWord()
        {
            var source = "Jan HELLOFebHELLO Mar HELLO April";
            var actual = source.SplitCutRight("hello", 0, 5);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWrongCaseWord()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var actual = source.SplitCutRight("hello", 0, 5, 25);
            Assert.Null(actual);
        }


        [Fact]
        public void SplitStartNonValidatedStartIndexIII()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var actual = source.SplitCutRight("hello", 0, 25, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartNonValidatedEndIndexII()
        {
            var source = "JanHELLOFebHELLOMarHELLOApril";
            var actual = source.SplitCutRight("hello", 0, 0, 5, false);
            Assert.Null(actual);
        }
    }
}
