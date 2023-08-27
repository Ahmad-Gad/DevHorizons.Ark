namespace DevHorizons.Ark.Test.Characters
{
    using TurboCode;

    public class CharacterPropertiesTest
    {
        [Fact]
        public void NullCharacterProperty()
        {
            Assert.Equal('\0', Character.Null);
        }

        [Fact]
        public void CommaCharacterProperty()
        {
            Assert.Equal(',', Character.Comma);
        }

        [Fact]
        public void ColonCharacterProperty()
        {
            Assert.Equal(':', Character.Colon);
        }

        [Fact]
        public void SemiColonCharacterProperty()
        {
            Assert.Equal(';', Character.SemiColon);
        }

        [Fact]
        public void CrCharacterProperty()
        {
            Assert.Equal(Convert.ToChar(13), Character.Cr);
            Assert.Equal(Convert.ToChar(13), Convert.ToChar('\r'));
            Assert.Equal("\r", Character.Cr.ToString());
        }

        [Fact]
        public void LfCharacterProperty()
        {
            Assert.Equal(Convert.ToChar(10), Character.Lf);
            Assert.Equal(Convert.ToChar(10), Convert.ToChar('\n'));
            Assert.Equal("\n", Character.Lf.ToString());
        }

        [Fact]
        public void AtSignCharacterProperty()
        {
            Assert.Equal('@', Character.AtSign);
        }

        [Fact]
        public void AsteriskSignCharacterProperty()
        {
            Assert.Equal('*', Character.Asterisk);
        }

        [Fact]
        public void HyphenSignCharacterProperty()
        {
            Assert.Equal('-', Character.Hyphen);
        }

        [Fact]
        public void GraveAccentCharacterProperty()
        {
            Assert.Equal('`', Character.GraveAccent);
        }

        [Fact]
        public void AmpersandCharacterProperty()
        {
            Assert.Equal('&', Character.Ampersand);
        }

        [Fact]
        public void EqualsCharacterProperty()
        {
            Assert.Equal('=', Character.Equals);
        }

        [Fact]
        public void HyphenCharacterProperty()
        {
            Assert.Equal('-', Character.Hyphen);
        }


        [Fact]
        public void CircumflexCharacterProperty()
        {
            Assert.Equal('^', Character.Circumflex);
        }

        [Fact]
        public void HorizontalTabCharacterProperty()
        {
            Assert.Equal(Convert.ToChar(9), Character.HorizontalTab);
            Assert.Equal("\t", Character.HorizontalTab.ToString());
        }

        [Fact]
        public void LessThanCharacterProperty()
        {
            Assert.Equal('<', Character.LessThan);
        }

        [Fact]
        public void GreaterThanCharacterProperty()
        {
            Assert.Equal('>', Character.GreaterThan);
        }

        [Fact]
        public void HashSignCharacterProperty()
        {
            Assert.Equal('#', Character.HashSign);
        }

        [Fact]
        public void DollarSignCharacterProperty()
        {
            Assert.Equal('$', Character.DollarSign);
        }

        [Fact]
        public void DoubleQuotesCharacterProperty()
        {
            Assert.Equal('"', Character.DoubleQuotes);
        }

        [Fact]
        public void SingleQuoteCharacterProperty()
        {
            Assert.Equal('\'', Character.SingleQuote);
            Assert.Equal("'", Character.SingleQuote.ToString());
        }

        [Fact]
        public void EquivalencySignCharacterProperty()
        {
            Assert.Equal('~', Character.EquivalencySign);

        }

        [Fact]
        public void ExclamationMarkCharacterProperty()
        {
            Assert.Equal('!', Character.ExclamationMark);

        }

        [Fact]
        public void BackSlashCharacterProperty()
        {
            Assert.Equal('\\', Character.BackSlash);
            Assert.Equal(@"\", Character.BackSlash.ToString());
        }

        [Fact]
        public void SlashCharacterProperty()
        {
            Assert.Equal('/', Character.Slash);
        }


        [Fact]
        public void OpeningBraceCharacterProperty()
        {
            Assert.Equal('{', Character.OpeningBrace);
        }

        [Fact]
        public void ClosingBraceCharacterProperty()
        {
            Assert.Equal('}', Character.ClosingBrace);
        }

        [Fact]
        public void OpeningBracketCharacterProperty()
        {
            Assert.Equal('(', Character.OpeningBracket);
        }

        [Fact]
        public void ClosingBracketCharacterProperty()
        {
            Assert.Equal(')', Character.ClosingBracket);
        }

        [Fact]
        public void OpeningSquareBracketCharacterProperty()
        {
            Assert.Equal('[', Character.OpeningSquareBracket);
        }

        [Fact]
        public void ClosingSquareBracketCharacterProperty()
        {
            Assert.Equal(']', Character.ClosingSquareBracket);
        }

        [Fact]
        public void UnderScoreCharacterProperty()
        {
            Assert.Equal('_', Character.UnderScore);
        }

        [Fact]
        public void QuestionMarkCharacterProperty()
        {
            Assert.Equal('?', Character.QuestionMark);
        }

        [Fact]
        public void PeriodCharacterProperty()
        {
            Assert.Equal('.', Character.Period);
        }

        [Fact]
        public void PlusCharacterProperty()
        {
            Assert.Equal('+', Character.Plus);
        }


        [Fact]
        public void PercentSignCharacterProperty()
        {
            Assert.Equal('%', Character.PercentSign);
        }

        [Fact]
        public void VerticalBarCharacterProperty()
        {
            Assert.Equal('|', Character.VerticalBar);
        }

        [Fact]
        public void WhiteSpaceCharacterProperty()
        {
            Assert.Equal(' ', Character.WhiteSpace);
        }

        [Fact]
        public void BulletCharacterProperty()
        {
            Assert.Equal('•', Character.Bullet);
        }

        [Fact]
        public void BrokenBarCharacterProperty()
        {
            Assert.Equal('¦', Character.BrokenBar);
        }

        [Fact]
        public void CentSignCharacterProperty()
        {
            Assert.Equal('¢', Character.CentSign);
        }

        [Fact]
        public void CurrencySignCharacterProperty()
        {
            Assert.Equal('¤', Character.CurrencySign);
        }

        [Fact]
        public void TrademarkSignCharacterProperty()
        {
            Assert.Equal('™', Character.TrademarkSign);
        }


        [Fact]
        public void RegisteredSignCharacterProperty()
        {
            Assert.Equal('®', Character.RegisteredSign);
        }

        [Fact]
        public void CopyrightSignCharacterProperty()
        {
            Assert.Equal('©', Character.CopyrightSign);
        }

        [Fact]
        public void EuroSignCharacterProperty()
        {
            Assert.Equal('€', Character.EuroSign);
        }

        [Fact]
        public void BritishPoundSignCharacterProperty()
        {
            Assert.Equal('£', Character.BritishPoundSign);
        }

        [Fact]
        public void YenCharacterProperty()
        {
            Assert.Equal('¥', Character.YenSign);
        }
    }
}