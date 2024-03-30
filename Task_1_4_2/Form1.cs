using System.Text;

namespace Task_1_4_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string plaintext = textBox1.Text.ToUpper(); 
            string keyword = textBox3.Text.ToUpper();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                textBox2.Text = "Введите ключ";
                return;
            }
            string ciphertext = EncryptVigenere(plaintext, keyword);
            if (ciphertext == "INVALID KEY")
            {
                textBox2.Text = "Некорректный ключ";
            }
            else
            {
                textBox2.Text = ciphertext;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ciphertext = textBox2.Text.ToUpper();
            string keyword = textBox3.Text.ToUpper();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                textBox1.Text = "Введите ключ";
                return;
            }
            string decryptedText = DecryptVigenere(ciphertext, keyword);
            if (decryptedText == "INVALID KEY")
            {
                textBox1.Text = "Некорректный ключ";
            }
            else
            {
                textBox1.Text = decryptedText;
            }
        }

        private string EncryptVigenere(string plaintext, string keyword)
        {
            foreach (char c in keyword)
            {
                if (!char.IsLetter(c))
                {
                    return "INVALID KEY";
                }
            }

            StringBuilder ciphertext = new StringBuilder();

            int keywordIndex = 0;
            foreach (char c in plaintext)
            {
                if (char.IsLetter(c))
                {
                    int shift = keyword[keywordIndex % keyword.Length] - 'A';
                    char encryptedChar = EncryptChar(c, shift);
                    ciphertext.Append(encryptedChar);
                    keywordIndex++;
                }
                else
                {
                    ciphertext.Append(c);
                }
            }

            return ciphertext.ToString();
        }

        private char EncryptChar(char c, int shift)
        {
            return (char)(((c - 'A' + shift) % 26) + 'A');
        }

        private string DecryptVigenere(string ciphertext, string keyword)
        {
            foreach (char c in keyword)
            {
                if (!char.IsLetter(c))
                {
                    return "INVALID KEY";
                }
            }

            StringBuilder plaintext = new StringBuilder();

            int keywordIndex = 0;
            foreach (char c in ciphertext)
            {
                if (char.IsLetter(c))
                {
                    int shift = keyword[keywordIndex % keyword.Length] - 'A';
                    char decryptedChar = DecryptChar(c, shift);
                    plaintext.Append(decryptedChar);
                    keywordIndex++;
                }
                else
                {
                    plaintext.Append(c);
                }
            }

            return plaintext.ToString();
        }
        private char DecryptChar(char c, int shift)
        {
            int decryptedValue = (c - 'A' - shift + 26) % 26;
            return (char)(decryptedValue + 'A');
        }
    }
}
