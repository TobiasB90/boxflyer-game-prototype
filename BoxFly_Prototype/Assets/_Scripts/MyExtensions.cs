namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static bool isInRange(this float number, float min, float max)
        {
            return number >= min && number <= max;
        }
    }
}
