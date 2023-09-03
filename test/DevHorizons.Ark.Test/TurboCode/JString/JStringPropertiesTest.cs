namespace DevHorizons.Ark.Test
{
    using TurboCode;

    public class JStringPropertiesTest
    {
        [Fact]
        public void NullStringProperty()
        {
            string nullString = null;
            Assert.Equal(nullString, JString.Null);
            Assert.Equal(null, JString.Null);
        }


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

    }
}
