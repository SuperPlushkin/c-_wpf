using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class Window3 : Window
    {
        static public string num1;
        static public string num2;
        static public char znack = ' ';

        static public string temp_num2;
        static public bool Is = false;

        public Window3()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
        private void calc_Click_Button(object sender, RoutedEventArgs e)
        {
            string otvet = Convert.ToString((sender as Button).Content);

            if (CalcEnter.Text == "0")
            {
                CalcEnter.Text = "";
            }
            CalcEnter.Text = CalcEnter.Text + otvet;

            Is = false;
        }
        private void calc_Click_Button_Is(object sender, RoutedEventArgs e)
        {
            var char_arr = CalcEnter.Text.ToCharArray();
            if (char_arr.Length == 0)
            {
                MessageBox.Show("Введите что-нибудь");
                return;
            }
            if(char_arr[0] == '0' & char_arr.Length == 1 & znack == '/')
            {
                MessageBox.Show("нА Ноль Делит незя");
                return;
            }

            if (CalcEnter.Text != "" & char_arr[char_arr.Length - 1] != ',')
            {
                if(znack != ' ')
                {
                    if (Is)
                    {
                        num1 = CalcEnter.Text;
                        num2 = temp_num2;
                        Otvet();
                        num2 = "";
                    }
                    else
                    {
                        num2 = CalcEnter.Text;
                        Otvet();
                        temp_num2 = num2;
                        Is = true;
                    }

                    CalcEnter.Text = num1;
                }
            }
        }
        private void calc_Click_Button_Operation(object sender, RoutedEventArgs e)
        {
            var char_arr = CalcEnter.Text.ToCharArray();
            if(char_arr.Length == 0)
            {
                MessageBox.Show("Введите что-нибудь");
                return;
            }

            if (char_arr[0] == '0' & char_arr.Length == 1 & znack == '/')
            {
                MessageBox.Show("нА Ноль Делит незя");
                return;
            }

            if (CalcEnter.Text != "" & char_arr[char_arr.Length - 1] != ',')
            {
                if (znack != ' ' & (num1 != null) & !Is)
                {
                    num2 = CalcEnter.Text;
                    Otvet();
                    temp_num2 = num2;
                    num2 = "";
                }
                else
                {
                    if (num1 != null)
                    {
                        num2 = CalcEnter.Text;
                        temp_num2 = num2;
                    }
                    else
                    {
                        num1 = CalcEnter.Text;
                    }
                }

                znack = Convert.ToChar((sender as Button).Content);
                CalcEnter.Text = "";
                Is = false;
            }
        }
        private void calc_Click_Button_Dot(object sender, RoutedEventArgs e)
        {
            var char_arr = CalcEnter.Text.ToCharArray();
            bool not_allowed = false;

            if (char_arr.Length == 0)
            {
                CalcEnter.Text = "0,";
                return;
            }
            foreach(char chr in char_arr)
            {
                if(chr == ',')
                {
                    not_allowed = true;
                    break;
                }
            }

            if (!not_allowed)
            {
                if (char_arr[char_arr.Length - 1] != ',')
                {
                    CalcEnter.Text = CalcEnter.Text + ",";
                }

                Is = false;
            }
        }
        private void calc_Click_Button_Clear(object sender, RoutedEventArgs e)
        {
            CalcEnter.Text = "";
            num1 = null;
            num2 = null;
            temp_num2 = null;
            znack = ' ';
            Is = false;
        }
        private void Otvet()
        {
            switch (znack)
            {
                case '+':
                    num1 = Convert.ToString(Convert.ToDouble(num1) + Convert.ToDouble(num2));
                    break;
                case '-':
                    num1 = Convert.ToString(Convert.ToDouble(num1) - Convert.ToDouble(num2));
                    break;
                case '*':
                    num1 = Convert.ToString(Convert.ToDouble(num1) * Convert.ToDouble(num2));
                    break;
                case '/':
                    num1 = Convert.ToString(Convert.ToDouble(num1) / Convert.ToDouble(num2));
                    break;
            }
            
        }
    }
}
