namespace DevHorizons.Ark.Test
{
    using Exceptions;

    public class SplitCutRightTest
    {
        [Fact]
        public void SplitCutRightTest_0()
        {
            var source = "Ahmad Adel Gad";
            var ex = Record.Exception(() => source.SplitCutRight(' ', -1));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }
    }
}
