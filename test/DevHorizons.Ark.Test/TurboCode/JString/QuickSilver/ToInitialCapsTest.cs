namespace DevHorizons.Ark.Test
{
    using Exceptions;
    using TurboCode;

    public class ToInitialCapsTest
    {
        #region Test Exceptions
        [Fact]
        public void TestToInitialCapsNull()
        {
            var source = JString.Null;
            var ex = Record.Exception(() => source.ToInitialCaps());
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestToInitialCapsWithEmptyStringExceptionSource()
        {
            string source = string.Empty;
            var ex = Record.Exception(() => source.ToInitialCaps());
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
        public void ToInitialCaps()
        {
            var name = "ahmad adel gad";
            var name2 = "ahmad Adel GAD";

            var expected = "Ahmad Adel Gad";
            var actual = name.ToInitialCaps();
            Assert.True(actual.Equals(name2.ToInitialCaps()));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInitialCapsSingleQuote()
        {
            var name2 = "AHMAD Adel GAD's son";

            var expected = "Ahmad Adel Gad's Son";
            Assert.Equal(expected, name2.ToInitialCaps());
        }

        [Fact]
        public void ToInitialCapsPeriod()
        {
            var name2 = "ahmad.adel.gad";
            var expected = "Ahmad.Adel.Gad";
            Assert.Equal(expected, name2.ToInitialCaps());
        }

        [Fact]
        public void ToInitialCapsNumbers()
        {
            var name2 = "ahmad1adel2gad";
            var expected = "Ahmad1adel2gad";
            Assert.Equal(expected, name2.ToInitialCaps());
        }

        [Fact]
        public void ToInitialCapsSpecialCharacters()
        {
            var name2 = "jan!feb@mar#apr$may%jun^jul&auG*sep(Oct)noV-dec_JAN=feb+mar.apR?may/jun\\Jul|aug{sep}oct[nov]dec:jan;feb\"mar<apr>may~juN`jUl" + $"{Character.EuroSign}aUg{Character.BritishPoundSign}Sep{Character.CopyrightSign}ocT{Character.YenSign}NOV{Character.Bullet}dEC";
            var expected = "Jan!Feb@Mar#Apr$May%Jun^Jul&Aug*Sep(Oct)Nov-Dec_Jan=Feb+Mar.Apr?May/Jun\\Jul|Aug{Sep}Oct[Nov]Dec:Jan;Feb\"Mar<Apr>May~Jun`Jul" + $"{Character.EuroSign}Aug{Character.BritishPoundSign}Sep{Character.CopyrightSign}Oct{Character.YenSign}Nov{Character.Bullet}Dec";
            Assert.Equal(expected, name2.ToInitialCaps());
        }

        [Fact]
        public void ToInitialCapsPeriod2()
        {
            var name2 = "..ahmad..adel...gad..";
            var expected = "..Ahmad..Adel...Gad..";
            Assert.Equal(expected, name2.ToInitialCaps());
        }

        [Fact]
        public void ToInitialCapsSingleSpecialChars()
        {
            var name2 = "ahmad Adel GAD's@son";

            var expected = "Ahmad Adel Gad's@Son";
            Assert.Equal(expected, name2.ToInitialCaps());
        }


        [Fact]
        public void ToInitialCapsOneChar()
        {
            var name = "j";
            var name2 = "J";

            var expected = "J";
            var actual = name.ToInitialCaps();
            Assert.True(actual.Equals(name2.ToInitialCaps()));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInitialCapsOneCharNumber()
        {
            var name = "2";
            var name2 = "2";

            var expected = "2";
            var actual = name.ToInitialCaps();
            Assert.True(actual.Equals(name2.ToInitialCaps()));
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void ToInitialCapsOneCharSpecial()
        {
            var name = "@";
            var name2 = "@";

            var expected = "@";
            var actual = name.ToInitialCaps();
            Assert.True(actual.Equals(name2.ToInitialCaps()));
            Assert.Equal(expected, actual);
        }
    }
}
