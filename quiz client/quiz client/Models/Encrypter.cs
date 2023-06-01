using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace quiz_client.Models
{
    class Encrypter
    {
        // Szyfrowanie tekstóe czyli pytań i odpowiedzi to szyfr cezara z przesunięciem o 10 liter
        // Szyfrowanie boola to zrobienie (!odpowiedź) jeśli pierwsza litera pytania zawiera się w stringu "QWERTYUIOPZXCVBNqwertyuiopzxcvbn"
        public static string Encrypt(string message, int key)
        {
            string encryptedMessage = "";

            foreach (char c in message)
            {
                if (Char.IsLetter(c))
                {
                    char encryptedChar = (char)(((int)Char.ToLower(c) - 97 + key) % 26 + 97);
                    encryptedMessage += Char.IsUpper(c) ? Char.ToUpper(encryptedChar) : encryptedChar;
                }
                else
                {
                    encryptedMessage += c;
                }
            }

            return encryptedMessage;
        }
        public static string Decrypt(string encryptedMessage, int key)
        {
            return Encrypt(encryptedMessage, 26 - key);
        }
        // Jeśli zawsze klucz będzie ten sam np 10 to wygodniej z tego korzystać:
        public static string Encrypt(string encryptedMessage)
        {
            return Encrypt(encryptedMessage, 10);
        }
        public static string Decrypt(string encryptedMessage)
        {
            return Decrypt(encryptedMessage, 10);
        }

        public static bool DecryptAnswerBool(string answerContent, string answerAnswer)
        {
            bool finalValue;
            if (answerAnswer == "y") finalValue = true;
            else finalValue = false;
            if ("QWERTYUIOPZXCVBNqwertyuiopzxcvbn".Contains(answerContent[0])) finalValue = !finalValue;
            return finalValue;
        }
        public static string EncryptAnswerBool(string answerContent, bool answerAnswer)
        {
            bool finalValue = answerAnswer;
            if ("QWERTYUIOPZXCVBNqwertyuiopzxcvbn".Contains(answerContent[0])) finalValue = !finalValue;
            if (finalValue) return "y";
            return "n";
        }
    }
}
