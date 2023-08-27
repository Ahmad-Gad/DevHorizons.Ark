namespace DevHorizons.Ark.Test
{
    using Exceptions;
    using TurboCode;

    public class RightTest
    {
        #region Test Exceptions
        [Fact]
        public void TestRightNull()
        {
            var source = JString.Null;
            var ex = Record.Exception(() => source.Right(2));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestRightEmptyStringLengthNotOne()
        {
            var source = string.Empty;
            var ex = Record.Exception(() => source.Right(2));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("source", argumentException.Origin.Argument);
            Assert.Equal("length", argumentException.ConflictArguement);
            var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument | ArgumentExceptionCode.EmptyString;
            Assert.Equal(exceptionCode, argumentException.ExceptionCode);
            Assert.Equal((int)exceptionCode, argumentException.Code);
        }


        [Fact]
        public void TestSpliceExceptionLengthEqualZero()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.Right(0));
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
        public void TestSpliceExceptionLengthEqualLessZanZero()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.Right(-1));
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
        public void TestRightExceptionLengthGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.Right(source.Length + 1));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("length", argumentException.Origin.Argument);
            Assert.NotNull(argumentException.ConflictArguement);
            Assert.Equal("source", argumentException.ConflictArguement);
            var expectedErrorCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument;
            Assert.Equal(expectedErrorCode, argumentException.ExceptionCode);
            Assert.Equal((int)expectedErrorCode, argumentException.Code);
        }
        #endregion Test Exceptions

        [Fact]
        public void TestRightOneCharacter()
        {
            var source = "A";
            var expected = "A";
            var actual = source.Right(1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRight01()
        {
            var source = "Ahmad Gad";
            var expected = "d Gad";
            var actual = source.Right(5);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestRight02()
        {
            var source = "Ahmad Gad";
            var expected = source;
            var actual = source.Right(source.Length);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRight03()
        {
            var source = "Ahmad Gad";
            var expected = "ad Gad";
            var actual = source.Right(6);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRight05()
        {
            var source = "Ahmad Adel Gad";
            var expected = "Adel Gad";
            var actual = source.Right(8);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRight06()
        {
            var source = "Ahmad Adel Gad";
            var expected = "Gad";
            var actual = source.Right(3);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRight07()
        {
            var source = "Ahmad Adel Gad";
            var expected = "d";
            var actual = source.Right(1);
            Assert.Equal(expected, actual);
        }
    }
}
