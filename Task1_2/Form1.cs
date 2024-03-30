using System;

namespace Task1_2
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

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private int[] numbers;

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int number) || number < 10 || number > 100)
            {
                textBox1.Text = "Введите число от 10 до 100";
            }
            else
            {
                numbers = GenerateArray(number);
                string numbersString = string.Join(Environment.NewLine, numbers.Select(n => n.ToString()));
                textBox2.Text = numbersString;

                int swaps, comparisons;
                BubbleSort(numbers, out swaps, out comparisons);

                string sortedNumbersString = string.Join(Environment.NewLine, numbers.Select(n => n.ToString()));
                textBox3.Text = sortedNumbersString;

                textBox5.Text = $"Количество перестановок (M): {swaps}\r\nКоличество сравнений (C): {comparisons}";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (numbers == null)
            {
                // Handle the case when numbers array is not initialized
                textBox4.Text = "Сначала сгенерируйте массив";
                return;
            }

            double mean = CalculateArithmeticMeanOfPositiveElements(numbers);

            // Display arithmetic mean in textBox4
            if (double.IsNaN(mean))
            {
                textBox4.Text = "Нет положительных элементов";
            }
            else
            {
                textBox4.Text = mean.ToString();
            }

        }

        private int[] GenerateArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 101);
            }
            return array;
        }

        private void BubbleSort(int[] array, out int swaps, out int comparisons)
        {
            swaps = 0;
            comparisons = 0;
            bool swapped;
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    comparisons++;
                    if (array[j] > array[j + 1])
                    {
                        // Swap array[j] and array[j+1]
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                        swaps++;
                    }
                }
                if (!swapped)
                    break;
            }
        }

        private double CalculateArithmeticMeanOfPositiveElements(int[] array)
        {
            double sum = 0;
            int count = 0;
            foreach (int num in array)
            {
                if (num > 0)
                {
                    sum += num;
                    count++;
                }
            }

            if (count > 0)
            {
                return sum / count;
            }
            else
            {
                return double.NaN;
            }
        }

    }
}

