using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    internal class EncryptionSystem
    {
        // Method to generate a random salt value
        public string salt()
        {
            Random rand = new Random();
            StringBuilder salt = new StringBuilder();
            for (int i = 0; i < 40; i++)
            {
                int randomNumber = rand.Next(0, 57);
                char salt_char = (char)(65 + randomNumber);
                salt.Append(salt_char);
            }
            return salt.ToString();
        }

        // Method to perform Caesar cipher encryption
        public (string, int[]) caesar(string password)
        {
            Random rand = new Random();
            StringBuilder caesar_password = new StringBuilder();
            List<int> caesar_random = new List<int>();
            for (int i = 0; i < password.Length; i++)
            {
                char caesar_char = password[i];
                int randomNumber = rand.Next(33, 127);
                caesar_random.Add(randomNumber);
                caesar_char = (char)((caesar_char + randomNumber - 33) % (127 - 33) + 33);
                caesar_password.Append(caesar_char);
            }
            return (caesar_password.ToString(), caesar_random.ToArray());
        }

        // Method to encrypt the password using Caesar cipher and random numbers
        public string EncryptPassword(string password, int[] randomNumbers)
        {
            StringBuilder encryptedPassword = new StringBuilder();

            for (int i = 0; i < password.Length; i++)
            {
                char caesar_char = password[i];
                int randomNumberIndex = i % randomNumbers.Length;
                int randomNumber = randomNumbers[randomNumberIndex];

                caesar_char = (char)((caesar_char + randomNumber - 33) % (127 - 33) + 33);

                encryptedPassword.Append(caesar_char);
            }

            return encryptedPassword.ToString();
        }

        // Method for first stage of decryption
        public string dqcr(string password)
        {
            StringBuilder encrypted_password = new StringBuilder();
            int dqcr_deletion = 0;
            for (int i = 0; i < password.Length; i++)
            {
                char dqcr_char = password[i];
                dqcr_deletion += (char)(dqcr_char / 5);
                if (dqcr_deletion >= 20)
                {
                    dqcr_deletion -= 20;
                }
                else
                {
                    encrypted_password.Append(dqcr_char);
                }
            }
            if (dqcr_deletion < encrypted_password.Length)
            {
                encrypted_password.Remove(dqcr_deletion, 1);
            }
            return encrypted_password.ToString();
        }

        // Method for second stage of decryption
        public string dqcr2(string password)
        {
            StringBuilder encrypted_password = new StringBuilder();
            int dqcr_deletion = 0;
            for (int i = 0; i < password.Length; i++)
            {
                char dqcr_char = password[i];
                dqcr_deletion += (char)(dqcr_char % 5);
                if (dqcr_deletion >= 20)
                {
                    dqcr_deletion -= 20;

                }
                else
                {
                    encrypted_password.Append(dqcr_char);
                }
            }
            if (dqcr_deletion < encrypted_password.Length)
            {
                encrypted_password.Remove(dqcr_deletion, 1);
            }
            return encrypted_password.ToString();
        }
    }
}
