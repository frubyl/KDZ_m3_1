namespace WorkWithJsonFile
{
    /// <summary>
    /// Состояния во время обработки json файла.
    /// </summary>
    public enum States
    {
        Start,
        End,
        FieldName,
        FieldNameEnd,
        FieldValue,
        FieldValueArray,
        ObjectEnd,
        Object,
        None
    }
}
