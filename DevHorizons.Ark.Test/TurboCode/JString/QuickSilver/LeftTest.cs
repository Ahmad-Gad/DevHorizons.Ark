namespace DevHorizons.Ark.Test
{
    using Exceptions;
    using TurboCode;

    public class LeftTest
    {
        #region Test Exceptions
        [Fact]
        public void TestLeftNull()
        {
            var source = JString.Null;
            var ex = Record.Exception(() => source.Left(2));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestLeftEmptyStringLengthNotOne()
        {
            var source = string.Empty;
            var ex = Record.Exception(() => source.Left(2));
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
            var ex = Record.Exception(() => source.Left(0));
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
            var ex = Record.Exception(() => source.Left(-1));
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
        public void TestLeftExceptionLengthGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.Left(source.Length + 1));
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
        public void TestLeftOneCharacter()
        {
            var source = "A";
            var expected = "A";
            var actual = source.Left(1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLeft01()
        {
            var source = "Ahmad Gad";
            var expected = "Ahmad";
            var actual = source.Left(5);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestLeft02()
        {
            var source = "Ahmad Gad";
            var expected = source;
            var actual = source.Left(source.Length);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLeft03()
        {
            var source = "Ahmad Gad";
            var expected = "Ahmad ";
            var actual = source.Left(6);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLeft05()
        {
            var source = "Ahmad Adel Gad";
            var expected = "Ahmad Ade";
            var actual = source.Left(9);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLeft06()
        {
            var source = "Ahmad Adel Gad";
            var expected = "A";
            var actual = source.Left(1);
            Assert.Equal(expected, actual);
        }
    }
}
