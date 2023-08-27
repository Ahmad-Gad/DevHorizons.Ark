namespace DevHorizons.Ark.Test
{
    using Exceptions;
    using TurboCode;

    public class ToRevertedCaseTest
    {
        #region Test Exceptions
        [Fact]
        public void TestToRevertedCaseNull()
        {
            var source = JString.Null;
            var ex = Record.Exception(() => source.ToRevertedCase());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestToRevertedCaseWithEmptyStringExceptionSource()
        {
            string source = string.Empty;
            var ex = Record.Exception(() => source.ToRevertedCase());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            var argumentException = ex as ArgumentException;
            Assert.NotNull(argumentException);
            Assert.Equal("source", argumentException.Origin.Argument);
            Assert.Equal(ArgumentExceptionCode.EmptyString, argumentException.ExceptionCode);
            Assert.Equal((int)ArgumentExceptionCode.EmptyString, argumentException.Code);
        }
        #endregion Test Exceptions

        [Fact]
        public void ToRevertedCase()
        {
            var name = "ahmad adel gad";

            var expected = "AHMAD ADEL GAD";
            var actual = name.ToRevertedCase();
            Assert.Equal(expected, actual);
            Assert.Equal(name, actual.ToRevertedCase());
            
        }

        [Fact]
        public void ToRevertedCasePeriod()
        {
            var name2 = "ahmad.adel.gad";
            var expected = "AHMAD.ADEL.GAD";
            Assert.Equal(expected, name2.ToRevertedCase());
        }

        [Fact]
        public void ToRevertedCasePeriod2()
        {
            var name2 = "..aHmaD..adel...gAD..";
            var expected = "..AhMAd..ADEL...Gad..";
            Assert.Equal(expected, name2.ToRevertedCase());
        }

        [Fact]
        public void ToRevertedCaseOneChar()
        {
            var name = "j";

            var expected = "J";
            var actual = name.ToRevertedCase();
            Assert.Equal(expected, actual);
            Assert.Equal(name, actual.ToRevertedCase());
        }

        [Fact]
        public void ToRevertedCaseOneCharNumber()
        {
            var name = "2";
            var expected = "2";
            var actual = name.ToRevertedCase();
            Assert.Equal(expected, actual);
            Assert.Equal(name, actual.ToRevertedCase());
        }


        [Fact]
        public void ToRevertedCaseOneCharSpecial()
        {
            var name = "@";
            var expected = "@";
            var actual = name.ToRevertedCase();
            Assert.Equal(expected, actual);
            Assert.Equal(name, actual.ToRevertedCase());
        }
    }
}
