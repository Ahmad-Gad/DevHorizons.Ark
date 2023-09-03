namespace DevHorizons.Ark.Test
{
    using TurboCode;

    public class StaticMethodsTest
    {
        #region Space
        [Fact]
        public void TestSpaceCount0()
        {
            var count = 0;
            var expected = JString.WhiteSpace;
            var actual = JString.Space(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpaceCount1()
        {
            var count = 1;
            var expected = JString.WhiteSpace;
            var actual = JString.Space(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpaceCountNegative()
        {
            var count = -1;
            var expected = JString.WhiteSpace;
            var actual = JString.Space(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpaceCount2()
        {
            var count = 2;
            var expected = "  ";
            var actual = JString.Space(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpaceCount3()
        {
            var count = 3;
            var expected = "   ";
            var actual = JString.Space(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpaceCount4()
        {
            var count = 4;
            var expected = "    ";
            var actual = JString.Space(count);
            Assert.Equal(expected, actual);
        }
        #endregion Space

        #region Tab
        [Fact]
        public void TestTabCount0()
        {
            var count = 0;
            var expected = JString.HorizontalTab;
            var actual = JString.Tab(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTabCount1()
        {
            var count = 1;
            var expected = JString.HorizontalTab;
            var actual = JString.Tab(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTabCountNegative()
        {
            var count = -1;
            var expected = JString.HorizontalTab;
            var actual = JString.Tab(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTabCount2()
        {
            var count = 2;
            var expected = "\t\t";
            var actual = JString.Tab(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTabCount3()
        {
            var count = 3;
            var expected = "\t\t\t";
            var actual = JString.Tab(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTabCount4()
        {
            var count = 4;
            var expected = "\t\t\t\t";
            var actual = JString.Tab(count);
            Assert.Equal(expected, actual);
        }
        #endregion Tab
    }
}
