namespace DevHorizons.Ark.Test
{
    using Exceptions;
    using TurboCode;

    public class SliceLeftTest
    {
        #region Test Exceptions
        [Fact]
        public void TestSliceLeftNull()
        {
            var source = JString.Null;
            var ex = Record.Exception(() => source.SliceLeft(0, 2));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestSliceLeftEmptyStringStartNotZero()
        {
            var source = string.Empty;
            var ex = Record.Exception(() => source.SliceLeft(1, 1));
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
        public void TestSliceLeftEmptyStringEndNotZero()
        {
            var source = string.Empty;
            var ex = Record.Exception(() => source.SliceLeft(0, 1));
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
            var ex = Record.Exception(() => source.SliceLeft(-1, -1));
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
        public void TestSliceLeftExceptionEndLessThanZero()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.SliceLeft(0, -1));
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
        public void TestSliceLeftExceptionStartGreaterThanEnd()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.SliceLeft(3, 2));
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
        public void TestSliceLeftExceptionStartGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.SliceLeft(source.Length, source.Length));
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
        public void TestSliceLeftExceptionEndtGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.SliceLeft( 0, source.Length));
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
        public void TestSliceLeftOneCharacter()
        {
            var source = "A";
            var expected = "A";
            var actual = source.SliceLeft(0, 0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSliceLeft01()
        {
            var source = "Ahmad Gad";
            var expected = "Ahmad";
            var actual = source.SliceLeft(0, 4);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestSliceLeft02()
        {
            var source = "Ahmad Gad";
            var expected = JString.WhiteSpace;
            var actual = source.SliceLeft(5, 5);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSliceLeft03()
        {
            var source = "Ahmad Gad";
            var expected = "Gad";
            var actual = source.SliceLeft(6, 8);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSliceLeft04()
        {
            var source = "Ahmad Gad";
            var expected = "Gad";
            var actual = source.SliceLeft(6, source.Length - 1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSliceLeft05()
        {
            var source = "Ahmad Adel Gad";
            var expected = "Adel";
            var actual = source.SliceLeft(6, 9);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSliceLeft06()
        {
            var source = "Ahmad Adel Gad";
            var expected = "A";
            var actual = source.SliceLeft(0, 0);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestSliceLeft07()
        {
            var source = "Ahmad Adel Gad";
            var expected = "Ah";
            var actual = source.SliceLeft(0, 1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSliceRight08()
        {
            var source = "Ahmad Adel";
            var expected = "Ahmad Adel";
            var actual = source.SliceLeft(0, 9);
            Assert.Equal(expected, actual);
        }
    }
}
