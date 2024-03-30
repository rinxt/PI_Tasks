namespace Task_1_4_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;

            string[] words = inputText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> uniqueWords = new HashSet<string>();

            foreach (string word in words)
            {
                string cleanWord = new string(word.Where(c => !char.IsPunctuation(c)).ToArray());

                if (!string.IsNullOrWhiteSpace(cleanWord))
                {
                    uniqueWords.Add(cleanWord);
                }
            }

            textBox2.Clear();

            foreach (string word in uniqueWords)
            {
                textBox2.AppendText(word + Environment.NewLine);
            }
        }

    }
}
