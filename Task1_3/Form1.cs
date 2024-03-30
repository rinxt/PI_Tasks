namespace Task1_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool textBox1Valid = int.TryParse(textBox1.Text, out int rows) && rows >= 2 && rows <= 10;
            bool textBox2Valid = int.TryParse(textBox2.Text, out int columns) && columns >= 2 && columns <= 10;

            if (textBox1Valid && textBox2Valid)
            {

                for (int i = Controls.Count - 1; i >= 0; i--)
                {
                    Control control = Controls[i];
                    if (control is TextBox textBox &&
                        textBox.Name != "textBox1" &&
                        textBox.Name != "textBox2")
                    {
                        Controls.Remove(textBox);
                        textBox.Dispose();
                    }
                }

                const int textBoxWidth = 25;
                const int textBoxHeight = 20;
                const int spacing = 5;
                Random random = new Random();

                int[,] leftMatrix = new int[rows, columns];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        int randomValue = random.Next(-99, 100);
                        leftMatrix[i, j] = randomValue;

                        TextBox textBox = new TextBox();
                        textBox.Location = new Point(12 + j * (textBoxWidth + spacing), 60 + label4.Height + i * (textBoxHeight + spacing)); // Учитываем отступ от label4
                        textBox.Size = new Size(textBoxWidth, textBoxHeight);
                        textBox.Text = randomValue.ToString();
                        Controls.Add(textBox);
                    }
                }

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        int newIndex = (j + 3) % columns; // Правильное вычисление нового индекса после циклического сдвига на 3 элемента влево
                        TextBox textBox = new TextBox();
                        textBox.Location = new Point(32 + columns * (textBoxWidth + spacing) + spacing + j * (textBoxWidth + spacing), 60 + label4.Height + i * (textBoxHeight + spacing)); // Учитываем отступ от label4 и располагаем справа от созданной матрицы
                        textBox.Size = new Size(textBoxWidth, textBoxHeight);
                        textBox.Text = leftMatrix[i, newIndex].ToString();
                        Controls.Add(textBox);
                    }
                }

                label4.Text = "";
            }
            else
            {
                label4.Text = "Введите числа от 2 до 10 в оба поля";
            }
        }
    }
}
