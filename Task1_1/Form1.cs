namespace Task1_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Clear();

            double a, b;
            if (!double.TryParse(textBox1.Text, out a))
            {
                textBox1.Text = "Некорректное значение A";
                return;
            }

            if (!double.TryParse(textBox2.Text, out b))
            {
                textBox2.Text = "Некорректное значение B";
                return;
            }

            double z = Math.Pow(Math.Cos(a) - Math.Cos(b), 2) - Math.Pow(Math.Sin(a) - Math.Sin(b), 2);
            textBox3.Text = z.ToString();
        }

    }
}
