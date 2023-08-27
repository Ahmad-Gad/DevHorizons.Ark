namespace DevHorizons.Ark.Test
{
    using System.Globalization;
    using TurboCode;
    using Validation;

    public class JStringTest
    {
        #region String Properties
        [Fact]
        public void CrLfStringProperty()
        {
            Assert.Equal("\r\n", JString.CrLf);
        }

        [Fact]
        public void WhiteSpaceStringProperty()
        {
            Assert.Equal(" ", JString.WhiteSpace);
        }

        [Fact]
        public void HorizontalTabStringProperty()
        {
            Assert.Equal("\t", JString.HorizontalTab);
        }
        #endregion String Properties

        #region Validation
        [Fact]
        public void IsUpperCaseStringTrue()
        {
            var source = "AHMAD GAD";
            var expected = true;
            var actual = source.IsUpper();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsUpperCaseStringFalse()
        {
            var source = "Ahmad Gad";
            var expected = false;
            var actual = source.IsUpper();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsLowerCaseStringTrue()
        {
            var source = "ahmad gad";
            var expected = true;
            var actual = source.IsLower();
            Assert.Equal(expected, actual);

            actual = source.IsLower(CultureInfo.InvariantCulture);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsLowerCaseStringFalse()
        {
            var source = "Ahmad Gad";
            var expected = false;
            var actual = source.IsLower();
            Assert.Equal(expected, actual);

            actual = source.IsLower(CultureInfo.InvariantCulture);
            Assert.Equal(expected, actual);
        }
        #endregion Validation

        #region Convert
        [Fact]
        public void ToSafeStringProperty()
        {
            var source = "Ahmad Gad";
            var expected = "Ahmad Gad";
            var actual = source.ToStringOrEmptyString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToSafeStringFromNullProperty()
        {
            var source = default(string);
            var expected = string.Empty;
            var actual = source.ToStringOrEmptyString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToSafeStringFromNullDefaultValueProperty()
        {
            var source = default(string);
            var expected = "Ahmad Gad";
            var actual = source.ToSafeString("Ahmad Gad");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToSafeStringFromTrueBooleanProperty()
        {
            var source = true;
            var expected = "True";
            var actual = source.ToStringOrEmptyString();
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void ToSafeStringFromFalseBooleanProperty()
        {
            var source = false;
            var expected = "False";
            var actual = source.ToStringOrEmptyString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToSafeStringFromTrueBooleanDefaultValueProperty()
        {
            var source = true;
            var expected = "True";
            var actual = source.ToSafeString("any thing");
            Assert.Equal(expected, actual);
        }
        #endregion Convert

        #region Quick Manipulation
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
            var name2 = "ahmad Adel GAD's son";

            var expected = "Ahmad Adel Gad's Son";
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
        public void ToInitialCapsNullOrEmpty()
        {
            string name = null;
            var name2 = string.Empty;

            Assert.Null(name.ToInitialCaps());
            Assert.Equal(string.Empty, name2.ToInitialCaps());
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
        #endregion Quick Manipulation
    }
}
