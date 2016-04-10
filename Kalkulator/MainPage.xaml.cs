using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using YAMP;

namespace Kalkulator
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter.ToString()!="")
            console.Text = e.Parameter.ToString();
        }

        bool bracketopen = false;

        private void console_insertnumber(int number)
        {
            if (console.Text != "0")
            {
                if(console.Text[console.Text.Length-1]!=')')
                    console.Text += number.ToString();
                else console.Text += "*" + number.ToString();
            }
            else console.Text = number.ToString();
        }

        private void consoleInsertBracket()
        {
            string lastCharacter = console.Text[console.Text.Length - 1].ToString();
            int n;
            if (console.Text == "0")
            {
                console.Text = "(";
                bracketopen = true;
            }
            else if (int.TryParse(lastCharacter, out n))
            {
                if(bracketopen)
                {
                    console.Text += ")";
                    bracketopen = false;
                }
                else
                {
                    console.Text += "*(";
                    bracketopen = true;
                }
            }
            else if(lastCharacter == "+" || lastCharacter == "-" || lastCharacter == "*" || lastCharacter == "/")
            {
                if(!bracketopen)
                {
                    console.Text += "(";
                    bracketopen = true;
                }
            }
        }

        private void consoleInsertOperator(string op)
        {
            string lastCharacter = console.Text[console.Text.Length - 1].ToString();
            int n;
            if (int.TryParse(lastCharacter, out n))
            {
                console.Text += op;
            }
            else if(lastCharacter==")")
            {
                console.Text += op;
            }
        }

        private void consoleInsertDot()
        {
            string lastCharacter = console.Text[console.Text.Length - 1].ToString();
            string secondToLastCharacter = "kek";
            if(console.Text.Length>1)
            secondToLastCharacter = console.Text[console.Text.Length - 2].ToString();
            int n;
            if (int.TryParse(lastCharacter, out n) && secondToLastCharacter!=".")
            {
                console.Text += ".";
            }
        }

        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            console_insertnumber(1);
        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            console_insertnumber(2);
        }

        private void button_3_Click(object sender, RoutedEventArgs e)
        {
            console_insertnumber(3);
        }

        private void button_4_Click(object sender, RoutedEventArgs e)
        {
            console_insertnumber(4);
        }

        private void button_5_Click(object sender, RoutedEventArgs e)
        {
            console_insertnumber(5);
        }

        private void button_6_Click(object sender, RoutedEventArgs e)
        {
            console_insertnumber(6);
        }

        private void button_7_Click(object sender, RoutedEventArgs e)
        {
            console_insertnumber(7);
        }

        private void button_8_Click(object sender, RoutedEventArgs e)
        {
            console_insertnumber(8);
        }

        private void button_9_Click(object sender, RoutedEventArgs e)
        {
            console_insertnumber(9);
        }

        private void button_0_Click(object sender, RoutedEventArgs e)
        {
            console_insertnumber(0);
        }

        private void button_bracket_Click(object sender, RoutedEventArgs e)
        {
            consoleInsertBracket();
        }

        private void button_plus_Click(object sender, RoutedEventArgs e)
        {
            consoleInsertOperator("+");
        }

        private void button_minus_Click(object sender, RoutedEventArgs e)
        {
            consoleInsertOperator("-");
        }

        private void button_multiply_Click(object sender, RoutedEventArgs e)
        {
            consoleInsertOperator("*");
        }

        private void button_divide_Click(object sender, RoutedEventArgs e)
        {
            consoleInsertOperator("/");
        }

        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            console.Text = "0";
            bracketopen = false;
        }

        private void button_backspace_Click(object sender, RoutedEventArgs e)
        {
            if (console.Text[console.Text.Length - 1] == '(')
                bracketopen = false;
            else if (console.Text[console.Text.Length - 1] == ')')
                bracketopen = true;
            console.Text = console.Text.Remove(console.Text.Length - 1);
            if (console.Text == "")
                console.Text = "0";
        }

        private void button_equals_Click(object sender, RoutedEventArgs e)
        {
            calculate();
        }

        private void calculate()
        {
            try
            {
                if (bracketopen)
                    console.Text += ")";
                Parser parser = new Parser();
                var result = parser.Evaluate(console.Text);
                console.Text = result.ToString();
            }
            catch
            {
                console.Text = "0";
            }
        }

        private void button_dot_Click(object sender, RoutedEventArgs e)
        {
            consoleInsertDot();
        }

        private void buttonScientific_Click(object sender, RoutedEventArgs e)
        {
            calculate();
            Frame.Navigate(typeof(ScientificMode), console.Text);
        }
    }
}
