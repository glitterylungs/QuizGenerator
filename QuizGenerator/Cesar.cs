using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator
{
     class Cesar
    {
        private int key = 1;

        public string encryption(string text)
        {
            char[] textChars = text.ToCharArray();
            for(int i = 0; i < textChars.Length; i++)
            {
                textChars[i] = (char)(textChars[i] + key);
            }
            return new String(textChars);
        }

        public string decryption(string text)
        {
            char[] textChars = text.ToCharArray();
            for (int i = 0; i < textChars.Length; i++)
            {
                textChars[i] = (char)(textChars[i] - key);
            }
            return new String(textChars);
        }
    }
}
