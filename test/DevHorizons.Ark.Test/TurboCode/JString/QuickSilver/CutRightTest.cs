namespace DevHorizons.Ark.Test
{
    using Exceptions;
    using TurboCode;

    public class CutRightTest
    {
        #region Test Exceptions
        [Fact]
        public void TestCutRightNull()
        {
            var source = JString.Null;
            var ex = Record.Exception(() => source.CutRight(0, 2));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestCutExceptionStartLessThanZero()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.CutRight(-1, 3));
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
        public void TestCutRightExceptionlengthLessThanZero()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.CutRight(0, -1));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("length", argumentException.Origin.Argument);
            Assert.Null(argumentException.ConflictArguement);
            var expectedErrorCode = ArgumentExceptionCode.OutRange;
            Assert.Equal(expectedErrorCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedErrorCode, argumentException.Code);
        }


        [Fact]
        public void TestCutRightExceptionStartPlusLengthGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.CutRight(5, 10));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("startIndex", argumentException.Origin.Argument);
            Assert.NotNull(argumentException.ConflictArguement);
            Assert.Equal("length", argumentException.ConflictArguement);
            var expectedErrorCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
            Assert.Equal(expectedErrorCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedErrorCode, argumentException.Code);
        }

        [Fact]
        public void TestCutRightExceptionStartGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.CutRight(10, 2));
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
            var ex = Record.Exception(() => source.CutRight(1, 1));
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
            var actual = source.CutRight(0, 0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRightOneCharacterLengthZero()
        {
            var source = "A";
            var expected = string.Empty;
            var actual = source.CutRight(0, 0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRightOneCharacter()
        {
            var source = "A";
            var expected = "A";
            var actual = source.CutRight(0, 1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRight01()
        {
            var source = "Ahmad Gad";
            var expected = " Gad";
            var actual = source.CutRight(0, 4);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestCutRight02()
        {
            var source = "Ahmad Gad";
            var expected = "ad ";
            var actual = source.CutRight(3, 3);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRight03()
        {
            var source = "Ahmad Gad";
            var expected = JString.WhiteSpace;
            var actual = source.CutRight(3, 1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRight04()
        {
            var source = "Ahmad Gad";
            var expected = "Ahmad";
            var actual = source.CutRight(4, 5);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRight05()
        {
            var source = "Ahmad Adel Gad";
            var expected = "Adel";
            var actual = source.CutRight(4, 4);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRight06()
        {
            var source = "Ahmad Adel Gad";
            var expected = "d";
            var actual = source.CutRight(0, 1);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestCutRight07()
        {
            var source = "Ahmad Adel Gad";
            var expected = "Gad";
            var actual = source.CutRight(0, 3);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRight08()
        {
            var source = "Ahmad Adel";
            var expected = "Ahmad Adel";
            var actual = source.CutRight(0, 10);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRight09()
        {
            var source = "Ahmad Adel";
            var expected = string.Empty;
            var actual = source.CutRight(3, 0);
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
            var expected = "جاد";
            var actual = source.CutRight(0, 3);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRightArabic02()
        {
            var source = "أحمد عادل جاد";
            var expected = "عادل";
            var actual = source.CutRight(4, 4);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCutRightArabic03()
        {
            var source = "أحمد عادل جاد";
            var expected = "أحمد";
            var actual = source.CutRight(9, 4);
            Assert.Equal(expected, actual);
        }
    }
}
