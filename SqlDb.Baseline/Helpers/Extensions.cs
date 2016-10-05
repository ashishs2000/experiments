namespace SqlDb.Baseline.Helpers
{
    public static class Extensions
    {
        public static void AddHeader(this FileWriter writer, string heading)
        {
            writer.WriteLine("".PadRight(50, '-'));
            writer.WriteLine($"-- {heading}");
            writer.WriteLine("".PadRight(50, '-'));
        }
    }
}