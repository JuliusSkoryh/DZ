using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace chifer
{
    internal class VigenereCipher
    {     
        private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


        private string ReworkKey (string message, string key)
        {           
            var temp = new StringBuilder();
            int j = 0;

            for (int i = 0; i < message.Length; i++)
            {
                if (j == key.Length)
                {
                    j = 0;
                }

                temp.Append(key[j]);

                j++;
            }

            return temp.ToString();
        }
        public string Encryption(string message, string key)
        {
            message = message.ToUpper();
            key = key.ToUpper();

            string temp = ReworkKey(message, key); // растяжение ключа по длине сообщения
            temp = temp.ToUpper();
            var result = new StringBuilder();

            int indexOfMesage;
            int indexOfKey;
            int shift;

            for (int i = 0; i < message.Length; i++)
            {
                indexOfMesage = alphabet.IndexOf(message[i]);
                indexOfKey = alphabet.IndexOf(temp[i]);
                              
                if (indexOfKey == -1 || indexOfMesage == -1)
                {
                    result.Append(message[i]);
                }
                else
                {
                    shift = (indexOfMesage + indexOfKey) % 26 + 1;
                    result.Append(alphabet[shift]);
                }                
            }
            return result.ToString();
        }

        public string Decoder(string message, string key)
        {
            var result = new StringBuilder();

            string temp = ReworkKey(message, key);

            temp = temp.ToUpper();           
            message = message.ToUpper();
            key = key.ToUpper();

            int indexOfMesage;
            int indexOfKey;
            int shift;

            for(int i = 0; i<message.Length; i++)
            {
                indexOfMesage = alphabet.IndexOf(message[i]);
                indexOfKey = alphabet.IndexOf(temp[i]);

                if (indexOfKey == -1 || indexOfMesage == -1)
                {
                    result.Append(message[i]);
                }
                else
                {
                    if(indexOfMesage > indexOfKey)
                    {
                        shift = (indexOfMesage - indexOfKey) % 26 - 1;
                    }
                    else
                    {
                        shift = (indexOfMesage + 26 - indexOfKey) % 26 - 1;
                    }
                    result.Append(alphabet[shift]);
                }
            }
            return result.ToString();
        }

    }
}
