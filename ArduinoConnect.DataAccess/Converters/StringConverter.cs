namespace ArduinoConnect.DataAccess.Converters
{
    public static class StringConverter
    {
        public static string MakeWhitespaceNull(string input)
            => string.IsNullOrWhiteSpace(input) ? null : input;
    }
}
