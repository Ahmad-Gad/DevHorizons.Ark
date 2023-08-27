namespace DevHorizons.Ark.Test
{
    using Exceptions;
    using TurboCode;

    public class SliceTest
    {
        #region Test Exceptions
        [Fact]
        public void TestSliceNull()
        {
            var source = JString.Null;
            var ex = Record.Exception(() => source.Slice(0, 2));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestSliceEmptyStringStartNotZero()
        {
            var source = string.Empty;
            var ex = Record.Exception(() => source.Slice(1, 1));
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
        public void TestSliceEmptyStringEndNotZero()
        {
            var source = string.Empty;
            var ex = Record.Exception(() => source.Slice(0, 1));
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
        public void TestSpliceExceptionStartLessThanZero()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.Slice(-1, -1));
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
        public void TestSliceExceptionEndLessThanZero()
        {
            string source = "Ahmad Gad";
            char delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.Slice(0, -1));
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
        public void TestSliceExceptionStartGreaterThanEnd()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.Slice(3, 2));
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
        public void TestSliceExceptionStartGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.Slice(source.Length, source.Length));
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
        public void TestSliceExceptionEndtGreaterThanLengthOfSource()
        {
            string source = "Ahmad Gad";
            var ex = Record.Exception(() => source.Slice( 0, source.Length));
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
        public void TestSliceOneCharacter()
        {
            var source = "A";
            var expected = "A";
            var actual = source.Slice(0, 0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSlice01()
        {
            var source = "Ahmad Gad";
            var expected = "Ahmad";
            var actual = source.Slice(0, 4);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestSlice02()
        {
            var source = "Ahmad Gad";
            var expected = JString.WhiteSpace;
            var actual = source.Slice(5, 5);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSlice03()
        {
            var source = "Ahmad Gad";
            var expected = "Gad";
            var actual = source.Slice(6, 8);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSlice04()
        {
            var source = "Ahmad Gad";
            var expected = "Gad";
            var actual = source.Slice(6, source.Length - 1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSlice05()
        {
            var source = "Ahmad Adel Gad";
            var expected = "Adel";
            var actual = source.Slice(6, 9);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSlice06()
        {
            var source = "Ahmad Adel Gad";
            var expected = "A";
            var actual = source.Slice(0, 0);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestSlice07()
        {
            var source = "Ahmad Adel Gad";
            var expected = "Ah";
            var actual = source.Slice(0, 1);
            Assert.Equal(expected, actual);
        }
    }
}
