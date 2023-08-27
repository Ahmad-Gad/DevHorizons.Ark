namespace DevHorizons.Ark.Test
{
    using TurboCode;

    public class JSplitLeftRight
    {
        #region JSplit
        [Fact]
        public void JSplit_LeftRight_0()
        {
            var source = "[Ahmad] [Gad]";
            var expected = "Ahmad";
            var actual = source.JSplit('[', ']');
            Assert.NotEmpty(actual);
            Assert.Equal(2, actual.Count);
            Assert.Equal(expected, actual[0]);
        }

        [Fact]
        public void JSplit_LeftRight_1()
        {
            var source = "[Ahmad] [Gad]";
            var expected = "Gad";
            var actual = source.JSplit('[', ']');
            Assert.NotEmpty(actual);
            Assert.Equal(2, actual.Count);
            Assert.Equal(expected, actual[1]);
        }

        [Fact]
        public void JSplit_LeftRight_MatchCase0()
        {
            var source = "zAhmadk zGadK";
            var expected = "Ahmad";
            var actual = source.JSplit('z', 'k', true);
            Assert.NotEmpty(actual);
            Assert.Single(actual);
            Assert.Equal(expected, actual[0]);
        }

        [Fact]
        public void JSplit_LeftRight_MatchCase1()
        {
            var source = "zAhmadk zGadK";
            var expected = "Gad";
            var actual = source.JSplit('z', 'k', false);
            Assert.NotEmpty(actual);
            Assert.Equal(2, actual.Count);
            Assert.Equal(expected, actual[1]);
        }

        [Fact]
        public void JSplit_LeftRight_MatchCaseStart00()
        {
            var source = "zAhmadk zGadK";
            var expected = "Gad";
            var actual = source.JSplit('z', 'k', 0 , false);
            Assert.NotEmpty(actual);
            Assert.Equal(2, actual.Count);
            Assert.Equal(expected, actual[1]);
        }

        [Fact]
        public void JSplit_LeftRight_Start0()
        {
            var source = "[Ahmad] [Gad]";
            var expected = "Gad";
            var actual = source.JSplit('[', ']', 1);
            Assert.NotEmpty(actual);
            Assert.Single(actual);
            Assert.Equal(expected, actual[0]);
        }

        [Fact]
        public void JSplit_LeftRight_StartMatchCaseTrue()
        {
            var source = "###JAhmadk jGadk";
            var expected = "Gad";
            var actual = source.JSplit('j', 'k', 1, true);
            Assert.NotEmpty(actual);
            Assert.Single(actual);
            Assert.Equal(expected, actual[0]);
        }

        [Fact]
        public void JSplit_LeftRight_StartMatchCaseFalse0()
        {
            var source = "###JAhmadk jGadk";
            var expected = "Ahmad";
            var actual = source.JSplit('j', 'k', 1, false);
            Assert.NotEmpty(actual);
            Assert.Equal(2, actual.Count);
            Assert.Equal(expected, actual[0]);
        }

        [Fact]
        public void JSplit_LeftRight_StartMatchCaseFalse1()
        {
            var source = "###JAhmadk jGadk";
            var expected = "Gad";
            var actual = source.JSplit('j', 'k', 1, false);
            Assert.NotEmpty(actual);
            Assert.Equal(2, actual.Count);
            Assert.Equal(expected, actual[1]);
        }

        [Fact]
        public void JSplit_LeftRight_StartEnd0()
        {
            var source = "[Ahmad] [Adel] [Gad]";
            var expected = "Adel";
            var actual = source.JSplit('[', ']', 2, 15);
            Assert.NotEmpty(actual);
            Assert.Single(actual);
            Assert.Equal(expected, actual[0]);
        }


        [Fact]
        public void JSplit_LeftRight_ReturnNullCondition01()
        {
            var source = "[Ahmad] [Adel] [Gad]";
            var actual = source.JSplit('[', ']', -1, 15);
            Assert.Null(actual);
        }

        [Fact]
        public void JSplit_LeftRight_ReturnNullCondition02()
        {
            var source = "[Ahmad] [Adel] [Gad]";
            var actual = source.JSplit('[', ']', 1, 0);
            Assert.Null(actual);
        }

        [Fact]
        public void JSplit_LeftRight_ReturnNullCondition03()
        {
            var source = "[Ahmad] [Adel] [Gad]";
            var start = source.Length;
            var actual = source.JSplit('[', ']', start, 0);
            Assert.True(start >= source.Length);
            Assert.Null(actual);
        }

        [Fact]
        public void JSplit_LeftRight_ReturnNullCondition04()
        {
            var source = "[Ahmad] [Adel] [Gad]";
            var end = source.Length;
            var actual = source.JSplit('[', ']', 0, end);
            Assert.True(end >= source.Length);
            Assert.Null(actual);
        }


        [Fact]
        public void JSplit_LeftRight_ReturnNullCondition05()
        {
            var source = "[Ahmad] [Adel] [Gad]";
            var start = 5;
            var end = 2;
            var actual = source.JSplit('[', ']', start, end);
            Assert.True(start >= end);
            Assert.Null(actual);
        }
        #endregion JSplit
    }
}
