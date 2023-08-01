namespace DevHorizons.Ark.Test
{
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
        }

        [Fact]
        public void IsLowerCaseStringFalse()
        {
            var source = "Ahmad Gad";
            var expected = false;
            var actual = source.IsLower();
            Assert.Equal(expected, actual);
        }
        #endregion Validation

        #region Convert
        [Fact]
        public void ToSafeStringProperty()
        {
            var source = "Ahmad Gad";
            var expected = "Ahmad Gad";
            var actual = source.ToSafeString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToSafeStringFromNullProperty()
        {
            var source = default(string);
            var expected = string.Empty;
            var actual = source.ToSafeString();
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
            var actual = source.ToSafeString();
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void ToSafeStringFromFalseBooleanProperty()
        {
            var source = false;
            var expected = "False";
            var actual = source.ToSafeString();
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
    }
}
