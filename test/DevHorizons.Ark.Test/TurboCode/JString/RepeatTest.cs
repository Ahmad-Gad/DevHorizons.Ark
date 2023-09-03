namespace DevHorizons.Ark.Test
{
    using System.Globalization;
    using TurboCode;

    public class RepeatTest
    {
        #region Test Exceptions
        [Fact]
        public void TestRepeatStringNullStringDelimiter()
        {
            var source = JString.Null;
            var delimiter = JString.WhiteSpace;
            var ex = Record.Exception(() => source.Repeat(2, delimiter));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestRepeatStringNullCharDelimiter()
        {
            var source = JString.Null;
            var delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.Repeat(2, delimiter));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestRepeatCharNullStringDelimiter()
        {
            var source = Character.Null;
            var delimiter = JString.WhiteSpace;
            var ex = Record.Exception(() => source.Repeat(2, delimiter));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void TestRepeatCharNullCharDelimiter()
        {
            var source = Character.Null;
            var delimiter = Character.WhiteSpace;
            var ex = Record.Exception(() => source.Repeat(2, delimiter));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }
        #endregion Test Exceptions

        [Fact]
        public void TestRepeatStringSourceEmptyStringStringDelimiter()
        {
            var source = string.Empty;
            var delimiter = JString.WhiteSpace;
            var count = 3;
            var expected = source;
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatStringSourceEmptyStringCharDelimiter()
        {
            var source = string.Empty;
            var delimiter = Character.WhiteSpace;
            var count = 2;
            var expected = source;
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatStringCount0()
        {
            var source = "Hello";
            var count = 0;
            var expected = source;
            var actual = source.Repeat(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatCharCount1()
        {
            var source = 'A';
            var count = 1;
            var expected = source.ToString(CultureInfo.InvariantCulture);
            var actual = source.Repeat(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatStringCount1()
        {
            var source = "Hello";
            var count = 1;
            var expected = source;
            var actual = source.Repeat(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatCharCount0()
        {
            var source = 'A';
            var count = 0;
            var expected = source.ToString(CultureInfo.InvariantCulture);
            var actual = source.Repeat(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatStringCountNegative()
        {
            var source = "Hello";
            var count = -3;
            var expected = source;
            var actual = source.Repeat(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatCharCount0Negative()
        {
            var source = 'A';
            var count = -2;
            var expected = source.ToString(CultureInfo.InvariantCulture);
            var actual = source.Repeat(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatStringCount2()
        {
            var source = "Hello";
            var count = 2;
            var expected = "HelloHello";
            var actual = source.Repeat(count);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestRepeatCharCount2()
        {
            var source = 'A';
            var count = 2;
            var expected = "AA";
            var actual = source.Repeat(count);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatStringCount3StringDelimiter()
        {
            var source = "Hello";
            var count = 3;
            var delimiter = "<>";
            var expected = "Hello<>Hello<>Hello";
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatStringCount3StringDelimiterNull()
        {
            var source = "Hello";
            var count = 3;
            var delimiter = JString.Null;
            var expected = "HelloHelloHello";
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatStringCount3StringDelimiterEmptyString()
        {
            var source = "Hello";
            var count = 3;
            var delimiter = string.Empty;
            var expected = "HelloHelloHello";
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatStringCount3CharDelimiter()
        {
            var source = "Hello";
            var count = 3;
            var delimiter = Character.WhiteSpace;
            var expected = "Hello Hello Hello";
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatStringCount0CharDelimiter()
        {
            var source = "Hello";
            var count = 0;
            var delimiter = Character.WhiteSpace;
            var expected = source;
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatStringCount1CharDelimiter()
        {
            var source = "Hello";
            var count = 1;
            var delimiter = Character.WhiteSpace;
            var expected = source;
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatStringCountNegativeCharDelimiter()
        {
            var source = "Hello";
            var count = -1;
            var delimiter = Character.WhiteSpace;
            var expected = source;
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatStringCount3CharDelimiterNull()
        {
            var source = "Hello";
            var count = 3;
            var delimiter = Character.Null;
            var expected = "HelloHelloHello";
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatCharCount3StringDelimiter()
        {
            var source = 'A';
            var count = 3;
            var delimiter = "<>";
            var expected = "A<>A<>A";
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestRepeatCharCount3ChaDelimiter()
        {
            var source = 'A';
            var count = 3;
            var delimiter = Character.WhiteSpace;
            var expected = "A A A";
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatCharCount3ChaDelimiterNull()
        {
            var source = 'A';
            var count = 3;
            var delimiter = Character.Null;
            var expected = "AAA";
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatCharCount0ChaDelimiter()
        {
            var source = 'A';
            var count = 0;
            var delimiter = Character.WhiteSpace;
            var expected = "A";
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatCharCount1ChaDelimiter()
        {
            var source = 'A';
            var count = 1;
            var delimiter = Character.WhiteSpace;
            var expected = "A";
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRepeatCharCountNegativeChaDelimiter()
        {
            var source = 'A';
            var count = -1;
            var delimiter = Character.WhiteSpace;
            var expected = "A";
            var actual = source.Repeat(count, delimiter);
            Assert.Equal(expected, actual);
        }
    }
}
