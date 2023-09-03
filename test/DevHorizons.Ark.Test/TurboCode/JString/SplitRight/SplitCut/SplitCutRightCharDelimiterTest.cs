namespace DevHorizons.Ark.Test
{
    using System.Globalization;
    using Exceptions;
    using TurboCode;

    public class SplitCutRightCharDelimiterTest
    {
        #region Test Exceptions
        [Fact]
        public void TestSplitWithNullExceptionSource()
        {
            string source = null;
            char delimiter = Character.WhiteSpace;
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
            char delimiter = Character.WhiteSpace;
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
            char delimiter = Character.Null;
            var ex = Record.Exception(() => source.SplitCutRight(delimiter, 0));
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
            var ex = Record.Exception(() => source.SplitCutRight(Character.WhiteSpace, 0));
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
            var ex = Record.Exception(() => source.SplitCutRight(Character.WhiteSpace,0, 1, 2));
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
        public void TestSplitExceptionEndLessThanZero()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.WhiteSpace;
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
        public void TestSplitExceptionStartGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.WhiteSpace;
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
        public void TestSplitExceptionEndtGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.WhiteSpace;
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
        public void TestSplitExceptionStartGreaterThanEnd()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.WhiteSpace;
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

        [Fact]
        public void TestSplitExceptionIndexLessThanZero()
        {
            string source = "Ahmad Gad";
            var delimiter = Character.WhiteSpace;
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
        #endregion Test Exceptions

        [Fact]
        public void SplitWhiteSpace0()
        {
            var source = "Jan Feb Mar April";
            var delimiter = Character.WhiteSpace;
            var index = 0;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitWhiteSpace1()
        {
            var source = "Jan Feb Mar April";
            var delimiter = Character.WhiteSpace;
            var index = 1;
            var expected = "Mar";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitWhiteSpace2()
        {
            var source = "Jan Feb Mar April";
            var delimiter = Character.WhiteSpace;
            var index = 2;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitWhiteSpace3()
        {
            var source = "Jan Feb Mar April";
            var delimiter = Character.WhiteSpace;
            var index = 3;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitWhiteSpace4()
        {
            var source = "Jan Feb Mar April";
            var delimiter = Character.WhiteSpace;
            var index = 4;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitWhiteSpace5()
        {
            var source = "Jan Feb Mar April";
            var delimiter = Character.WhiteSpace;
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitWhiteSpace6()
        {
            var source = "Jan Feb Mar April";
            var delimiter = Character.WhiteSpace;
            var index = 6;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitNonMatchigCaseDelimiter0()
        {
            var source = "JanZFebZMarZApril";
            var delimiter = 'z';
            var index = 0;
            var actual = source.SplitCutRight(delimiter, index, true);

            Assert.Null(actual);
        }

        [Fact]
        public void SplitNonMatchigCaseDelimiter1()
        {
            var source = "JanZFebZMarZApril";
            var delimiter = 'z';
            var index = 1;
            var actual = source.SplitCutRight(delimiter, index, true);

            Assert.Null(actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseDelimiter0()
        {
            var source = "JanZFebZMarZApril";
            var delimiter = 'z';
            var index = 0;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index, false, CultureInfo.InvariantCulture);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseDelimiter1()
        {
            var source = "JanZFebZMarZApril";
            var delimiter = 'z';
            var index = 1;
            var expected = "Mar";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseDelimiter2()
        {
            var source = "JanZFebZMarZApril";
            var delimiter = 'z';
            var index = 2;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseDelimiter3()
        {
            var source = "JanZFebZMarZApril";
            var delimiter = 'z';
            var index = 3;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseDelimiter4()
        {
            var source = "JanZFebZMarZApril";
            var delimiter = 'z';
            var index = 4;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseDelimiter5()
        {
            var source = "JanZFebZMarZApril";
            var delimiter = 'z';
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitMatchigIgnoreCaseDelimiter6()
        {
            var source = "JanZFebZMarZApril";
            var delimiter = 'z';
            var index = 6;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining0()
        {
            var source = "ZJanZFebZMarZApril";
            var delimiter = 'Z';
            var index = 0;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining1()
        {
            var source = "ZJanZFebZMarZApril";
            var delimiter = 'Z';
            var index = 1;
            var expected = "Mar";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining2()
        {
            var source = "ZJanZFebZMarZApril";
            var delimiter = 'Z';
            var index = 2;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining3()
        {
            var source = "ZJanZFebZMarZApril";
            var delimiter = 'Z';
            var index = 3;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining4()
        {
            var source = "ZJanZFebZMarZApril";
            var delimiter = 'Z';
            var index = 4;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining5()
        {
            var source = "ZJanZFebZMarZApril";
            var delimiter = 'Z';
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtBegining6()
        {
            var source = "ZJanZFebZMarZApril";
            var delimiter = 'Z';
            var index = 6;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtEnd0()
        {
            var source = "JanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 0;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtEnd1()
        {
            var source = "JanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 1;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtEnd2()
        {
            var source = "JanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 2;
            var expected = "Mar";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtEnd3()
        {
            var source = "JanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 3;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void SplitDelimiterAtEnd4()
        {
            var source = "JanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 4;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtEnd5()
        {
            var source = "JanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtEnd6()
        {
            var source = "JanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 6;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd0()
        {
            var source = "ZJanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 0;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd1()
        {
            var source = "ZJanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 1;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd2()
        {
            var source = "ZJanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 2;
            var expected = "Mar";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd3()
        {
            var source = "ZJanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 3;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd4()
        {
            var source = "ZJanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 4;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd5()
        {
            var source = "ZJanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 5;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd6()
        {
            var source = "ZJanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 6;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd7()
        {
            var source = "ZJanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 7;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterAtBeginingAndEnd100()
        {
            var source = "ZJanZFebZMarZAprilZ";
            var delimiter = 'Z';
            var index = 100;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitRedundantDelimiter0()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var delimiter = 'Z';
            var index = 0;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter1()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var delimiter = 'Z';
            var index = 1;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter2()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var delimiter = 'Z';
            var index = 2;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter3()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var delimiter = 'Z';
            var index = 3;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter4()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var delimiter = 'Z';
            var index = 4;
            var expected = "Mar";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void SplitRedundantDelimiter5()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var delimiter = 'Z';
            var index = 5;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter6()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var delimiter = 'Z';
            var index = 6;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter7()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var delimiter = 'Z';
            var index = 7;
            var expected = "Jan";
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter8()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var delimiter = 'Z';
            var index = 8;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter9()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var delimiter = 'Z';
            var index = 9;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter10()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var delimiter = 'Z';
            var index = 10;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitRedundantDelimiter11()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var delimiter = 'Z';
            var index = 11;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitRedundantDelimiter12()
        {
            var source = "ZZZJanZFebZZMarZAprilZZZ";
            var delimiter = 'Z';
            var index = 12;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnly0()
        {
            var source = "Z";
            var delimiter = source.ToChar();
            var index = 0;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterOnly1()
        {
            var source = "Z";
            var delimiter = source.ToChar();
            var index = 1;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterOnly2()
        {
            var source = "Z";
            var delimiter = source.ToChar();
            var index = 2;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnly3()
        {
            var source = "Z";
            var delimiter = source.ToChar();
            var index = 3;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyIgnoreCase0()
        {
            var source = "Z";
            var delimiter = source.ToLower().ToChar();
            var index = 0;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterOnlyIgnoreCase1()
        {
            var source = "Z";
            var delimiter = source.ToLower().ToChar();
            var index = 1;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterOnlyIgnoreCase2()
        {
            var source = "Z";
            var delimiter = source.ToLower().ToChar();
            var index = 2;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyIgnoreCase3()
        {
            var source = "Z";
            var delimiter = source.ToLower().ToChar();
            var index = 3;
            var actual = source.SplitCutRight(delimiter, index, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyNotMatch0()
        {
            var source = "Z";
            var delimiter = source.ToLower().ToChar();
            var index = 0;
            var actual = source.SplitCutRight(delimiter, index, true);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyNotMatch1()
        {
            var source = "Z";
            var delimiter = source.ToLower().ToChar();
            var index = 1;
            var actual = source.SplitCutRight(delimiter, index, true);
            Assert.Null(actual);
        }


        [Fact]
        public void SplitDelimiterOnlyNotMatch100()
        {
            var source = "Z";
            var delimiter = source.ToLower().ToChar();
            var index = 100;
            var actual = source.SplitCutRight(delimiter, index, true);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyWhiteSpace0()
        {
            var source = JString.WhiteSpace;
            var delimiter = Character.WhiteSpace;
            var index = 0;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterOnlyWhiteSpace1()
        {
            var source = JString.WhiteSpace;
            var delimiter = Character.WhiteSpace;
            var index = 1;
            var expected = string.Empty;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitDelimiterOnlyWhiteSpace2()
        {
            var source = JString.WhiteSpace;
            var delimiter = Character.WhiteSpace;
            var index = 2;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitDelimiterOnlyWhiteSpace3()
        {
            var source = JString.WhiteSpace;
            var delimiter = Character.WhiteSpace;
            var index = 3;
            var actual = source.SplitCutRight(delimiter, index);
            Assert.Null(actual);
        }


        [Fact]
        public void SplitStartIndexOkWord0()
        {
            var source = "Jan ZFebZ Mar Z April";
            var delimiter = 'Z';
            var index = 0;
            var expected = JString.WhiteSpace;
            var actual = source.SplitCutRight(delimiter, index, 5);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkWord1()
        {
            var source = "Jan ZFebZ Mar Z April";
            var delimiter = 'Z';
            var index = 1;
            var expected = " Mar ";
            var actual = source.SplitCutRight(delimiter, index, 5);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkWord2()
        {
            var source = "Jan ZFebZ Mar Z April";
            var delimiter = 'Z';
            var index = 2;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index, 5);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkWord3()
        {
            var source = "Jan ZFebZ Mar Z April";
            var delimiter = 'Z';
            var index = 3;
            var expected = "Jan ";
            var actual = source.SplitCutRight(delimiter, index, 5);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkWord4()
        {
            var source = "Jan ZFebZ Mar Z April";
            var delimiter = 'Z';
            var index = 4;
            var actual = source.SplitCutRight(delimiter, index, 5);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexOkWord5()
        {
            var source = "Jan ZFebZ Mar Z April";
            var delimiter = 'Z';
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index, 5);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord0()
        {
            var source = "Jan ZFebZ Mar Z April";
            var delimiter = 'z';
            var index = 0;
            var expected = JString.WhiteSpace;
            var actual = source.SplitCutRight(delimiter, index, 5, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord1()
        {
            var source = "Jan ZFebZ Mar Z April";
            var delimiter = 'z';
            var index = 1;
            var expected = " Mar ";
            var actual = source.SplitCutRight(delimiter, index, 5, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord2()
        {
            var source = "Jan ZFebZ Mar Z April";
            var delimiter = 'z';
            var index = 2;
            var expected = "Feb";
            var actual = source.SplitCutRight(delimiter, index, 5, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord3()
        {
            var source = "Jan ZFebZ Mar Z April";
            var delimiter = 'z';
            var index = 3;
            var expected = "Jan ";
            var actual = source.SplitCutRight(delimiter, index, 5, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord4()
        {
            var source = "Jan ZFebZ Mar Z April";
            var delimiter = 'z';
            var index = 4;
            var actual = source.SplitCutRight(delimiter, index, 5, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexOkIgnoreCaseWord5()
        {
            var source = "Jan ZFebZ Mar Z April";
            var delimiter = 'z';
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index, 5, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWord0()
        {
            var source = "JanZFebZMarZAprilZMayZJuneZJulyZAugust";
            var delimiter = 'z';
            var index = 0;
            var expected = "A";
            var actual = source.SplitCutRight(delimiter, index, 5, 25, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWord1()
        {
            var source = "JanZFebZMarZAprilZMayZJuneZJulyZAugust";
            var delimiter = 'z';
            var index = 1;
            var expected = "July";
            var actual = source.SplitCutRight(delimiter, index, 5, 25, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWord2()
        {
            var source = "JanZFebZMarZAprilZMayZJuneZJulyZAugust";
            var delimiter = 'z';
            var index = 2;
            var expected = "June";
            var actual = source.SplitCutRight(delimiter, index, 5, 25, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWord3()
        {
            var source = "JanZFebZMarZAprilZMayZJuneZJulyZAugust";
            var delimiter = 'z';
            var index = 3;
            var expected = "May";
            var actual = source.SplitCutRight(delimiter, index, 5, 25, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWord4()
        {
            var source = "JanZFebZMarZAprilZMayZJuneZJulyZAugust";
            var delimiter = 'z';
            var index = 4;
            var expected = "April";
            var actual = source.SplitCutRight(delimiter, index, 5, 25, false);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWord5()
        {
            var source = "JanZFebZMarZAprilZMayZJuneZJulyZAugust";
            var delimiter = 'z';
            var index = 5;
            var actual = source.SplitCutRight(delimiter, index, 5, 25, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWord6()
        {
            var source = "JanZFebZMarZAprilZMayZJuneZJulyZAugust";
            var delimiter = 'z';
            var index = 6;
            var actual = source.SplitCutRight(delimiter, index, 5, 25, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWordWrongMatchCase()
        {
            var source = "JanZFebZMarZAprilZMayZJuneZJulyZAugust";
            var delimiter = 'z';
            var index = 0;
            var actual = source.SplitCutRight(delimiter, index, 5, 25, true);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexWrongCaseWord()
        {
            var source = "Jan ZFebZ Mar Z April";
            var actual = source.SplitCutRight('z', 0, 5);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartIndexEndIndexWrongCaseWord()
        {
            var source = "JanZFebZMarZAprilZMayZJuneZJulyZAugust";
            var actual = source.SplitCutRight('z', 0, 5, 25);
            Assert.Null(actual);
        }


        [Fact]
        public void SplitStartNonValidatedStartIndexIII()
        {
            var source = "JanZFebZMarZAprilZMayZJuneZJulyZAugust";
            var actual = source.SplitCutRight('O', 0, 25, false);
            Assert.Null(actual);
        }

        [Fact]
        public void SplitStartNonValidatedEndIndexII()
        {
            var source = "JanZFebZMarZAprilZMayZJuneZJulyZAugust";
            var actual = source.SplitCutRight('M', 0, 0, 5, false);
            Assert.Null(actual);
        }
    }
}
