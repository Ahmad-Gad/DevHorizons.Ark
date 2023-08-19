namespace DevHorizons.Ark.Exceptions
{
    public class ExceptionSource
    {
        public string Assembly { get; internal set; }

        public string Class { get; internal set; }

        public string Method { get; internal set; }

        public string? Argument { get; internal set; }
    }
}
