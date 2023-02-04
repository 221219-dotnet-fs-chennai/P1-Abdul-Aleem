using System;
namespace BusinessLogic
{
    // </summary>
    public static class TokenGenerator
    {

        public static string TokenGeneratorToken()
        {
            Random rnd = new Random();
            string[] words = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            string generatedToken = $"{words[rnd.Next(0, words.Length)]}{rnd.Next(1, 10)}{words[rnd.Next(0, words.Length)]}{rnd.Next(1, 10)}{words[rnd.Next(0, words.Length)]}{words[rnd.Next(0, words.Length)]}{rnd.Next(1, 10)}{words[rnd.Next(0, words.Length)]}{rnd.Next(1, 10)}{words[rnd.Next(0, words.Length)]}{words[rnd.Next(0, words.Length)]}{rnd.Next(1, 10)}{words[rnd.Next(0, words.Length)]}{rnd.Next(1, 10)}{words[rnd.Next(0, words.Length)]}{words[rnd.Next(0, words.Length)]}";

            return generatedToken;

        }
    }
}

