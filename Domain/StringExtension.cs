using System;

namespace Domain
{
    public static class StringExtensions
    {
        public static string ClearBlanks(this string str)
        {
            if (str == null)
                return str;

            str = str.Replace("\a", "");
            str = str.Replace("\b", "");
            str = str.Replace("\f", "");
            str = str.Replace("\n", "");
            str = str.Replace("\r", "");
            str = str.Replace("\t", "");
            str = str.Replace("\v", "");


            var words = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            str = "";

            for (var i = 0; i < words.Length; i++)
            {
                str += words[i];

                if (i != words.Length - 1)
                    str += " ";
            }

            return str;
        }
        public static string MakeVariableFirsLetterToUpperCase(this string text)
        {
            text = text.ClearBlanks();

            if (string.IsNullOrWhiteSpace(text))
                return text;

            var letters = text.ToCharArray();
            letters[0] = letters[0] == 'i' ? 'I' : Char.ToUpper(letters[0]);
            text = new String(letters);

            return text;
        }
    }
}