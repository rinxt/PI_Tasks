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

                string filePath = openFileDialog1.FileName;

                string[] lines = File.ReadAllLines(filePath);

                Regex regex = new Regex(@"\d{6}");

                string directoryPath = Path.GetDirectoryName(filePath);
                string resultFilePath = Path.Combine(directoryPath, "result_" + Path.GetFileName(filePath));

                using (StreamWriter writer = new StreamWriter(resultFilePath))
                {

                    foreach (string line in lines)
                    {
                        MatchCollection matches = regex.Matches(line);

                        if (matches.Count > 0)
                        {
                            int lastIndex = matches[matches.Count - 1].Index;

                            writer.WriteLine(line.Substring(lastIndex));
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                }

                textBox1.Text = "Готово! Результаты сохранены в файле: " + resultFilePath;
            }


        }
    }
}
