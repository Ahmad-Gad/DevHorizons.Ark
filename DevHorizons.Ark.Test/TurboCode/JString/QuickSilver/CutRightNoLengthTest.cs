namespace DevHorizons.Ark.Test
{
    using Exceptions;
    using TurboCode;

    public class CutRightNoLengthTest
    {
        #region Test Exceptions
        [Fact]
        public void TestCutRightNull()
        {
            var source = JString.Null;
            var ex = Record.Exception(() => source.CutRight(0));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestCutExceptionStartLessThanZero()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.CutRight(-1));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("startIndex", argumentException.Origin.Argument);
            Assert.Null(argumentException.ConflictArguement);
            var expectedErrorCode = ArgumentExceptionCode.OutRange;
            Assert.Equal(expectedErrorCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedErrorCode, argumentException.Code);
        }


        [Fact]
        public void TestCutRightExceptionStartGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.CutRight(10));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("startIndex", argumentException.Origin.Argument);
            Assert.NotNull(argumentException.ConflictArguement);
            Assert.Equal("source", argumentException.ConflictArguement);
            var expectedErrorCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
            Assert.Equal(expectedErrorCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedErrorCode, argumentException.Code);
        }

        [Fact]
        public void TestCutRightExceptionStartGreaterThanLengthOfSource2()
        {
            string source = string.Empty;
            var ex = Record.Exception(() => source.CutRight(1));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("startIndex", argumentException.Origin.Argument);
            Assert.NotNull(argumentException.ConflictArguement);
            Assert.Equal("source", argumentException.ConflictArguement);
            var expectedErrorCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
            Assert.Equal(expectedErrorCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedErrorCode, argumentException.Code);
        }
        #endregion Test Exceptions

        [Fact]
        public void TestCutRightSourceEmptyString()
        {
            var source = string.Empty;
            var expected = string.Empty;
            var actual = source.CutRight(0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRightOneCharacter()
        {
            var source = "A";
            var expected = "A";
            var actual = source.CutRight(0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRight01()
        {
            var source = "Ahmad Gad";
            var expected = "Ahmad Gad";
            var actual = source.CutRight(0);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestCutRight02()
        {
            var source = "Ahmad Gad";
            var expected = "Ahmad Ga";
            var actual = source.CutRight(1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRight03()
        {
            var source = "Ahmad Gad";
            var expected = "Ahmad G";
            var actual = source.CutRight(2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRight04()
        {
            var source = "Ahmad Gad";
            var expected = "A";
            var actual = source.CutRight(source.Length - 1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRightArabic00()
        {
            var source = "أحمد عادل جاد";
            var expected = string.Empty;
            var actual = source.CutRight(0, 0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRightArabic01()
        {
            var source = "أحمد عادل جاد";
            var expected = "أحمد عادل جاد";
            var actual = source.CutRight(0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRightArabic02()
        {
            var source = "أحمد عادل جاد";
            var expected = "أحمد عادل";
            var actual = source.CutRight(4);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRightArabic03()
        {
            var source = "أحمد عادل جاد";
            var expected = "أحمد";
            var actual = source.CutRight(9);
            Assert.Equal(expected, actual);
        }
    }
}
