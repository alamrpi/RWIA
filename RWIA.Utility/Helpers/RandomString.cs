using System.Text;

namespace RWIA.Utility.Helpers
{
    public static class RandomString
    {
        private const string Characters = "abcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly Random random;
        static RandomString()
        {
            random = new Random();
        }
        public static string Generate(int length)
        {
            var result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(Characters.Length);
                result.Append(Characters[index]);
            }
            return result.ToString();
        }
    }
}
