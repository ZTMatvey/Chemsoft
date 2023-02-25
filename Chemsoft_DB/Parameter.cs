namespace Chemsoft_BL
{
    public sealed class Parameter<T>
    {
        public string Key { get; set; }

        public T Value { get; set; }

        public Parameter(string key, T value)
        {
            Key = key;
            Value = value;
        }
    }
}
