namespace DevHorizons.Ark.Exceptions
{
    [Flags]
    public enum ArgumentExceptionCode
    {
        Nullable = -1,

        EmptyString = -2,

        EmptySpacesOrTabs = -4,

        OutRange = 1,

        InvalidValue = 2,

        ConflictWithOtherArgument = 4
    }
}
