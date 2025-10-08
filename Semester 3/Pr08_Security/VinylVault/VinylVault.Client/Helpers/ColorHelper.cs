namespace VinylVault.Client.Helpers
{
    public static class ColorHelper
    {
        private static Random rand = new();
        public static string GetVinylStyle()
        {
            int r = rand.Next(120, 255);
            int g = rand.Next(120, 255);
            int b = rand.Next(120, 255);
            string labelColor = $"rgb({r},{g},{b})";

            return $@"
            background: radial-gradient(circle at center, {labelColor} 0 20%, black 20% 100%);
            width: 60px;
            height: 60px;
            border-radius: 50%;
            box-shadow: 0 0 4px rgba(0,0,0,0.2);
        ";
        }
    }
}
