namespace DevHorizons.Ark.Test
{
    using TurboCode;

    public class JStringConvertTest
    {
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
    }
}
