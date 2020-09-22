namespace GrassWrapper.Enum
{
    public enum DataType
    {
        Any = -1, //!< Accepts any field
        Numeric = 0, //!< Accepts numeric fields
        String = 1, //!< Accepts string fields
        DateTime = 2 //!< Accepts datetime fields
    };
}