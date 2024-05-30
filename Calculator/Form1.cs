using System.CodeDom.Compiler;
using System.Security.Cryptography.Xml;

namespace Calculator
{
    public partial class Form1 : Form
    {
        const double d = 0.00000001;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        static private double fExp(double x, double e)
        {
            double res = 0;
            double current_u = 0;
            int number_u = 0;
            do
            {
                current_u = uForExp(x, number_u);
                res += current_u;
                number_u++;
            }
            while (Math.Abs(current_u) >= e);
            return res;
        }

        static private double uForExp(double x, int number)
        {
            if (number == 0)
                return 1;
            else
            {
                double u = 0;
                u = (x / number) * uForExp(x, number - 1);
                return u;
            }
        }

        static private double fLn(double x, double e)
        {
            double res = 0;
            double current_u = 0;
            int number_u = 0;
            do
            {
                current_u = uForLn(x, number_u);
                res += current_u;
                number_u++;
            }
            while (Math.Abs(current_u) >= e);
            return res * (-2);
        }

        static private double uForLn(double x, double number)
        {
            double u0 = (1 - x) / (1 + x);
            return (1 / (2 * number + 1)) * Math.Pow(u0, 2 * number + 1);
        }

        static private double fSin(double x, double e)
        {
            double res = 0;
            int number = 1;

            while (x > 2 * Math.PI)
            {
                x-= 2 * Math.PI;
            }

            double u = x;

            while (Math.Abs(u) >= e)
            {
                res = res + u;
                u = u * (-1) * (x * x) / ((2 * number + 1) * (2 * number));
                number = number + 1;
            }

            return res;
        }
        static private double fCos(double x, double e)
        {
            double v = 1;
            double res = 0;
            int number = 1;

            while (x > 2 * Math.PI)
            {
                x -= 2 * Math.PI;
            }

            while (Math.Abs(v) >= e)
            {
                res = res + v;
                v = v * (-1) * (x * x) / ((2 * number - 1) * (2 * number));
                number = number + 1;
            }

            return res;
        }

        static private double fTg(double x, double e)
        {
            return fSin(x, e) / fCos(x, e);
        }

        static private double fCtg(double x, double e)
        {
            return fCos(x, e) / fSin(x, e);
        }

        static private double fSqrt(double x, double e)
        {
            double x0 = x / 2;
            double x1 = 0.5 * (x0 + x / x0);
            while(Math.Abs(x1 - x0) > e)
            {
                double temp = x1;
                x0 = x1;
                x1 = 0.5 * (temp + x / temp);
            }
            return x1;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x;
            if (!Double.TryParse(textBox1.Text, out x))
            {
                label3.Text = "Введите X - корректное число с плавающей точкой";
                return;
            }

/*            double p;
            if (!Double.TryParse(textBox3.Text, out p) || p <= 0)
            {
                label3.Text = "Введите погрешность - корректное\nположительное число с плавающей точкой";
                return;
            }*/

            double res = fExp(x, d);
            textBox2.Text = res.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x;

            if (!Double.TryParse(textBox1.Text, out x))
            {
                label3.Text = "Введите X - корректное число с плавающей точкой";
                return;
            }

            if (x <= 0)
            {
                label3.Text = "X - положительное число";
                return;
            }

/*            double p;
            if (!Double.TryParse(textBox3.Text, out p) || p <= 0)
            {
                label3.Text = "Введите погрешность - корректное\nположительное число с плавающей точкой";
                return;
            }*/

            double res = fLn(x, d);
            textBox2.Text = res.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double x;
            if (!Double.TryParse(textBox1.Text, out x))
            {
                label3.Text = "Введите X - корректное число с плавающей точкой";
                return;
            }

/*            double p;
            if (!Double.TryParse(textBox3.Text, out p) || p <= 0)
            {
                label3.Text = "Введите погрешность - корректное\nположительное число с плавающей точкой";
                return;
            }*/
            if(check(x).Item2)
            {
                double res = fSin(check(x).Item1, d);
                textBox2.Text = res.ToString();
            }
            else
            {
                label3.Text = "Выберите единицу измерения";
                return;
            }
            
        }

        private (double, bool) check(double x)
        {
            if (radioButton2.Checked)
            {
                return (x, true);
            }
            else if (radioButton1.Checked)
            {
                x = (x * Math.PI) / 180;
                return (x, true);
            }
            else
            {
                return (x, false);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double x;
            if (!Double.TryParse(textBox1.Text, out x))
            {
                label3.Text = "Введите X - корректное число с плавающей точкой";
                return;
            }

            if (x < 0)
            {
                label3.Text = "X - положительное число";
                return;
            }
/*
            double p;
            if (!Double.TryParse(textBox3.Text, out p) || p <= 0)
            {
                label3.Text = "Введите погрешность - корректное\nположительное число с плавающей точкой";
                return;
            }*/

/*            double x0;
            if (!Double.TryParse(textBox4.Text, out x0) || x0 < 0)
            {
                label3.Text = "Введите начальный элемент - корректное\nположительное число с плавающей точкой";
                return;
            }*/

            double res = fSqrt(x, d);
            textBox2.Text = res.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double x;
            if (!Double.TryParse(textBox1.Text, out x))
            {
                label3.Text = "Введите X - корректное число с плавающей точкой";
                return;
            }

/*            double p;
            if (!Double.TryParse(textBox3.Text, out p) || p <= 0)
            {
                label3.Text = "Введите погрешность - корректное\nположительное число с плавающей точкой";
                return;
            }*/
            if (check(x).Item2)
            {
                double res = fCos(check(x).Item1, d);
                textBox2.Text = res.ToString();
            }
            else
            {
                label3.Text = "Выберите единицу измерения";
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double x;
            if (!Double.TryParse(textBox1.Text, out x))
            {
                label3.Text = "Введите X - корректное число с плавающей точкой";
                return;
            }

/*            double p;
            if (!Double.TryParse(textBox3.Text, out p) || p <= 0)
            {
                label3.Text = "Введите погрешность - корректное\nположительное число с плавающей точкой";
                return;
            }*/
            if (check(x).Item2)
            {
                double res = fTg(check(x).Item1, d);
                textBox2.Text = res.ToString();
            }
            else
            {
                label3.Text = "Выберите единицу измерения";
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double x;
            if (!Double.TryParse(textBox1.Text, out x))
            {
                label3.Text = "Введите X - корректное число с плавающей точкой";
                return;
            }

/*            double p;
            if (!Double.TryParse(textBox3.Text, out p) || p <= 0)
            {
                label3.Text = "Введите погрешность - корректное\nположительное число с плавающей точкой";
                return;
            }*/
            if (check(x).Item2)
            {
                double res = fCtg(check(x).Item1, d);
                textBox2.Text = res.ToString();
            }
            else
            {
                label3.Text = "Выберите единицу измерения";
                return;
            }
        }

        private void Калькулятор_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}