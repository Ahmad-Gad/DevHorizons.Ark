namespace DevHorizons.Ark.Test
{
    using Exceptions;
    using TurboCode;

    public class SliceRightTest
    {
        #region Test Exceptions
        [Fact]
        public void TestSliceRightNull()
        {
            var source = JString.Null;
            var ex = Record.Exception(() => source.SliceRight(0, 2));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestSliceRightEmptyStringStartNotZero()
        {
            var source = string.Empty;
            var ex = Record.Exception(() => source.SliceRight(1, 1));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("source", argumentException.Origin.Argument);
            Assert.Equal("start", argumentException.ConflictArguement);
            var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument | ArgumentExceptionCode.EmptyString;
            Assert.Equal(exceptionCode, argumentException.ExceptionCode);
            Assert.Equal((int)exceptionCode, argumentException.Code);
        }

        [Fact]
        public void TestSliceRightEmptyStringEndNotZero()
        {
            var source = string.Empty;
            var ex = Record.Exception(() => source.SliceRight(0, 1));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("source", argumentException.Origin.Argument);
            Assert.Equal("end", argumentException.ConflictArguement);
            var exceptionCode = ArgumentExceptionCode.OutRange | ArgumentExceptionCode.ConflictWithOtherArgument | ArgumentExceptionCode.EmptyString;
            Assert.Equal(exceptionCode, argumentException.ExceptionCode);
            Assert.Equal((int)exceptionCode, argumentException.Code);
        }

        [Fact]
        public void TestSliceExceptionStartLessThanZero()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.SliceRight(-1, -1));
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
        public void TestSliceRightExceptionEndLessThanZero()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.SliceRight(0, -1));
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
        public void TestSliceRightExceptionStartGreaterThanEnd()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.SliceRight(3, 2));
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
        public void TestSliceRightExceptionStartGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.SliceRight(source.Length, source.Length));
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
        public void TestSliceRightExceptionEndtGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.SliceRight( 0, source.Length));
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
        #endregion Test Exceptions

        [Fact]
        public void TestSliceRightOneCharacter()
        {
            var source = "A";
            var expected = "A";
            var actual = source.SliceRight(0, 0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSliceRight01()
        {
            var source = "Ahmad Gad";
            var expected = "d Gad";
            var actual = source.SliceRight(0, 4);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestSliceRight02()
        {
            var source = "Ahmad Gad";
            var expected = JString.WhiteSpace;
            var actual = source.SliceRight(3, 3);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSliceRight03()
        {
            var source = "Ahmad Gad";
            var expected = "Ahmad";
            var actual = source.SliceRight(4, 8);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSliceRight04()
        {
            var source = "Ahmad Gad";
            var expected = "Ahm";
            var actual = source.SliceRight(6, source.Length - 1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSliceRight05()
        {
            var source = "Ahmad Adel Gad";
            var expected = "Adel";
            var actual = source.SliceRight(4, 7);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSliceRight06()
        {
            var source = "Ahmad Adel Gad";
            var expected = "d";
            var actual = source.SliceRight(0, 0);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestSliceRight07()
        {
            var source = "Ahmad Adel Gad";
            var expected = "ad";
            var actual = source.SliceRight(0, 1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSliceRight08()
        {
            var source = "Ahmad Adel";
            var expected = "Ahmad Adel";
            var actual = source.SliceRight(0, 9);
            Assert.Equal(expected, actual);
        }
    }
}
