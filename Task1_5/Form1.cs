using System;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Task1_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Выберите текстовый файл";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Получаем путь к выбранному файлу
                string filePath = openFileDialog1.FileName;

                // Читаем все строки из файла
                string[] lines = File.ReadAllLines(filePath);

                // Создаем регулярное выражение для поиска группы из шести цифр
                Regex regex = new Regex(@"\d{6}");

                string directoryPath = Path.GetDirectoryName(filePath);

                // Создаем новый файл для записи результатов в той же директории
                string resultFilePath = Path.Combine(directoryPath, "result_" + Path.GetFileName(filePath));
                using (StreamWriter writer = new StreamWriter(resultFilePath))
                {
                    // Проходим по каждой строке и заменяем все символы перед группой из шести цифр
                    foreach (string line in lines)
                    {
                        // Ищем все совпадения в строке с помощью регулярного выражения
                        MatchCollection matches = regex.Matches(line);

                        // Если найдены совпадения
                        if (matches.Count > 0)
                        {
                            // Получаем индекс последнего совпадения
                            int lastIndex = matches[matches.Count - 1].Index;

                            // Записываем в файл часть строки, начиная с последней найденной группы из шести цифр
                            writer.WriteLine(line.Substring(lastIndex));
                        }
                        else
                        {
                            // Если совпадений не найдено, записываем строку как есть
                            writer.WriteLine(line);
                        }
                    }
                }

                textBox1.Text = "Готово! Результаты сохранены в файле: " + resultFilePath;
            }


        }
    }
}
